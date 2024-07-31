using CommunityLibrary.Core.Entities;
using FluentValidation;
using System;

namespace CommunityLibrary.Application.Validators
{
    /// <summary>
    /// Validator for the Review entity, defining validation rules for review properties.
    /// </summary>
    public class ReviewValidator : AbstractValidator<Review>
    {
        public ReviewValidator()
        {
            RuleFor(review => review.UserId)
                .GreaterThan(0).WithMessage("Invalid user ID.");

            RuleFor(review => review.BookId)
                .GreaterThan(0).WithMessage("Invalid book ID.");

            RuleFor(review => review.Rating)
                .InclusiveBetween(1, 5).WithMessage("Rating must be between 1 and 5.");

            RuleFor(review => review.Comment)
                .MaximumLength(1000).WithMessage("Comment must not exceed 1000 characters.");

            RuleFor(review => review.ReviewDate)
                .NotEmpty().WithMessage("Review date is required.")
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Review date cannot be in the future.");
        }
    }
}