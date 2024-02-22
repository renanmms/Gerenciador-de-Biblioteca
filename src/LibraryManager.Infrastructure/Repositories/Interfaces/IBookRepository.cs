using LibraryManager.Core.Entities;

namespace LibraryManager.Infrastructure.Repositories.Interfaces
{
    public interface IBookRepository
    {
        int Create(Book book);
        int CreateLoan(Loan loan);
        IEnumerable<Loan> GetLoansByBookId(int id);
        Loan GetLoan(int userId, int bookId);
        void Return(int userId, int bookId);
        Book GetById(int id);
        IEnumerable<Book> GetAll(string query);
        int Delete(int id);
    }
}