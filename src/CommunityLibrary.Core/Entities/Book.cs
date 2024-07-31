using System;
using System.Collections.Generic;

namespace CommunityLibrary.Core.Entities
{
    public class Book
    {
        public int Id { get; set;}
        public required string Title { get; set; }
        public required string Author {get; set;}
        public required string ISBN {get; set;}
        public string? Description {get; set;}
        public int PublicationYear {get; set;}
        public required string Publisher {get; set;}
        public int CopiesAvailable {get; set;}
        public required string Genre {get; set;}
        public DateTime DateAdded {get; set;}
        public ICollection<Reservation>? Reservations {get; set;}
        public ICollection<Review>? Reviews {get; set;}
    }
}