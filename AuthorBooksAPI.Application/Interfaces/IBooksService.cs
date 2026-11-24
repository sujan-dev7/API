using AuthorBooksAPI.Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthorBooksAPI.Application.Interfaces
{
    public interface IBooksService
    {
        Task<List<BookDto>> GetAllAsync();
        Task<BookDto?> GetByIdAsync(int bookId);
        Task<BookDto?> CreateAsync(CreateBookDto bookDto);
    }
}
