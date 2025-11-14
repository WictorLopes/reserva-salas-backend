public record ReservationCreateDto(
    Guid LocationId,
    Guid RoomId,
    DateTimeOffset Start,
    DateTimeOffset End,
    string Responsible,
    bool CoffeeRequested,
    int? CoffeeQuantity,
    string? CoffeeDescription
);

public record ReservationUpdateDto(
    DateTimeOffset Start,
    DateTimeOffset End,
    string Responsible,
    bool CoffeeRequested,
    int? CoffeeQuantity,
    string? CoffeeDescription
);

public record ReservationResponseDto(
    Guid Id,
    Guid LocationId,
    Guid RoomId,
    DateTimeOffset Start,
    DateTimeOffset End,
    string Responsible,
    bool CoffeeRequested,
    int? CoffeeQuantity,
    string? CoffeeDescription,
    DateTimeOffset CreatedAt
);
