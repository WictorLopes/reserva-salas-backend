using ReservaSalas.Api.Models;

public class ReservationService : IReservationService
{
    private readonly IReservationRepository _repo;

    public ReservationService(IReservationRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<Reservation>> GetAllAsync()
    {
        return await _repo.GetAllAsync();
    }

    public async Task<Reservation?> GetByIdAsync(Guid id)
    {
        return await _repo.GetByIdAsync(id);
    }

    public async Task<Reservation> CreateAsync(Reservation entity)
    {
        bool conflict = await _repo.HasConflict(entity.RoomId, entity.Start, entity.End);

        if (conflict)
            throw new Exception("Já existe uma reserva nesse horário para esta sala.");

        await _repo.AddAsync(entity);
        await _repo.SaveAsync();
        return entity;
    }

    public async Task<Reservation> UpdateAsync(Guid id, ReservationUpdateDto dto)
    {
        var existing = await _repo.GetByIdAsync(id);

        if (existing == null)
            throw new Exception("Reserva não encontrada.");

        // Atualiza os campos permitidos
        existing.Start = dto.Start;
        existing.End = dto.End;
        existing.Responsible = dto.Responsible;
        existing.CoffeeRequested = dto.CoffeeRequested;
        existing.CoffeeQuantity = dto.CoffeeQuantity;
        existing.CoffeeDescription = dto.CoffeeDescription;

        bool conflict = await _repo.HasConflict(existing.RoomId, dto.Start, dto.End, id);

        if (conflict)
            throw new Exception("Já existe uma reserva nesse horário para esta sala.");

        _repo.Update(existing);
        await _repo.SaveAsync();

        return existing;
    }

    public async Task DeleteAsync(Guid id)
    {
        var existing = await _repo.GetByIdAsync(id);

        if (existing == null)
            throw new Exception("Reserva não encontrada.");

        _repo.Delete(existing);
        await _repo.SaveAsync();
    }
}
