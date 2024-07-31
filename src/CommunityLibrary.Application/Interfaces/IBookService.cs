/// <summary>
/// Defines the contract for the Book service in the Community Library system.
/// This interface outlines the operations that can be performed on Book entities,
/// serving as an abstraction layer between the API controllers and the data access layer.
/// </summary>

using CommunityLibrary.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommunityLibrary.Application.Interfaces
{
    public interface IBookService
    {
        Task<Book> GetBookByIdAsync(int id);
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book> AddBookAsync(Book book);
        Task UpdateBookAsync(Book book);
        Task DeleteBookAsync(int id);
    }
}