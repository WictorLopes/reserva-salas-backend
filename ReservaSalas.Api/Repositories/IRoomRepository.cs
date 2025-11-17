using ReservaSalas.Api.Models;

namespace ReservaSalas.Api.Repositories;

public interface IRoomRepository
{
    Task<IEnumerable<Room>> GetAllAsync();
    Task<Room?> GetByIdAsync(int id);
    Task AddAsync(Room entity);
    void Update(Room entity);
    void Delete(Room entity);
    Task SaveAsync();
}
