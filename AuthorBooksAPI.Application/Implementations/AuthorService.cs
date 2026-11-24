using AuthorBooksAPI.Application.DTO;
using AuthorBooksAPI.Application.Interfaces;
using AuthorBooksAPI.Domain.Entities;
using AuthorBooksAPI.Infrastructure.Interfaces;

namespace AuthorBooksAPI.Application.Implementations
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<AuthorDto> CreateAsync(CreateAuthorDto authorDto)
        {
            var author = await _authorRepository.AddAsync(new Author
            {
                FirstName = authorDto.FirstName,
                LastName = authorDto.LastName,
                Address = authorDto.Address,
                CreatedDate = DateTime.UtcNow
            });

            return new AuthorDto
            {
                AuthorId = author.AuthorId,
                FirstName = author.FirstName,
                LastName = author.LastName,
                Address = author.Address
            };
        }
    }
}
