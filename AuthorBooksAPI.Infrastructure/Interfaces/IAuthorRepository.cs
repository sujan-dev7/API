using AuthorBooksAPI.Domain.Entities;

namespace AuthorBooksAPI.Infrastructure.Interfaces
{
    public interface IAuthorRepository
    {
        Task<Author> AddAsync(Author author);
    }
}
