using LibraryManager.API.Context;
using LibraryManager.API.Models;
using LibraryManager.API.Repositories.Interfaces;

namespace LibraryManager.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LibraryContext _context;

        public UserRepository(LibraryContext context)
        {
            _context = context;
        }

        public int Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return user.Id;
        }

        public User GetById(int id)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == id);
            return user;
        }
    }
}