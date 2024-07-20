using AutoMapper;
using Booking.Api.Dtos;
using Booking.Domain.Models;

namespace Booking.Api.AutoMapper
{
    public class ReservationMappingProfile : Profile
    {
        public ReservationMappingProfile()
        {
            CreateMap<ReservationPutPostDto, Reservation>();
            CreateMap<Reservation, ReservationGetDto>();
        }
    }
}
