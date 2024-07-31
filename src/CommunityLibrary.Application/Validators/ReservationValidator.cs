using CommunityLibrary.Core.Entities;
using FluentValidation;
using System;

namespace CommunityLibrary.Application.Validators
{
    /// <summary>
    /// Validator for the Reservation entity, defining validation rules for reservation properties.
    /// </summary>
    public class ReservationValidator : AbstractValidator<Reservation>
    {
        public ReservationValidator()
        {
            RuleFor(reservation => reservation.UserId)
                .GreaterThan(0).WithMessage("Invalid user ID.");

            RuleFor(reservation => reservation.BookId)
                .GreaterThan(0).WithMessage("Invalid book ID.");

            RuleFor(reservation => reservation.ReservationDate)
                .NotEmpty().WithMessage("Reservation date is required.")
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Reservation date cannot be in the future.");

            RuleFor(reservation => reservation.DueDate)
                .NotEmpty().WithMessage("Due date is required.")
                .GreaterThan(reservation => reservation.ReservationDate).WithMessage("Due date must be after the reservation date.");

            RuleFor(reservation => reservation.ReturnDate)
                .GreaterThanOrEqualTo(reservation => reservation.ReservationDate)
                .When(reservation => reservation.ReturnDate.HasValue)
                .WithMessage("Return date must be after or equal to the reservation date.");

            RuleFor(reservation => reservation.Status)
                .IsInEnum().WithMessage("Invalid reservation status.");
        }
    }
}