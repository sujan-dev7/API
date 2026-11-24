using AuthorBooksAPI.Domain.Entities;
using AuthorBooksAPI.Infrastructure.Interfaces;

namespace AuthorBooksAPI.Infrastructure.Implementations
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AuthorBooksAPIDbContext _authorBooksAPIDbContext;

        public AuthorRepository(AuthorBooksAPIDbContext authorBooksAPIDbContext)
        {
            _authorBooksAPIDbContext = authorBooksAPIDbContext;
        }

        public async Task<Author> AddAsync(Author author)
        {
            _authorBooksAPIDbContext.Authors.Add(author);
            await _authorBooksAPIDbContext.SaveChangesAsync();
            return author;
        }
    }
}
