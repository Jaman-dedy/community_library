using CommunityLibrary.Core.Entities;
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
        Task<Reservation> GetReservationByIdAsync(int id);
        Task<IEnumerable<Reservation>> GetAllReservationsAsync();
        Task<Reservation> AddReservationAsync(Reservation reservation);
        Task UpdateReservationAsync(Reservation reservation);
        Task DeleteReservationAsync(int id);
    }
}