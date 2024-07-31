using System;
using CommunityLibrary.Core.Enums;


namespace CommunityLibrary.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public DateTime DateRegistered { get; set; }
        public bool IsActive { get; set; }
         public UserRole Role { get; set; }
        public ICollection<Reservation>? Reservations { get; set; }
        public ICollection<Review>? Reviews { get; set; }
    }
}