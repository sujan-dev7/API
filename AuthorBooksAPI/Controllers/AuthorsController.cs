using AuthorBooksAPI.Application.DTO;
using AuthorBooksAPI.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AuthorBooksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAuthorDto authorDto)
        {
            var author = await _authorService.CreateAsync(authorDto);
            return Created(string.Empty, author);
        }
    }
}