using CommunityLibrary.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommunityLibrary.Application.Interfaces
{
    public interface IReviewService
    {
        Task<ReviewDto> GetReviewByIdAsync(int id);
        Task<IEnumerable<ReviewDto>> GetAllReviewsAsync();
        Task<ReviewDto> CreateReviewAsync(ReviewDto reviewDto);
        Task UpdateReviewAsync(ReviewDto reviewDto);
        Task DeleteReviewAsync(int id);
    }
}