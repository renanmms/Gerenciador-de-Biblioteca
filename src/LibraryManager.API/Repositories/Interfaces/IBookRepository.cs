using LibraryManager.API.Models;

namespace LibraryManager.API.Repositories.Interfaces
{
    public interface IBookRepository
    {
        int Create(Book book);
        int CreateLoan(Loan loan);
        IEnumerable<Loan> GetLoansByBookId(int id);
        Book GetById(int id);
        IEnumerable<Book> GetAll(string query);
        int Delete(int id);
    }
}