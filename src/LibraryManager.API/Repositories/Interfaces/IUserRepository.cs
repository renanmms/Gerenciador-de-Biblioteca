using LibraryManager.API.Models;

namespace LibraryManager.API.Repositories.Interfaces
{
    public interface IUserRepository
    {
        int Create(User user);
        User GetById(int id);
    }
}