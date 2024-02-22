using LibraryManager.Core.Entities;

namespace LibraryManager.Application.ViewModels
{
    public class CreateLoanViewModel
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
        public DateTime LoanDate { get; set; }

        public static Loan ToEntity(CreateLoanViewModel loan)
        {
            return new Loan {
                UserId = loan.UserId,
                BookId = loan.BookId,
                LoanDate = loan.LoanDate
            };
        }
    }
}