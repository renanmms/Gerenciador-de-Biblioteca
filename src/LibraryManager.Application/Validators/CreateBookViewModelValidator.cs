using FluentValidation;
using LibraryManager.Application.ViewModels;

namespace LibraryManager.Application.Validators
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