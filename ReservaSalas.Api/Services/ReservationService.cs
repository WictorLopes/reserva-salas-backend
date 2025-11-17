using AutoMapper;
using ReservaSalas.Api.Dtos;
using ReservaSalas.Api.Models;
using ReservaSalas.Api.Repositories;

namespace ReservaSalas.Api.Services;

public class ReservationService : IReservationService
{
    private readonly IReservationRepository _repo;
    private readonly IMapper _mapper;

    public ReservationService(IReservationRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ReservationResponseDto>> GetAllAsync()
    {
        var list = await _repo.GetAllAsync();
        return _mapper.Map<IEnumerable<ReservationResponseDto>>(list);
    }

    public async Task<ReservationResponseDto?> GetByIdAsync(int id)
    {
        var reservation = await _repo.GetByIdAsync(id);
        return reservation == null ? null : _mapper.Map<ReservationResponseDto>(reservation);
    }

    public async Task<ReservationResponseDto> CreateAsync(ReservationCreateDto dto)
    {
        var entity = _mapper.Map<Reservation>(dto);

        if (await _repo.HasConflict(entity.RoomId, entity.Start, entity.End))
            throw new Exception("Já existe uma reserva nesse horário para esta sala.");

        await _repo.AddAsync(entity);
        await _repo.SaveAsync();
        return _mapper.Map<ReservationResponseDto>(entity);
    }

    public async Task<ReservationResponseDto> UpdateAsync(int id, ReservationUpdateDto dto)
    {
        var existing = await _repo.GetByIdAsync(id);
        if (existing == null) throw new Exception("Reserva não encontrada.");

        _mapper.Map(dto, existing);

        if (await _repo.HasConflict(existing.RoomId, existing.Start, existing.End, id))
            throw new Exception("Já existe uma reserva nesse horário para esta sala.");

        _repo.Update(existing);
        await _repo.SaveAsync();
        return _mapper.Map<ReservationResponseDto>(existing);
    }

    public async Task DeleteAsync(int id)
    {
        var existing = await _repo.GetByIdAsync(id);
        if (existing == null) throw new Exception("Reserva não encontrada.");

        _repo.Delete(existing);
        await _repo.SaveAsync();
    }
}
