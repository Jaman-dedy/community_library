using AutoMapper;
using CommunityLibrary.Application.DTOs;
using CommunityLibrary.Application.Interfaces;
using CommunityLibrary.Core.Entities;
using CommunityLibrary.Core.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommunityLibrary.Application.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IRepository<Review> _reviewRepository;
        private readonly IMapper _mapper;

        public ReviewService(IRepository<Review> reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        public async Task<ReviewDto> GetReviewByIdAsync(int id)
        {
            var review = await _reviewRepository.GetByIdAsync(id);
            return _mapper.Map<ReviewDto>(review);
        }

        public async Task<IEnumerable<ReviewDto>> GetAllReviewsAsync()
        {
            var reviews = await _reviewRepository.ListAllAsync();
            return _mapper.Map<IEnumerable<ReviewDto>>(reviews);
        }

        public async Task<ReviewDto> CreateReviewAsync(ReviewDto reviewDto)
        {
            var review = _mapper.Map<Review>(reviewDto);
            var createdReview = await _reviewRepository.AddAsync(review);
            return _mapper.Map<ReviewDto>(createdReview);
        }

        public async Task UpdateReviewAsync(ReviewDto reviewDto)
        {
            var review = _mapper.Map<Review>(reviewDto);
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