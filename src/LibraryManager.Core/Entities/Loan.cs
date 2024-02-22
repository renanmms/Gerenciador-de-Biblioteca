namespace LibraryManager.Core.Entities
{
    public class Loan
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public DateTime LoanDate { get; set; }
        public bool IsExpired => LoanDate < DateTime.Today;
    }
}