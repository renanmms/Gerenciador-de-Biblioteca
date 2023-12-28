using LibraryManager.API.Models;
using LibraryManager.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }

        [HttpPost("create")]
        public IActionResult Post(Book book)
        {
            try{
                var id = _bookRepository.Create(book);
                return Ok();

            }catch(Exception ex){
                return BadRequest();
            }
            
        }
    }
}