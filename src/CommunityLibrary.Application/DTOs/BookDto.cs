
namespace CommunityLibrary.Application.DTOs
{
   public class BookDto
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Author { get; set; }
    public required string ISBN { get; set; }
    public string? Description { get; set; }
    public int PublicationYear { get; set; }
    public required string Publisher { get; set; }
    public int CopiesAvailable { get; set; }
    public required string Genre { get; set; }
    public DateTime DateAdded { get; set; }
}
}