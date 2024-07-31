using System;
using CommunityLibrary.Core.Enums;

namespace CommunityLibrary.Core.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public int BookId { get; set; }
        public Book? Book { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public ReservationStatus Status { get; set; }
    }
}