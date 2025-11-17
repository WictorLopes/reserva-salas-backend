using Microsoft.EntityFrameworkCore;
using ReservaSalas.Api.Data;
using ReservaSalas.Api.Models;

namespace ReservaSalas.Api.Repositories;

public class ReservationRepository : IReservationRepository
{
    private readonly AppDbContext _context;

    public ReservationRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Reservation>> GetAllAsync() =>
        await _context.Reservations
        .Include(r => r.Room)
        .ThenInclude(r => r.Location)
        .ToListAsync();

    public async Task<Reservation?> GetByIdAsync(int id) =>
        await _context.Reservations.FindAsync(id);

    public async Task AddAsync(Reservation entity) =>
        await _context.Reservations.AddAsync(entity);

    public void Update(Reservation entity) =>
        _context.Reservations.Update(entity);

    public void Delete(Reservation entity) =>
        _context.Reservations.Remove(entity);

    public async Task SaveAsync() =>
        await _context.SaveChangesAsync();

    public async Task<bool> HasConflict(int roomId, DateTimeOffset start, DateTimeOffset end, int? reservationId = null)
    {
        return await _context.Reservations
            .AnyAsync(r => r.RoomId == roomId &&
                           (reservationId == null || r.Id != reservationId) &&
                           r.Start < end && start < r.End);
    }
}
