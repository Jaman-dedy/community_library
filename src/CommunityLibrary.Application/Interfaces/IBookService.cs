/// <summary>
/// Defines the contract for the Book service in the Community Library system.
/// This interface outlines the operations that can be performed on Book entities,
/// serving as an abstraction layer between the API controllers and the data access layer.
/// </summary>

// src/CommunityLibrary.Application/Interfaces/IBookService.cs

using CommunityLibrary.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommunityLibrary.Application.Interfaces
{
    public interface IBookService
    {
        Task<BookDto> GetBookByIdAsync(int id);
        Task<IEnumerable<BookDto>> GetAllBooksAsync();
        Task<BookDto> AddBookAsync(BookDto bookDto);
        Task UpdateBookAsync(BookDto bookDto);
        Task DeleteBookAsync(int id);
        Task<IEnumerable<BookDto>> SearchBooksAsync(string searchTerm);
        Task<bool> IsBookAvailableAsync(int bookId);
        Task<BookDto> UpdateBookInventoryAsync(int bookId, int quantityChange);
        Task<IEnumerable<BookDto>> GetPopularBooksAsync(int count);
    }
}