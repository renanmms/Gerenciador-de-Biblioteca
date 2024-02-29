using LibraryManager.Core.Entities;

namespace LibraryManager.Application.ViewModels
{
    public class UserViewModel
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
    }
}