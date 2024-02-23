using System;
using LibraryManager.Core.Entities;
using LibraryManager.Infrastructure.Context;
using LibraryManager.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Infrastructure.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly LibraryContext _context;
        public LoanRepository(LibraryContext context)
        {
            _context = context;
        }

        public int Create(Loan loan)
        {
            _context.Loans.Add(loan);
            _context.SaveChanges();

            return loan.BookId;
        }

        public Loan GetByUserIdAndBookId(int userId, int bookId)
        {
            var loan = _context.Loans.SingleOrDefault(l => l.BookId == bookId && l.UserId == userId);
            return loan;
        }

        public IEnumerable<Loan> GetLoansByBookId(int id)
        {
            var userLoans = _context.Loans.Where(l => l.BookId == id);
            return userLoans;
        }

        public void Delete(int userId, int bookId)
        {
            _context.Loans
                    .Where(l => l.UserId == userId && l.BookId == bookId)
                    .ExecuteDelete();
        }
    }
}