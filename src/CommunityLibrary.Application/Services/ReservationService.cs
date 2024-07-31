// src/CommunityLibrary.Application/Services/ReservationService.cs

using AutoMapper;
using CommunityLibrary.Application.DTOs;
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
        private readonly IMapper _mapper;

        public ReservationService(IRepository<Reservation> reservationRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }

        public async Task<ReservationDto> GetReservationByIdAsync(int id)
        {
            var reservation = await _reservationRepository.GetByIdAsync(id);
            return _mapper.Map<ReservationDto>(reservation);
        }

        public async Task<IEnumerable<ReservationDto>> GetAllReservationsAsync()
        {
            var reservations = await _reservationRepository.ListAllAsync();
            return _mapper.Map<IEnumerable<ReservationDto>>(reservations);
        }

        public async Task<ReservationDto> CreateReservationAsync(ReservationDto reservationDto)
        {
            var reservation = _mapper.Map<Reservation>(reservationDto);
            var createdReservation = await _reservationRepository.AddAsync(reservation);
            return _mapper.Map<ReservationDto>(createdReservation);
        }

        public async Task UpdateReservationAsync(ReservationDto reservationDto)
        {
            var reservation = _mapper.Map<Reservation>(reservationDto);
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