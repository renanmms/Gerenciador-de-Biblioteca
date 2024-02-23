using System;
using LibraryManager.Application.ViewModels;
using LibraryManager.Core.Entities;

namespace LibraryManager.Application.Services.Interfaces
{
    public interface IUserService
    {
        int Create(UserViewModel user);
        UserViewModel GetById(int id); 
    }
}