using LibraryManager.Application.Services.Interfaces;
using LibraryManager.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoansController : ControllerBase
    {
        private readonly ILoanService _loanService;

        public LoansController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        [HttpGet("get/loans/{bookId}")]
        public IActionResult GetLoansByBookId(int bookId)
        {
            var loans = _loanService.GetLoansByBookId(bookId);
            return Ok(loans);
        }

        [HttpPost("create/loan")]
        public IActionResult CreateLoan(CreateLoanViewModel loan)
        {
            try
            {
                var bookId = _loanService.Create(loan);
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
                var loan = _loanService.GetLoanByUserIdAndBookId(model.UserId, model.BookId);

                if(loan.IsExpired)
                {
                    return BadRequest("Loan is expired! Please contact the library to further details.");
                }

                _loanService.Delete(model.UserId, model.BookId);
                return Ok("Book returned successfully");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}