using CommunityLibrary.Application.DTOs;
using CommunityLibrary.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommunityLibrary.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReviewDto>>> GetAllReviews()
        {
            var reviews = await _reviewService.GetAllReviewsAsync();
            return Ok(reviews);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewDto>> GetReview(int id)
        {
            var review = await _reviewService.GetReviewByIdAsync(id);
            if (review == null)
            {
                return NotFound();
            }
            return Ok(review);
        }

        [HttpPost]
        public async Task<ActionResult<ReviewDto>> CreateReview(ReviewDto reviewDto)
        {
            var createdReview = await _reviewService.CreateReviewAsync(reviewDto);
            return CreatedAtAction(nameof(GetReview), new { id = createdReview.Id }, createdReview);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReview(int id, ReviewDto reviewDto)
        {
            if (id != reviewDto.Id)
            {
                return BadRequest();
            }

            await _reviewService.UpdateReviewAsync(reviewDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            await _reviewService.DeleteReviewAsync(id);
            return NoContent();
        }
    }
}