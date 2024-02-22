using LibraryManager.Core.Entities;

namespace LibraryManager.Application.ViewModels
{
    public class UserViewModel
    {
        public string? Name { get; set; }
        public string? Email { get; set; }

        public static User ToEntity(UserViewModel model)
        {
            return new User {
                Name = model.Name,
                Email = model.Email
            };
        }        
    }
}