using System;
using LibraryManager.Application.Services.Interfaces;
using LibraryManager.Application.ViewModels;
using LibraryManager.Core.Entities;
using LibraryManager.Infrastructure.Repositories.Interfaces;
using Mapster;

namespace LibraryManager.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public int Create(UserViewModel user)
        {
            var entityUser = user.Adapt<User>();
            return _userRepository.Create(entityUser);
        }

        public UserViewModel GetById(int id)
        {
            return _userRepository.GetById(id)
                        .Adapt<UserViewModel>();
        }
    }
}