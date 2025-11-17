using AutoMapper;
using ReservaSalas.Api.Dtos;
using ReservaSalas.Api.Models;
using ReservaSalas.Api.Repositories;

namespace ReservaSalas.Api.Services;

public class LocationService : ILocationService
{
    private readonly ILocationRepository _repo;
    private readonly IMapper _mapper;

    public LocationService(ILocationRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<IEnumerable<LocationResponseDto>> GetAllAsync()
    {
        var list = await _repo.GetAllAsync();
        return _mapper.Map<IEnumerable<LocationResponseDto>>(list);
    }

    public async Task<LocationResponseDto?> GetByIdAsync(int id)
    {
        var location = await _repo.GetByIdAsync(id);
        return location == null ? null : _mapper.Map<LocationResponseDto>(location);
    }

    public async Task<LocationResponseDto> CreateAsync(LocationCreateDto dto)
    {
        var entity = _mapper.Map<Location>(dto);
        await _repo.AddAsync(entity);
        await _repo.SaveAsync();
        return _mapper.Map<LocationResponseDto>(entity);
    }

    public async Task<LocationResponseDto> UpdateAsync(int id, LocationUpdateDto dto)
    {
        var existing = await _repo.GetByIdAsync(id);
        if (existing == null) throw new Exception("Location não encontrada");

        _mapper.Map(dto, existing);
        _repo.Update(existing);
        await _repo.SaveAsync();
        return _mapper.Map<LocationResponseDto>(existing);
    }

    public async Task DeleteAsync(int id)
    {
        var existing = await _repo.GetByIdAsync(id);
        if (existing == null) throw new Exception("Location não encontrada");

        _repo.Delete(existing);
        await _repo.SaveAsync();
    }
}
