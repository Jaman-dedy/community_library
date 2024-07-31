using CommunityLibrary.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommunityLibrary.Application.Interfaces
{

    /// <summary>
    /// Defines the contract for the Reservation service in the Community Library system.
    /// This interface outlines the operations that can be performed on Reservation entities,
    /// serving as an abstraction layer between the API controllers and the data access layer.
    /// </summary>
    public interface IReservationService
    {
        Task<ReservationDto> GetReservationByIdAsync(int id);
        Task<IEnumerable<ReservationDto>> GetAllReservationsAsync();
        Task<ReservationDto> CreateReservationAsync(ReservationDto reservationDto);
        Task UpdateReservationAsync(ReservationDto reservationDto);
        Task DeleteReservationAsync(int id);
    }
}