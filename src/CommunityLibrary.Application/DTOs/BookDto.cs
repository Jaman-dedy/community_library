
namespace CommunityLibrary.Application.DTOs
{
    public class BookDto
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Author { get; set; }
        public required string ISBN { get; set; }
        public int PublicationYear { get; set; }
        public int CopiesAvailable { get; set; }
    }
}