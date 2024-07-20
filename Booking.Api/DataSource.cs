using Booking.Domain.Models;
namespace Booking.Api;

public class DataSource
{
    public DataSource()
    {
        Hotels = GetHotels();
    }
    
    public List<Hotel> Hotels { get; set; }

    private List<Hotel> GetHotels()
    {
        return new List<Hotel>
        {
            new Hotel
            {
                HotelId = 1,
                Name = "Enerik",
                Stars = 3,
                Country = "Greece",
                City = "Thasos",
                Description = "Some nice description"
            },

            new Hotel
            {
                HotelId = 2,
                Name = "Kotsi",
                Stars = 4,
                Country = "Greece",
                City = "Kavala",
                Description = "Some nice description"
            }
        };
    }
}