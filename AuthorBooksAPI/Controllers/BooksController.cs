using AuthorBooksAPI.Application.Interfaces;
using AuthorBooksAPI.Application.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthorBooksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;

        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await _booksService.GetAllAsync();
            return Ok(books);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBookDto bookDto)
        {
            var book = await _booksService.CreateAsync(bookDto);

            if (book is null)
            {
                return BadRequest("One or more author IDs do not exist.");
            }

            return CreatedAtAction(nameof(GetById), new { id = book.BookId }, book);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var book = await _booksService.GetByIdAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            return Ok(book);
        }
    }
}
