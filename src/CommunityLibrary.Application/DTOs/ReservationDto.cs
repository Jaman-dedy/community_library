using System;
using CommunityLibrary.Core.Enums;

namespace CommunityLibrary.Application.DTOs
{
    /// <summary>
    /// Data Transfer Object for Reservation entity.
    /// This DTO is used to transfer reservation data between processes.
    /// </summary>
    public class ReservationDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public ReservationStatus Status { get; set; }

        public required string UserName { get; set; }
        public required string BookTitle { get; set; }
    }
}