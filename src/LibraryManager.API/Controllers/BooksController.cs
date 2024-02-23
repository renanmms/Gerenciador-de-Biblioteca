using LibraryManager.Application.Services.Interfaces;
using LibraryManager.Application.ViewModels;
using LibraryManager.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var book = _bookService.GetById(id);
            return Ok(book);
        }

        [HttpGet("get")]
        public IActionResult GetAll(string query = "")
        {
            var books = _bookService.GetAll(query);
            return Ok(books);
        }

        [HttpPost("create")]
        public IActionResult Post(CreateBookViewModel book)
        {
            try{
                var id = _bookService.Create(book);
                return Created(nameof(GetById), new {id = id});

            }catch(Exception ex){
                return BadRequest();
            }
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _bookService.Delete(id);
                return Ok("Book deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}