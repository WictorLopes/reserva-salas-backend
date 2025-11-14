using Microsoft.EntityFrameworkCore;
using ReservaSalas.Api.Data;
using ReservaSalas.Api.Models;

public class ReservationRepository : IReservationRepository
{
    private readonly AppDbContext _context;

    public ReservationRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Reservation>> GetAllAsync()
    {
        return await _context.Reservations
            .Include(r => r.Location)
            .Include(r => r.Room)
            .ToListAsync();
    }

    public async Task<Reservation?> GetByIdAsync(Guid id)
    {
        return await _context.Reservations
            .Include(r => r.Location)
            .Include(r => r.Room)
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task AddAsync(Reservation entity)
    {
        await _context.Reservations.AddAsync(entity);
    }

    public void Update(Reservation entity)
    {
        _context.Reservations.Update(entity);
    }

    public void Delete(Reservation entity)
    {
        _context.Reservations.Remove(entity);
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<bool> HasConflict(Guid roomId, DateTime start, DateTime end, Guid? ignoreId = null)
    {
        return await _context.Reservations.AnyAsync(r =>
            r.RoomId == roomId &&
            (ignoreId == null || r.Id != ignoreId) &&
            (
                (start >= r.Start && start < r.End) ||
                (end > r.Start && end <= r.End) ||
                (start <= r.Start && end >= r.End)
            )
        );
    }

    public Task<bool> HasConflict(Guid roomId, DateTimeOffset start, DateTimeOffset end, Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> HasConflict(Guid roomId, DateTimeOffset start, DateTimeOffset end)
    {
        throw new NotImplementedException();
    }
}
