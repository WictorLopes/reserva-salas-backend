using ReservaSalas.Api.Dtos;

namespace ReservaSalas.Api.Services;

public interface IRoomService
{
    Task<IEnumerable<RoomResponseDto>> GetAllAsync();
    Task<RoomResponseDto?> GetByIdAsync(int id);
    Task<RoomResponseDto> CreateAsync(RoomCreateDto dto);
    Task<RoomResponseDto> UpdateAsync(int id, RoomUpdateDto dto);
    Task DeleteAsync(int id);
}
