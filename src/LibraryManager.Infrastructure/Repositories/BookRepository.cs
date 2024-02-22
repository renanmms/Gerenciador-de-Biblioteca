using LibraryManager.Core.Entities;
using LibraryManager.Infrastructure.Context;
using LibraryManager.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext _context;

        public BookRepository(LibraryContext context)
        {
            _context = context;           
        }
        
        public int Create(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();

            return book.Id;
        }

        public int CreateLoan(Loan loan)
        {
            _context.Loans.Add(loan);
            _context.SaveChanges();

            return loan.BookId;
        }

        public int Delete(int id)
        {
            _context.Books
                .Where(b => b.Id == id)
                .ExecuteDelete();

            return id;
        }

        public IEnumerable<Book> GetAll(string query)
        {
            IQueryable<Book> books = _context.Books;

            if(!string.IsNullOrWhiteSpace(query)){
                books = books.Where(b => b.Title.Contains(query) || b.Author.Contains(query));
            }

            return books;
        }

        public Book GetById(int id)
        {
            var books = _context.Books;
            var book = books.SingleOrDefault(b => b.Id == id);

            return book;
        }

        public IEnumerable<Loan> GetLoansByBookId(int id)
        {
            var userLoans = _context.Loans.Where(l => l.BookId == id);
            return userLoans;
        }

        public Loan GetLoan(int userId, int bookId)
        {
            var loan = _context.Loans
                .SingleOrDefault(l => l.UserId == userId && l.BookId == bookId);

            return loan;
        }

        public void Return(int userId, int bookId)
        {
            _context.Loans
                .Where(l => l.UserId == userId && l.BookId == bookId)
                .ExecuteDelete();
        }
    }
}