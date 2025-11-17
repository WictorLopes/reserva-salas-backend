namespace ReservaSalas.Api.Dtos;

public record LocationCreateDto(string Name);
public record LocationUpdateDto(string Name);
public record LocationResponseDto(int Id, string Name);
