using AutoMapper;
using ReservaSalas.Api.Dtos;
using ReservaSalas.Api.Models;
using ReservaSalas.Api.Repositories;

namespace ReservaSalas.Api.Services;

public class RoomService : IRoomService
{
    private readonly IRoomRepository _repo;
    private readonly IMapper _mapper;

    public RoomService(IRoomRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<IEnumerable<RoomResponseDto>> GetAllAsync()
    {
        var list = await _repo.GetAllAsync();
        return _mapper.Map<IEnumerable<RoomResponseDto>>(list);
    }

    public async Task<RoomResponseDto?> GetByIdAsync(int id)
    {
        var room = await _repo.GetByIdAsync(id);
        return room == null ? null : _mapper.Map<RoomResponseDto>(room);
    }

    public async Task<RoomResponseDto> CreateAsync(RoomCreateDto dto)
    {
        var entity = _mapper.Map<Room>(dto);
        await _repo.AddAsync(entity);
        await _repo.SaveAsync();
        return _mapper.Map<RoomResponseDto>(entity);
    }

    public async Task<RoomResponseDto> UpdateAsync(int id, RoomUpdateDto dto)
    {
        var existing = await _repo.GetByIdAsync(id);
        if (existing == null) throw new Exception("Room não encontrada");

        _mapper.Map(dto, existing);
        _repo.Update(existing);
        await _repo.SaveAsync();
        return _mapper.Map<RoomResponseDto>(existing);
    }

    public async Task DeleteAsync(int id)
    {
        var existing = await _repo.GetByIdAsync(id);
        if (existing == null) throw new Exception("Room não encontrada");

        _repo.Delete(existing);
        await _repo.SaveAsync();
    }
}
