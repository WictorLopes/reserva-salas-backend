namespace ReservaSalas.Api.Dtos;

public record ReservationCreateDto(
    int LocationId,
    int RoomId,
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

public class ReservationResponseDto
{
    public int Id { get; set; }
    public int LocationId { get; set; }
    public int RoomId { get; set; }
    public string RoomName { get; set; } = "-";
    public string LocationName { get; set; } = "-";
    public DateTimeOffset Start { get; set; }
    public DateTimeOffset End { get; set; }
    public string Responsible { get; set; } = "";
    public bool CoffeeRequested { get; set; }
    public int? CoffeeQuantity { get; set; }
    public string? CoffeeDescription { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
}
