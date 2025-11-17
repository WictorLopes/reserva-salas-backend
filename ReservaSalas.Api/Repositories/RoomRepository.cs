using Microsoft.EntityFrameworkCore;
using ReservaSalas.Api.Data;
using ReservaSalas.Api.Models;

namespace ReservaSalas.Api.Repositories;

public class RoomRepository : IRoomRepository
{
    private readonly AppDbContext _context;

    public RoomRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Room>> GetAllAsync() =>
        await _context.Rooms.ToListAsync();

    public async Task<Room?> GetByIdAsync(int id) =>
        await _context.Rooms.FindAsync(id);

    public async Task AddAsync(Room entity) =>
        await _context.Rooms.AddAsync(entity);

    public void Update(Room entity) =>
        _context.Rooms.Update(entity);

    public void Delete(Room entity) =>
        _context.Rooms.Remove(entity);

    public async Task SaveAsync() =>
        await _context.SaveChangesAsync();
}
