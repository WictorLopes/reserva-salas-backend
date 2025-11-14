using ReservaSalas.Api.Models;

public interface IReservationRepository
{
    Task<IEnumerable<Reservation>> GetAllAsync();
    Task<Reservation?> GetByIdAsync(Guid id);
    Task AddAsync(Reservation entity);
    void Update(Reservation entity);
    void Delete(Reservation entity);
    Task SaveAsync();
    
    Task<bool> HasConflict(Guid roomId, DateTime start, DateTime end, Guid? ignoreId = null);
    Task<bool> HasConflict(Guid roomId, DateTimeOffset start, DateTimeOffset end, Guid id);
    Task<bool> HasConflict(Guid roomId, DateTimeOffset start, DateTimeOffset end);
}
