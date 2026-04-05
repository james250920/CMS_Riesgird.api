using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CMS_Riesgird.api.Controllers;

[Route("api/v1/activities")]
[ApiController]
public class ActivityController : ControllerBase
{
    private readonly IActivityService _service;

    public ActivityController(IActivityService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var activities = await _service.GetAllActivities();
        return Ok(new ApiResponse<IEnumerable<ActivityResponseDto>>(activities, true, "Lista de actividades."));
    }

    [HttpGet("memory/{memoryId}")]
    public async Task<IActionResult> GetByMemoryId(Guid memoryId)
    {
        var activities = await _service.GetActivitiesByMemoryId(memoryId);
        return Ok(new ApiResponse<IEnumerable<ActivityResponseDto>>(activities, true, "Actividades de la memoria de gestión."));
    }

    [HttpGet("date-range")]
    public async Task<IActionResult> GetByDateRange([FromQuery] DateOnly startDate, [FromQuery] DateOnly endDate)
    {
        if (startDate > endDate)
        {
            return BadRequest(new ApiResponse<object>(false, "La fecha de inicio no puede ser mayor a la fecha de fin."));
        }
        try
        {
            var activities = await _service.GetActivitiesByDateRange(startDate, endDate);
            return Ok(new ApiResponse<IEnumerable<ActivityResponseDto>>(activities, true, $"Actividades del {startDate} al {endDate}."));
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
        var activities = await _service.GetActivitiesByLocation(location);
        return Ok(new ApiResponse<IEnumerable<ActivityResponseDto>>(activities, true, $"Actividades en: {location}."));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var activity = await _service.GetActivityById(id);
        if (activity == null)
            return NotFound(new ApiResponse<object>(false, "Actividad no encontrada."));
        return Ok(new ApiResponse<ActivityResponseDto>(activity, true, "Actividad encontrada."));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateActivityDto dto)
    {
        if (dto == null || string.IsNullOrEmpty(dto.Title))
        {
            return BadRequest(new ApiResponse<object>(false, "El título de la actividad es requerido."));
        }
        if (string.IsNullOrEmpty(dto.Description))
        {
            return BadRequest(new ApiResponse<object>(false, "La descripción de la actividad es requerida."));
        }
        if (dto.MemoryId == Guid.Empty)
        {
            return BadRequest(new ApiResponse<object>(false, "El ID de la memoria es requerido."));
        }
        try
        {
            var activityId = await _service.CreateActivity(dto);
            return Ok(new ApiResponse<object>(new { ActivityId = activityId }, true, "Actividad creada correctamente."));
        }
        catch (Exception ex)
        {
            var errorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            return BadRequest(new ApiResponse<object>(false, errorMessage));
        }
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateActivityDto dto)
    {
        if (dto == null || id != dto.Id)
        {
            return BadRequest(new ApiResponse<object>(false, "Id de la actividad no coincide."));
        }
        if (string.IsNullOrEmpty(dto.Title))
        {
            return BadRequest(new ApiResponse<object>(false, "El título de la actividad es requerido."));
        }
        if (string.IsNullOrEmpty(dto.Description))
        {
            return BadRequest(new ApiResponse<object>(false, "La descripción de la actividad es requerida."));
        }
        try
        {
            await _service.UpdateActivity(id, dto);
            return Ok(new ApiResponse<object>(true, "Actividad actualizada correctamente."));
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
            await _service.DeleteActivity(id);
            return Ok(new ApiResponse<object>(true, "Actividad eliminada correctamente."));
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<object>(false, ex.Message));
        }
    }
}
