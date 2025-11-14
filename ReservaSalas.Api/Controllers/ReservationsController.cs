using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReservaSalas.Api.Models;


[ApiController]
[Route("api/[controller]")]
public class ReservationsController : ControllerBase
{
    private readonly IReservationService _service;
    private readonly IMapper _mapper;

    public ReservationsController(IReservationService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReservationResponseDto>>> GetAll()
    {
        var items = await _service.GetAllAsync();
        return Ok(_mapper.Map<IEnumerable<ReservationResponseDto>>(items));
    }

    [HttpPost]
    public async Task<ActionResult> Create(ReservationCreateDto dto)
    {
        var entity = _mapper.Map<Reservation>(dto);
        entity.CreatedAt = DateTimeOffset.UtcNow;

        var created = await _service.CreateAsync(entity);

        return CreatedAtAction(nameof(GetById), new { id = created.Id },
            _mapper.Map<ReservationResponseDto>(created));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(Guid id)
    {
        var item = await _service.GetByIdAsync(id);
        if (item == null) return NotFound();
        return Ok(_mapper.Map<ReservationResponseDto>(item));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(Guid id, ReservationUpdateDto dto)
    {
        var result = await _service.UpdateAsync(id, dto);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}
