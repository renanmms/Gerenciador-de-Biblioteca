using System;
using LibraryManager.Application.Services.Interfaces;
using LibraryManager.Application.ViewModels;
using LibraryManager.Core.Entities;
using LibraryManager.Infrastructure.Persistence.UoW;
using LibraryManager.Infrastructure.Repositories.Interfaces;
using Mapster;

namespace LibraryManager.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int Create(UserViewModel user)
        {
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