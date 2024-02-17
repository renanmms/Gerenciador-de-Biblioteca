using FluentValidation;
using LibraryManager.API.ViewModels;

namespace LibraryManager.API.Validators
{
    public class CreateBookViewModelValidator : AbstractValidator<CreateBookViewModel>
    {
        public CreateBookViewModelValidator()
        {
            RuleFor(b => b.Author)
                .NotNull()
                .NotEmpty()
                .WithMessage("Author name is required.");

            RuleFor(b => b.Title)
                .NotNull()
                .NotEmpty()
                .WithMessage("Book title is required.");

            RuleFor(b => b.UserId)
                .GreaterThan(0)
                .WithMessage("User id is required.");

            RuleFor(b => b.ISBN)
                .NotNull()
                .NotEmpty()
                .WithMessage("ISBN number is required.");
        }        
    }
}