using ReservaSalas.Api.Dtos;

namespace ReservaSalas.Api.Services;

public interface ILocationService
{
    Task<IEnumerable<LocationResponseDto>> GetAllAsync();
    Task<LocationResponseDto?> GetByIdAsync(int id);
    Task<LocationResponseDto> CreateAsync(LocationCreateDto dto);
    Task<LocationResponseDto> UpdateAsync(int id, LocationUpdateDto dto);
    Task DeleteAsync(int id);
}
