using AuthorBooksAPI.Domain.Entities;
using AuthorBooksAPI.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AuthorBooksAPI.Infrastructure.Implementations
{
    public class BooksRepository : IBooksRepository
    {
        private readonly AuthorBooksAPIDbContext _authorBooksAPIDbContext;

        public BooksRepository(AuthorBooksAPIDbContext authorBooksAPIDbContext)
        {
            _authorBooksAPIDbContext = authorBooksAPIDbContext;
        }

        public Task<List<Book>> GetAllAsync()
        {
            return _authorBooksAPIDbContext.Books
                .Include(x => x.Authors)
                .Where(x => x.DeletedDate == null)
                .ToListAsync();
        }

        public Task<Book?> GetByIdAsync(int bookId)
        {
            return _authorBooksAPIDbContext.Books
                .Include(x => x.Authors)
                .Where(x => x.DeletedDate == null && x.BookId == bookId)
                .FirstOrDefaultAsync();
        }

        public async Task<Book?> AddAsync(Book book, List<int> authorIds)
        {
            var distinctAuthorIds = authorIds.Distinct().ToList();
            var authors = await _authorBooksAPIDbContext.Authors
                .Where(x => x.DeletedDate == null && distinctAuthorIds.Contains(x.AuthorId))
                .ToListAsync();

            if (authors.Count != distinctAuthorIds.Count)
            {
                return null;
            }

            book.Authors = authors;
            _authorBooksAPIDbContext.Books.Add(book);
            await _authorBooksAPIDbContext.SaveChangesAsync();
            return book;
        }
    }
}
