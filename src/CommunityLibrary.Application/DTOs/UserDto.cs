using System;

namespace CommunityLibrary.Application.DTOs
{
    /// <summary>
    /// Data Transfer Object for User entity.
    /// This DTO is used to transfer user data between processes, hiding sensitive information like PasswordHash.
    /// </summary>
    public class UserDto
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public DateTime DateRegistered { get; set; }
        public bool IsActive { get; set; }
        public string? Role { get; set; }
    }
}