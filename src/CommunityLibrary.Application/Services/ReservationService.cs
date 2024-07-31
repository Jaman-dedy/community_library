using CommunityLibrary.Application.Interfaces;
using CommunityLibrary.Core.Entities;
using CommunityLibrary.Core.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommunityLibrary.Application.Services
{
    /// <summary>
    /// Implements the IReservationService interface to provide business logic for Reservation-related operations.
    /// This service acts as an intermediary between the API controllers and the repository,
    /// encapsulating the application's business rules for managing reservations.
    /// </summary>
    public class ReservationService : IReservationService
    {
        private readonly IRepository<Reservation> _reservationRepository;

        public ReservationService(IRepository<Reservation> reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<Reservation> GetReservationByIdAsync(int id)
        {
            return await _reservationRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Reservation>> GetAllReservationsAsync()
        {
            return await _reservationRepository.ListAllAsync();
        }

        public async Task<Reservation> AddReservationAsync(Reservation reservation)
        {
            return await _reservationRepository.AddAsync(reservation);
        }

        public async Task UpdateReservationAsync(Reservation reservation)
        {
            await _reservationRepository.UpdateAsync(reservation);
        }

        public async Task DeleteReservationAsync(int id)
        {
            var reservation = await _reservationRepository.GetByIdAsync(id);
            if (reservation != null)
            {
                await _reservationRepository.DeleteAsync(reservation);
            }
        }
    }
}