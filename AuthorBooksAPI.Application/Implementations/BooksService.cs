using AuthorBooksAPI.Application.DTO;
using AuthorBooksAPI.Application.Interfaces;
using AuthorBooksAPI.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthorBooksAPI.Application.Implementations
{
    public class BooksService : IBooksService
    {
        private readonly IBooksRepository _booksRepository;

        public BooksService(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public async Task<List<BookDto>> GetAllAsync()
        {
           var books = await _booksRepository.GetAllAsync();
           return books.Select(x => new BookDto
           {
               BookId = x.BookId,
               Title = x.Title,
               BookNumber = x.BookNumber,
               PublishedYear = x.PublishedYear,
               Authors = x.Authors.Select(a => new AuthorDto
               {
                   AuthorId = a.AuthorId,
                   FirstName = a.FirstName,
                   LastName = a.LastName,
                   Address = a.Address
               }).ToList()
           }).ToList();

        }

        public async Task<BookDto?> GetByIdAsync(int bookId)
        {
            var book = await _booksRepository.GetByIdAsync(bookId);

            if (book is null)
            {
                return null;
            }

            return new BookDto
            {
                BookId = book.BookId,
                Title = book.Title,
                BookNumber = book.BookNumber,
                PublishedYear = book.PublishedYear,
                Authors = book.Authors.Select(a => new AuthorDto
                {
                    AuthorId = a.AuthorId,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    Address = a.Address
                }).ToList()
            };
        }

        public async Task<BookDto?> CreateAsync(CreateBookDto bookDto)
        {
            var book = await _booksRepository.AddAsync(new Domain.Entities.Book
            {
                Title = bookDto.Title,
                BookNumber = bookDto.BookNumber,
                PublishedYear = bookDto.PublishedYear,
                CreatedDate = DateTime.UtcNow
            }, bookDto.AuthorIds);

            if (book is null)
            {
                return null;
            }

            return new BookDto
            {
                BookId = book.BookId,
                Title = book.Title,
                BookNumber = book.BookNumber,
                PublishedYear = book.PublishedYear,
                Authors = book.Authors.Select(a => new AuthorDto
                {
                    AuthorId = a.AuthorId,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    Address = a.Address
                }).ToList()
            };
        }
    }
}
