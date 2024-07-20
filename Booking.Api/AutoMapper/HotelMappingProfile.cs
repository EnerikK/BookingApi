using AutoMapper;
using Booking.Api.Dtos;
using Booking.Domain.Models;

namespace Booking.Api.AutoMapper;

public class HotelMappingProfile : Profile
{
    public HotelMappingProfile()
    {
        CreateMap<HotelCreateDto, Hotel>();
        CreateMap<Hotel, HotelGetDto>();
    }
}