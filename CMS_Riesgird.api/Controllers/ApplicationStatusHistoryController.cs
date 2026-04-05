using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CMS_Riesgird.api.Controllers;

[Route("api/v1/application-status-history")]
[ApiController]
public class ApplicationStatusHistoryController : ControllerBase
{
    private readonly IApplicationStatusHistoryService _service;

    public ApplicationStatusHistoryController(IApplicationStatusHistoryService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var histories = await _service.GetAllHistories();
        return Ok(new ApiResponse<IEnumerable<ApplicationStatusHistoryResponseDto>>(histories, true, "Lista de historial de estados."));
    }

    [HttpGet("application/{applicationId}")]
    public async Task<IActionResult> GetByApplicationId(Guid applicationId)
    {
        var histories = await _service.GetHistoriesByApplicationId(applicationId);
        return Ok(new ApiResponse<IEnumerable<ApplicationStatusHistoryResponseDto>>(histories, true, "Historial de la solicitud."));
    }

    [HttpGet("status/{status}")]
    public async Task<IActionResult> GetByStatus(string status)
    {
        if (string.IsNullOrWhiteSpace(status))
        {
            return BadRequest(new ApiResponse<object>(false, "El estado es requerido."));
        }
        var histories = await _service.GetHistoriesByStatus(status);
        return Ok(new ApiResponse<IEnumerable<ApplicationStatusHistoryResponseDto>>(histories, true, $"Historial de estado: {status}."));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var history = await _service.GetHistoryById(id);
        if (history == null)
            return NotFound(new ApiResponse<object>(false, "Historial no encontrado."));
        return Ok(new ApiResponse<ApplicationStatusHistoryResponseDto>(history, true, "Historial encontrado."));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateApplicationStatusHistoryDto dto)
    {
        if (dto == null || string.IsNullOrEmpty(dto.Status))
        {
            return BadRequest(new ApiResponse<object>(false, "El estado es requerido."));
        }
        if (dto.ApplicationId == Guid.Empty)
        {
            return BadRequest(new ApiResponse<object>(false, "El ID de la solicitud es requerido."));
        }
        try
        {
            var historyId = await _service.CreateHistory(dto);
            return Ok(new ApiResponse<object>(new { HistoryId = historyId }, true, "Historial creado correctamente."));
        }
        catch (Exception ex)
        {
            var errorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            return BadRequest(new ApiResponse<object>(false, errorMessage));
        }
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateApplicationStatusHistoryDto dto)
    {
        if (dto == null || id != dto.Id)
        {
            return BadRequest(new ApiResponse<object>(false, "Id del historial no coincide."));
        }
        if (string.IsNullOrEmpty(dto.Status))
        {
            return BadRequest(new ApiResponse<object>(false, "El estado es requerido."));
        }
        try
        {
            await _service.UpdateHistory(id, dto);
            return Ok(new ApiResponse<object>(true, "Historial actualizado correctamente."));
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
            await _service.DeleteHistory(id);
            return Ok(new ApiResponse<object>(true, "Historial eliminado correctamente."));
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<object>(false, ex.Message));
        }
    }
}
