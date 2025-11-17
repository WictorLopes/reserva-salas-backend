namespace ReservaSalas.Api.Mappings;
using AutoMapper;
using ReservaSalas.Api.Models;
using ReservaSalas.Api.Dtos;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // Locations
        CreateMap<Location, LocationResponseDto>();
        CreateMap<LocationCreateDto, Location>();
        CreateMap<LocationUpdateDto, Location>();

        // Rooms
        CreateMap<Room, RoomResponseDto>();
        CreateMap<RoomCreateDto, Room>();
        CreateMap<RoomUpdateDto, Room>();

        // Reservations
        CreateMap<Reservation, ReservationResponseDto>()
        .ForMember(dest => dest.RoomName, 
                opt => opt.MapFrom(src => src.Room != null ? src.Room.Name : null))
        .ForMember(dest => dest.LocationId,
                opt => opt.MapFrom(src => src.Room != null && src.Room.Location != null ? src.Room.Location.Id : 0))
        .ForMember(dest => dest.LocationName,
                opt => opt.MapFrom(src => src.Room != null && src.Room.Location != null ? src.Room.Location.Name : "-"));

        CreateMap<ReservationCreateDto, Reservation>();
        CreateMap<ReservationUpdateDto, Reservation>();
    }
}
