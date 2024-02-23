using LibraryManager.Application.ViewModels;

namespace LibraryManager.Application.Services.Interfaces
{
    public interface ILoanService
    {
        int Create(CreateLoanViewModel loan);
        IEnumerable<CreateLoanViewModel> GetLoansByBookId(int id);
        GetLoanViewModel GetLoanByUserIdAndBookId(int userId, int bookId);
        void Delete(int userId, int bookId);
    }
}