using Booking.DataAccess;
using Booking.Domain.Abstraction.Repositories;
using Booking.Domain.Abstraction.Services;
using Booking.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Booking.Services.Services;

public class ReservationService : IReservationService
{
    private readonly IHotelRepository _hotelRepository;
    private readonly DataContext _dataContext;

    public ReservationService(IHotelRepository hotelRepo, DataContext dataContext)
    {
        _hotelRepository = hotelRepo;
        _dataContext = dataContext;
    }
    
    public async Task<Reservation> MakeReservationAsync(Reservation reservation)
    {
        //Step 1: Get the hotel, including all rooms
        var hotel = await _hotelRepository.GetHotelByIdAsync(reservation.HotelId);

        //Step 2: Find the specified room
        var room = hotel.Rooms.Where(r => r.RoomId == reservation.RoomId).FirstOrDefault();

        if (hotel == null || room == null) return null;

        //Step 3: Make sure the room is available
        bool isBusy = await _dataContext.Reservations.AnyAsync(r =>
            (reservation.CheckInDate >= r.CheckInDate && reservation.CheckInDate <= r.CheckoutDate)
            && (reservation.CheckoutDate >= r.CheckInDate && reservation.CheckoutDate <= r.CheckoutDate)
        );


        if (isBusy) return null;

        if (room.NeedsRepair) return null;

        //Step 4: Persist all changes to the database
        _dataContext.Rooms.Update(room);
        _dataContext.Reservations.Add(reservation);

        await _dataContext.SaveChangesAsync();

        return reservation;
    }
    public async Task<List<Reservation>> GetAllReservationsAsync()
    {
        return await _dataContext.Reservations
            .Include(r => r.Hotel)
            .Include(r => r.Room)
            .ToListAsync();
    }
    public async Task<Reservation> GetReservationByIdAsync(int id)
    {
        return await _dataContext.Reservations
            .Include(r => r.Hotel)
            .Include(r => r.Room)
            .FirstOrDefaultAsync(r => r.ReservationId == id);
    }
    public async Task<Reservation> DeleteReservationAsync(int id)
    {
        var reservation = await _dataContext.Reservations.FirstOrDefaultAsync(r => r.ReservationId == id);

        if (reservation != null)
            _dataContext.Reservations.Remove(reservation);

        await _dataContext.SaveChangesAsync();

        return reservation;
    }
}
