using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CMS_Riesgird.api.Controllers;

[Route("api/v1/forum-events")]
[ApiController]
public class ForumEventController : ControllerBase
{
    private readonly IForumEventService _service;

    public ForumEventController(IForumEventService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var forumEvents = await _service.GetAllForumEvents();
        return Ok(new ApiResponse<IEnumerable<ForumEventResponseDto>>(forumEvents, true, "Lista de eventos de foro."));
    }

    [HttpGet("public")]
    public async Task<IActionResult> GetPublic()
    {
        var forumEvents = await _service.GetPublicForumEvents();
        return Ok(new ApiResponse<IEnumerable<ForumEventResponseDto>>(forumEvents, true, "Lista de eventos de foro públicos."));
    }

    [HttpGet("upcoming")]
    public async Task<IActionResult> GetUpcoming()
    {
        var forumEvents = await _service.GetUpcomingForumEvents();
        return Ok(new ApiResponse<IEnumerable<ForumEventResponseDto>>(forumEvents, true, "Próximos eventos de foro."));
    }

    [HttpGet("month/{month}/{year}")]
    public async Task<IActionResult> GetByMonth(int month, int year)
    {
        if (month < 1 || month > 12)
        {
            return BadRequest(new ApiResponse<object>(false, "El mes debe estar entre 1 y 12."));
        }
        if (year < 1900 || year > DateTime.UtcNow.Year + 10)
        {
            return BadRequest(new ApiResponse<object>(false, "El año proporcionado no es válido."));
        }
        var forumEvents = await _service.GetForumEventsByMonth(month, year);
        return Ok(new ApiResponse<IEnumerable<ForumEventResponseDto>>(forumEvents, true, $"Eventos de foro de {month}/{year}."));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var forumEvent = await _service.GetForumEventById(id);
        if (forumEvent == null)
            return NotFound(new ApiResponse<object>(false, "Evento de foro no encontrado."));
        return Ok(new ApiResponse<ForumEventResponseDto>(forumEvent, true, "Evento de foro encontrado."));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateForumEventDto dto)
    {
        if (dto == null || string.IsNullOrEmpty(dto.Title))
        {
            return BadRequest(new ApiResponse<object>(false, "El título del evento es requerido."));
        }
        if (string.IsNullOrEmpty(dto.Description))
        {
            return BadRequest(new ApiResponse<object>(false, "La descripción del evento es requerida."));
        }
        if (dto.StartDate == default)
        {
            return BadRequest(new ApiResponse<object>(false, "La fecha de inicio es requerida."));
        }
        if (dto.EndDate.HasValue && dto.EndDate < dto.StartDate)
        {
            return BadRequest(new ApiResponse<object>(false, "La fecha de fin no puede ser anterior a la fecha de inicio."));
        }
        try
        {
            var forumEventId = await _service.CreateForumEvent(dto);
            return Ok(new ApiResponse<object>(new { ForumEventId = forumEventId }, true, "Evento de foro creado correctamente."));
        }
        catch (Exception ex)
        {
            var errorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            return BadRequest(new ApiResponse<object>(false, errorMessage));
        }
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateForumEventDto dto)
    {
        if (dto == null || id != dto.Id)
        {
            return BadRequest(new ApiResponse<object>(false, "Id del evento no coincide con el Id en el cuerpo de la solicitud."));
        }
        if (string.IsNullOrEmpty(dto.Title))
        {
            return BadRequest(new ApiResponse<object>(false, "El título del evento es requerido."));
        }
        if (string.IsNullOrEmpty(dto.Description))
        {
            return BadRequest(new ApiResponse<object>(false, "La descripción del evento es requerida."));
        }
        if (dto.EndDate.HasValue && dto.EndDate < dto.StartDate)
        {
            return BadRequest(new ApiResponse<object>(false, "La fecha de fin no puede ser anterior a la fecha de inicio."));
        }
        try
        {
            await _service.UpdateForumEvent(id, dto);
            return Ok(new ApiResponse<object>(true, "Evento de foro actualizado correctamente."));
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
            await _service.DeleteForumEvent(id);
            return Ok(new ApiResponse<object>(true, "Evento de foro eliminado correctamente."));
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<object>(false, ex.Message));
        }
    }
}
