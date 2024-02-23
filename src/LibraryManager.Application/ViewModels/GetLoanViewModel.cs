namespace LibraryManager.Application.ViewModels
{
    public class GetLoanViewModel
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
        public DateTime LoanDate { get; set; }
        public bool IsExpired => LoanDate < DateTime.Today;
    }
}