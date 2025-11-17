namespace ReservaSalas.Api.Dtos;

public record RoomCreateDto(string Name, int LocationId, int Capacity);
public record RoomUpdateDto(string Name, int LocationId, int Capacity);
public record RoomResponseDto(int Id, string Name, int LocationId, int Capacity);
