using CommunityLibrary.Application.Interfaces;
using CommunityLibrary.Core.Entities;
using CommunityLibrary.Core.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommunityLibrary.Application.Services
{
    /// <summary>
    /// Implements the IReviewService interface to provide business logic for Review-related operations.
    /// This service acts as an intermediary between the API controllers and the repository,
    /// encapsulating the application's business rules for managing reviews.
    /// </summary>
    public class ReviewService : IReviewService
    {
        private readonly IRepository<Review> _reviewRepository;

        public ReviewService(IRepository<Review> reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<Review> GetReviewByIdAsync(int id)
        {
            return await _reviewRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Review>> GetAllReviewsAsync()
        {
            return await _reviewRepository.ListAllAsync();
        }

        public async Task<Review> AddReviewAsync(Review review)
        {
            return await _reviewRepository.AddAsync(review);
        }

        public async Task UpdateReviewAsync(Review review)
        {
            await _reviewRepository.UpdateAsync(review);
        }

        public async Task DeleteReviewAsync(int id)
        {
            var review = await _reviewRepository.GetByIdAsync(id);
            if (review != null)
            {
                await _reviewRepository.DeleteAsync(review);
            }
        }
    }
}