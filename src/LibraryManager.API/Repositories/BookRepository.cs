using LibraryManager.API.Context;
using LibraryManager.API.Models;
using LibraryManager.API.Repositories.Interfaces;

namespace LibraryManager.API.Repositories
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
    }
}