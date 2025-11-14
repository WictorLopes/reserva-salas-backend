public record RoomCreateDto(string Name, Guid LocationId);
public record RoomUpdateDto(string Name, Guid LocationId);
public record RoomResponseDto(Guid Id, string Name, Guid LocationId);
