namespace ReservaSalas.Api.Models;

public class Room
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public Guid LocationId { get; set; }
    public Location? Location { get; set; }
    public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
