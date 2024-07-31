using System;

namespace CommunityLibrary.Application.DTOs
{
    /// <summary>
    /// Data Transfer Object for Review entity.
    /// This DTO is used to transfer review data between processes.
    /// </summary>
    public class ReviewDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime ReviewDate { get; set; }

        public required string UserName { get; set; }
        public required string BookTitle { get; set; }
    }
}