using ReservaSalas.Api.Models;

namespace ReservaSalas.Api.Repositories;

public interface ILocationRepository
{
    Task<IEnumerable<Location>> GetAllAsync();
    Task<Location?> GetByIdAsync(int id);
    Task AddAsync(Location entity);
    void Update(Location entity);
    void Delete(Location entity);
    Task SaveAsync();
}
