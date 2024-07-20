using AutoMapper;
using Booking.Api.Dtos;
using Booking.Domain.Models;

namespace Booking.Api.AutoMapper
{
    public class RoomMappingProfile : Profile
    {
        public RoomMappingProfile()
        {
            CreateMap<Room, RoomGetDto>();
            CreateMap<RoomPostPutDto, Room>();
        }
    }
}
