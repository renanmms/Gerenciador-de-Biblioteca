using LibraryManager.Infrastructure.Repositories.Interfaces;

namespace LibraryManager.Infrastructure.Persistence.UoW
{
    public interface IUnitOfWork
    {
        public IBookRepository Books { get; }
        public IUserRepository Users { get; }
        public ILoanRepository Loans { get; }
        int Complete();
    }
}