using CommunityLibrary.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommunityLibrary.Application.Interfaces
{
    /// <summary>
    /// Defines the contract for the Review service in the Community Library system.
    /// This interface outlines the operations that can be performed on Review entities,
    /// serving as an abstraction layer between the API controllers and the data access layer.
    /// </summary>
    public interface IReviewService
    {
        Task<Review> GetReviewByIdAsync(int id);
        Task<IEnumerable<Review>> GetAllReviewsAsync();
        Task<Review> AddReviewAsync(Review review);
        Task UpdateReviewAsync(Review review);
        Task DeleteReviewAsync(int id);
    }
}