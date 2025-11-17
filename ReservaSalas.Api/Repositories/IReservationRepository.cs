using ReservaSalas.Api.Models;

namespace ReservaSalas.Api.Repositories;

public interface IReservationRepository
{
    Task<IEnumerable<Reservation>> GetAllAsync();
    Task<Reservation?> GetByIdAsync(int id);
    Task AddAsync(Reservation entity);
    void Update(Reservation entity);
    void Delete(Reservation entity);
    Task SaveAsync();

    Task<bool> HasConflict(int roomId, DateTimeOffset start, DateTimeOffset end, int? reservationId = null);
}
