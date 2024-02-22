using LibraryManager.Core.Entities;

namespace LibraryManager.API.ViewModels
{
    public class CreateBookViewModel
    {
        public int UserId { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? ISBN { get; set; }
        public int PublishYear { get; set; }

        public static Book ToEntity(CreateBookViewModel model)
        {
            return new Book {
                UserId = model.UserId,
                Title = model.Title,
                Author = model.Author,
                ISBN = model.ISBN,
                PublishYear = model.PublishYear           
            };
        }
    }
}