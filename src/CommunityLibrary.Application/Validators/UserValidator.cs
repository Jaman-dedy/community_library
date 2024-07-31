using System;
using CommunityLibrary.Core.Entities;
using CommunityLibrary.Core.Enums;
using FluentValidation;

namespace CommunityLibrary.Application.Validators
{
    /// <summary>
    /// Validator for the User entity, defining validation rules for user properties.
    /// </summary>
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.Username)
                .NotEmpty().WithMessage("Username is required.")
                .Length(3, 50).WithMessage("Username must be between 3 and 50 characters.");

            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("A valid email address is required.");

            RuleFor(user => user.PasswordHash)
                .NotEmpty().WithMessage("Password is required.");

            RuleFor(user => user.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .MaximumLength(50).WithMessage("First name must not exceed 50 characters.");

            RuleFor(user => user.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .MaximumLength(50).WithMessage("Last name must not exceed 50 characters.");

            RuleFor(user => user.DateRegistered)
                .NotEmpty().WithMessage("Date registered is required.")
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Date registered cannot be in the future.");

            RuleFor(user => user.Role)
                .IsInEnum().WithMessage("Invalid role.");
        }
    }
}