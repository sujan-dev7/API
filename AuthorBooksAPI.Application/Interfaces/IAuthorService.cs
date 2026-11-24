using AuthorBooksAPI.Application.DTO;

namespace AuthorBooksAPI.Application.Interfaces
{
    public interface IAuthorService
    {
        Task<AuthorDto> CreateAsync(CreateAuthorDto authorDto);
    }
}
