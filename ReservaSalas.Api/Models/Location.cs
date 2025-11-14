namespace ReservaSalas.Api.Models;

public class Location
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Room> Rooms { get; set; } = new List<Room>();

}
