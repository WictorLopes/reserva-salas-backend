using ReservaSalas.Api.Models;

public interface IReservationService
{
    Task<IEnumerable<Reservation>> GetAllAsync();
    Task<Reservation?> GetByIdAsync(Guid id);
    Task<Reservation> CreateAsync(Reservation entity);
    Task<Reservation> UpdateAsync(Guid id, ReservationUpdateDto dto);
    Task DeleteAsync(Guid id);
}
