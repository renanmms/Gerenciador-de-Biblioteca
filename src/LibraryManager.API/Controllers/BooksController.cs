using LibraryManager.API.Models;
using LibraryManager.API.Repositories.Interfaces;
using LibraryManager.API.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
            var book = _bookRepository.GetById(id);
            return Ok(book);
        }

        [HttpPost("create")]
        public IActionResult Post(CreateBookViewModel book)
        {
            try{
                var id = _bookRepository.Create(CreateBookViewModel.ToEntity(book));
                return Created(nameof(GetById), new {id = id});

            }catch(Exception ex){
                return BadRequest();
            }
            
        }
    }
}