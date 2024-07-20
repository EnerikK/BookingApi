using Booking.Domain.Models;

namespace Booking.Domain.Abstraction.Services;

public interface IReservationService
{
    Task<Reservation> MakeReservationAsync(Reservation reservation);
    Task<List<Reservation>> GetAllReservationsAsync();
    Task<Reservation> GetReservationByIdAsync(int id);
    Task<Reservation> DeleteReservationAsync(int id);
}