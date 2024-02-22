using LibraryManager.Core.Entities;

namespace LibraryManager.Infrastructure.Repositories.Interfaces
{
    public interface IUserRepository
    {
        int Create(User user);
        User GetById(int id);
    }
}