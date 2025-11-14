using ReservaSalas.Api.Models;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Location, LocationResponseDto>();
        CreateMap<LocationCreateDto, Location>();
        CreateMap<LocationUpdateDto, Location>();

        CreateMap<Room, RoomResponseDto>();
        CreateMap<RoomCreateDto, Room>();
        CreateMap<RoomUpdateDto, Room>();

        CreateMap<Reservation, ReservationResponseDto>();
        CreateMap<ReservationCreateDto, Reservation>();
        CreateMap<ReservationUpdateDto, Reservation>();
    }

    private void CreateMap<T1, T2>()
    {
        throw new NotImplementedException();
    }
}

public class Profile
{
}