using AutoMapper;
using CommunityLibrary.Application.DTOs;
using CommunityLibrary.Application.Interfaces;
using CommunityLibrary.Core.Entities;
using CommunityLibrary.Core.Interfaces.Repositories;
using CommunityLibrary.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityLibrary.Application.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IRepository<Reservation> _reservationRepository;
        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public ReservationService(
            IRepository<Reservation> reservationRepository,
            IRepository<Book> bookRepository,
            IRepository<User> userRepository,
            IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _bookRepository = bookRepository;
            _userRepository = userRepository;
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

        public async Task<ReservationDto> CheckoutBookAsync(int userId, int bookId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            var book = await _bookRepository.GetByIdAsync(bookId);

            if (user == null || book == null)
            {
                throw new ArgumentException("Invalid user or book ID");
            }

            if (book.CopiesAvailable <= 0)
            {
                throw new InvalidOperationException("No copies available for checkout");
            }

            var reservation = new Reservation
            {
                UserId = userId,
                BookId = bookId,
                ReservationDate = DateTime.UtcNow,
                DueDate = DateTime.UtcNow.AddDays(14), // 2 weeks loan period
                Status = ReservationStatus.Borrowed
            };

            book.CopiesAvailable--;
            await _bookRepository.UpdateAsync(book);

            var createdReservation = await _reservationRepository.AddAsync(reservation);
            return _mapper.Map<ReservationDto>(createdReservation);
        }

        public async Task<ReservationDto> ReturnBookAsync(int reservationId)
        {
            var reservation = await _reservationRepository.GetByIdAsync(reservationId);
            if (reservation == null)
            {
                throw new ArgumentException("Reservation not found", nameof(reservationId));
            }

            if (reservation.Status != ReservationStatus.Borrowed)
            {
                throw new InvalidOperationException("This reservation is not currently borrowed");
            }

            reservation.ReturnDate = DateTime.UtcNow;
            reservation.Status = ReservationStatus.Returned;

            var book = await _bookRepository.GetByIdAsync(reservation.BookId);
            book.CopiesAvailable++;

            await _bookRepository.UpdateAsync(book);
            await _reservationRepository.UpdateAsync(reservation);

            return _mapper.Map<ReservationDto>(reservation);
        }

        public async Task<IEnumerable<ReservationDto>> GetOverdueReservationsAsync()
        {
            var reservations = await _reservationRepository.ListAllAsync();
            var overdueReservations = reservations.Where(r => 
                r.Status == ReservationStatus.Borrowed && r.DueDate < DateTime.UtcNow);
            return _mapper.Map<IEnumerable<ReservationDto>>(overdueReservations);
        }

        public async Task<IEnumerable<ReservationDto>> GetUserReservationsAsync(int userId)
        {
            var reservations = await _reservationRepository.ListAllAsync();
            var userReservations = reservations.Where(r => r.UserId == userId);
            return _mapper.Map<IEnumerable<ReservationDto>>(userReservations);
        }

        public async Task<IEnumerable<ReservationDto>> GetBookReservationsAsync(int bookId)
        {
            var reservations = await _reservationRepository.ListAllAsync();
            var bookReservations = reservations.Where(r => r.BookId == bookId);
            return _mapper.Map<IEnumerable<ReservationDto>>(bookReservations);
        }

        public async Task ExtendReservationAsync(int reservationId, int daysToExtend)
        {
            var reservation = await _reservationRepository.GetByIdAsync(reservationId);
            if (reservation == null)
            {
                throw new ArgumentException("Reservation not found", nameof(reservationId));
            }

            if (reservation.Status != ReservationStatus.Borrowed)
            {
                throw new InvalidOperationException("Can only extend active borrowed reservations");
            }

            if (reservation.DueDate < DateTime.UtcNow)
            {
                throw new InvalidOperationException("Cannot extend overdue reservations");
            }

            reservation.DueDate = reservation.DueDate.AddDays(daysToExtend);
            await _reservationRepository.UpdateAsync(reservation);
        }
    }
}