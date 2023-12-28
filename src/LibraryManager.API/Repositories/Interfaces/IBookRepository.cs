using LibraryManager.API.Models;

namespace LibraryManager.API.Repositories.Interfaces
{
    public interface IBookRepository
    {
        int Create(Book book);
    }
}