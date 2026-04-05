using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CMS_Riesgird.api.Controllers;

[Route("api/v1/calendar-events")]
[ApiController]
public class CalendarEventController : ControllerBase
{
    private readonly ICalendarEventService _service;

    public CalendarEventController(ICalendarEventService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var events = await _service.GetAllEvents();
        return Ok(new ApiResponse<IEnumerable<CalendarEventResponseDto>>(events, true, "Lista de eventos del calendario."));
    }

    [HttpGet("public")]
    public async Task<IActionResult> GetPublic()
    {
        var events = await _service.GetPublicEvents();
        return Ok(new ApiResponse<IEnumerable<CalendarEventResponseDto>>(events, true, "Eventos públicos del calendario."));
    }

    [HttpGet("upcoming")]
    public async Task<IActionResult> GetUpcoming()
    {
        var events = await _service.GetUpcomingEvents();
        return Ok(new ApiResponse<IEnumerable<CalendarEventResponseDto>>(events, true, "Próximos eventos."));
    }

    [HttpGet("date-range")]
    public async Task<IActionResult> GetByDateRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
    {
        if (startDate > endDate)
        {
            return BadRequest(new ApiResponse<object>(false, "La fecha de inicio no puede ser mayor a la fecha de fin."));
        }
        try
        {
            var events = await _service.GetEventsByDateRange(startDate, endDate);
            return Ok(new ApiResponse<IEnumerable<CalendarEventResponseDto>>(events, true, $"Eventos del {startDate:yyyy-MM-dd} al {endDate:yyyy-MM-dd}."));
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<object>(false, ex.Message));
        }
    }

    [HttpGet("location/{location}")]
    public async Task<IActionResult> GetByLocation(string location)
    {
        if (string.IsNullOrWhiteSpace(location))
        {
            return BadRequest(new ApiResponse<object>(false, "La ubicación es requerida."));
        }
        var events = await _service.GetEventsByLocation(location);
        return Ok(new ApiResponse<IEnumerable<CalendarEventResponseDto>>(events, true, $"Eventos en: {location}."));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var calendarEvent = await _service.GetEventById(id);
        if (calendarEvent == null)
            return NotFound(new ApiResponse<object>(false, "Evento no encontrado."));
        return Ok(new ApiResponse<CalendarEventResponseDto>(calendarEvent, true, "Evento encontrado."));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCalendarEventDto dto)
    {
        if (dto == null || string.IsNullOrEmpty(dto.Title))
        {
            return BadRequest(new ApiResponse<object>(false, "El título del evento es requerido."));
        }
        if (dto.EndDate.HasValue && dto.StartDate > dto.EndDate)
        {
            return BadRequest(new ApiResponse<object>(false, "La fecha de inicio no puede ser mayor a la fecha de fin."));
        }
        try
        {
            var eventId = await _service.CreateEvent(dto);
            return Ok(new ApiResponse<object>(new { EventId = eventId }, true, "Evento creado correctamente."));
        }
        catch (Exception ex)
        {
            var errorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            return BadRequest(new ApiResponse<object>(false, errorMessage));
        }
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCalendarEventDto dto)
    {
        if (dto == null || id != dto.Id)
        {
            return BadRequest(new ApiResponse<object>(false, "Id del evento no coincide."));
        }
        if (string.IsNullOrEmpty(dto.Title))
        {
            return BadRequest(new ApiResponse<object>(false, "El título del evento es requerido."));
        }
        if (dto.EndDate.HasValue && dto.StartDate > dto.EndDate)
        {
            return BadRequest(new ApiResponse<object>(false, "La fecha de inicio no puede ser mayor a la fecha de fin."));
        }
        try
        {
            await _service.UpdateEvent(id, dto);
            return Ok(new ApiResponse<object>(true, "Evento actualizado correctamente."));
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<object>(false, ex.Message));
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            await _service.DeleteEvent(id);
            return Ok(new ApiResponse<object>(true, "Evento eliminado correctamente."));
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<object>(false, ex.Message));
        }
    }
}
