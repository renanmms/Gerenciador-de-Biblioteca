using System;
using LibraryManager.Application.Services.Interfaces;
using LibraryManager.Application.ViewModels;
using LibraryManager.Core.Entities;
using LibraryManager.Infrastructure.AuthServices;
using LibraryManager.Infrastructure.Persistence.UoW;
using LibraryManager.Infrastructure.Repositories.Interfaces;
using Mapster;

namespace LibraryManager.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthService _authService;
        public UserService(IUnitOfWork unitOfWork, IAuthService authService)
        {
            _unitOfWork = unitOfWork;
            _authService = authService;
        }

        public int Create(UserViewModel user)
        {
            var encryptedPassword = _authService.ComputeSha256Hash(user.Password);
            user.Password = encryptedPassword;
            var entityUser = user.Adapt<User>();

            return _unitOfWork.Users.Create(entityUser);
        }

        public UserViewModel GetById(int id)
        {
            return _unitOfWork.Users.GetById(id)
                        .Adapt<UserViewModel>();
        }
    }
}