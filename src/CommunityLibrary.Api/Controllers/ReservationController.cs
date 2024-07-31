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
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservationDto>>> GetAllReservations()
        {
            var reservations = await _reservationService.GetAllReservationsAsync();
            return Ok(reservations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReservationDto>> GetReservation(int id)
        {
            var reservation = await _reservationService.GetReservationByIdAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            return Ok(reservation);
        }

        [HttpPost]
        public async Task<ActionResult<ReservationDto>> CreateReservation(ReservationDto reservationDto)
        {
            var createdReservation = await _reservationService.CreateReservationAsync(reservationDto);
            return CreatedAtAction(nameof(GetReservation), new { id = createdReservation.Id }, createdReservation);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReservation(int id, ReservationDto reservationDto)
        {
            if (id != reservationDto.Id)
            {
                return BadRequest();
            }

            await _reservationService.UpdateReservationAsync(reservationDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            await _reservationService.DeleteReservationAsync(id);
            return NoContent();
        }

        [HttpPost("checkout")]
        public async Task<ActionResult<ReservationDto>> CheckoutBook(int userId, int bookId)
        {
            try
            {
                var reservation = await _reservationService.CheckoutBookAsync(userId, bookId);
                return CreatedAtAction(nameof(GetReservation), new { id = reservation.Id }, reservation);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{id}/return")]
        public async Task<ActionResult<ReservationDto>> ReturnBook(int id)
        {
            try
            {
                var reservation = await _reservationService.ReturnBookAsync(id);
                return Ok(reservation);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("overdue")]
        public async Task<ActionResult<IEnumerable<ReservationDto>>> GetOverdueReservations()
        {
            var reservations = await _reservationService.GetOverdueReservationsAsync();
            return Ok(reservations);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<ReservationDto>>> GetUserReservations(int userId)
        {
            var reservations = await _reservationService.GetUserReservationsAsync(userId);
            return Ok(reservations);
        }

        [HttpGet("book/{bookId}")]
        public async Task<ActionResult<IEnumerable<ReservationDto>>> GetBookReservations(int bookId)
        {
            var reservations = await _reservationService.GetBookReservationsAsync(bookId);
            return Ok(reservations);
        }

        [HttpPost("{id}/extend")]
        public async Task<IActionResult> ExtendReservation(int id, [FromBody] int daysToExtend)
        {
            try
            {
                await _reservationService.ExtendReservationAsync(id, daysToExtend);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}