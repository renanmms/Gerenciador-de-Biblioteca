using LibraryManager.Application.ViewModels;

namespace LibraryManager.Application.Services.Interfaces
{
    public interface IBookService
    {
        int Create(CreateBookViewModel book);
        GetBookViewModel GetById(int id);
        IEnumerable<GetBookViewModel> GetAll(string query);
        int Delete(int id);

    }
}