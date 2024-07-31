using CommunityLibrary.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommunityLibrary.Application.Interfaces
{
    public interface IReservationService
    {
        Task<ReservationDto> GetReservationByIdAsync(int id);
        Task<IEnumerable<ReservationDto>> GetAllReservationsAsync();
        Task<ReservationDto> CreateReservationAsync(ReservationDto reservationDto);
        Task UpdateReservationAsync(ReservationDto reservationDto);
        Task DeleteReservationAsync(int id);
        Task<ReservationDto> CheckoutBookAsync(int userId, int bookId);
        Task<ReservationDto> ReturnBookAsync(int reservationId);
        Task<IEnumerable<ReservationDto>> GetOverdueReservationsAsync();
        Task<IEnumerable<ReservationDto>> GetUserReservationsAsync(int userId);
        Task<IEnumerable<ReservationDto>> GetBookReservationsAsync(int bookId);
        Task ExtendReservationAsync(int reservationId, int daysToExtend);
    }
}