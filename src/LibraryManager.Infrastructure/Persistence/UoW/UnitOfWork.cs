using LibraryManager.Infrastructure.Context;
using LibraryManager.Infrastructure.Repositories.Interfaces;

namespace LibraryManager.Infrastructure.Persistence.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryContext _context;
        public IBookRepository Books { get; }
        public IUserRepository Users { get; }
        public ILoanRepository Loans { get; }

        public UnitOfWork(
            LibraryContext context,
            IBookRepository books,
            IUserRepository users,
            ILoanRepository loans)
        {
            _context = context;
            Books = books;
            Users = users;
            Loans = loans;
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}