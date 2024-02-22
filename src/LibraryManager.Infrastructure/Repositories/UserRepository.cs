using LibraryManager.Core.Entities;
using LibraryManager.Infrastructure.Context;
using LibraryManager.Infrastructure.Repositories.Interfaces;

namespace LibraryManager.Infrastructure.Repositories
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