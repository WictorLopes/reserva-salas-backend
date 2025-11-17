using Microsoft.EntityFrameworkCore;
using ReservaSalas.Api.Data;
using ReservaSalas.Api.Models;

namespace ReservaSalas.Api.Repositories;

public class LocationRepository : ILocationRepository
{
    private readonly AppDbContext _context;

    public LocationRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Location>> GetAllAsync() =>
        await _context.Locations.ToListAsync();

    public async Task<Location?> GetByIdAsync(int id) =>
        await _context.Locations.FindAsync(id);

    public async Task AddAsync(Location entity) =>
        await _context.Locations.AddAsync(entity);

    public void Update(Location entity) =>
        _context.Locations.Update(entity);

    public void Delete(Location entity) =>
        _context.Locations.Remove(entity);

    public async Task SaveAsync() =>
        await _context.SaveChangesAsync();
}
