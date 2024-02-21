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

        [HttpGet("get")]
        public IActionResult GetAll(string query = "")
        {
            var books = _bookRepository.GetAll(query);
            return Ok(books);
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

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _bookRepository.Delete(id);
                return Ok("Book deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("get/loans/{bookId}")]
        public IActionResult GetLoansByBookId(int bookId)
        {
            var loans = _bookRepository.GetLoansByBookId(bookId);
            return Ok(loans);
        }

        [HttpPost("create/loan")]
        public IActionResult CreateLoan(CreateLoanViewModel loan)
        {
            try
            {
                var bookId = _bookRepository.CreateLoan(CreateLoanViewModel.ToEntity(loan));
                return Created(nameof(GetLoansByBookId), new {id = bookId});
            }
            catch (Exception ex)
            {       
                throw;
            }
        }

        [HttpDelete("return")]
        public IActionResult Return(ReturnBookViewModel model)
        {
            try
            {
                var loan = _bookRepository.GetLoan(model.UserId, model.BookId);

                if(loan.IsExpired)
                {
                    return BadRequest("Loan is expired! Please contact the library to further details.");
                }

                _bookRepository.Return(model.UserId, model.BookId);
                return Ok("Book returned successfully");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}