using ReservaSalas.Api.Dtos;

namespace ReservaSalas.Api.Services;

public interface IReservationService
{
    Task<IEnumerable<ReservationResponseDto>> GetAllAsync();
    Task<ReservationResponseDto?> GetByIdAsync(int id);
    Task<ReservationResponseDto> CreateAsync(ReservationCreateDto dto);
    Task<ReservationResponseDto> UpdateAsync(int id, ReservationUpdateDto dto);
    Task DeleteAsync(int id);
}
