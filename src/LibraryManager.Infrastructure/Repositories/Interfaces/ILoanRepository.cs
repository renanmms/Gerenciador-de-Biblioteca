using LibraryManager.Core.Entities;

namespace LibraryManager.Infrastructure.Repositories.Interfaces
{
    public interface ILoanRepository
    {
        int Create(Loan loan);
        IEnumerable<Loan> GetLoansByBookId(int id);
        Loan GetByUserIdAndBookId(int userId, int bookId);
        void Delete(int userId, int bookId);
    }
}