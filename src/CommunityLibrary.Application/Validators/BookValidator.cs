
using CommunityLibrary.Core.Entities;
using FluentValidation;

namespace CommunityLibrary.Application.Validators
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(book => book.Title).NotEmpty().MaximumLength(200);
            RuleFor(book => book.Author).NotEmpty().MaximumLength(100);
            RuleFor(book => book.ISBN).NotEmpty().Matches(@"^\d{13}$").WithMessage("ISBN must be 13 digits");
            RuleFor(book => book.PublicationYear).InclusiveBetween(1000, System.DateTime.Now.Year);
            RuleFor(book => book.CopiesAvailable).GreaterThanOrEqualTo(0);
        }
    }
}