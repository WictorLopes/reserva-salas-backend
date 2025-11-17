namespace ReservaSalas.Api.Models;

public class Reservation
{
    public int Id { get; set; }

    public int RoomId { get; set; }
    public Room? Room { get; set; }

    public DateTimeOffset Start { get; set; }
    public DateTimeOffset End { get; set; }

    public string Responsible { get; set; } = string.Empty;

    public bool CoffeeRequested { get; set; }
    public int? CoffeeQuantity { get; set; }
    public string? CoffeeDescription { get; set; }

    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
}
