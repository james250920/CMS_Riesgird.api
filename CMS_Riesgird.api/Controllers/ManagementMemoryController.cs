using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CMS_Riesgird.api.Controllers;

[Route("api/v1/management-memories")]
[ApiController]
public class ManagementMemoryController : ControllerBase
{
    private readonly IManagementMemoryService _service;

    public ManagementMemoryController(IManagementMemoryService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var memories = await _service.GetAllMemories();
        return Ok(new ApiResponse<IEnumerable<ManagementMemoryResponseDto>>(memories, true, "Lista de memorias de gestión."));
    }

    [HttpGet("public")]
    public async Task<IActionResult> GetPublic()
    {
        var memories = await _service.GetPublicMemories();
        return Ok(new ApiResponse<IEnumerable<ManagementMemoryResponseDto>>(memories, true, "Memorias de gestión públicas."));
    }

    [HttpGet("latest")]
    public async Task<IActionResult> GetLatest()
    {
        var memory = await _service.GetLatestMemory();
        if (memory == null)
            return NotFound(new ApiResponse<object>(false, "No hay memorias de gestión disponibles."));
        return Ok(new ApiResponse<ManagementMemoryResponseDto>(memory, true, "Última memoria de gestión."));
    }

    [HttpGet("year/{year}")]
    public async Task<IActionResult> GetByYear(int year)
    {
        if (year < 1900 || year > DateTime.Now.Year + 10)
        {
            return BadRequest(new ApiResponse<object>(false, "El año debe ser válido."));
        }
        var memories = await _service.GetMemoriesByYear(year);
        return Ok(new ApiResponse<IEnumerable<ManagementMemoryResponseDto>>(memories, true, $"Memorias de gestión del año {year}."));
    }

    [HttpGet("period/{period}")]
    public async Task<IActionResult> GetByPeriod(string period)
    {
        if (string.IsNullOrWhiteSpace(period))
        {
            return BadRequest(new ApiResponse<object>(false, "El período es requerido."));
        }
        var memories = await _service.GetMemoriesByPeriod(period);
        return Ok(new ApiResponse<IEnumerable<ManagementMemoryResponseDto>>(memories, true, $"Memorias de gestión del período: {period}."));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var memory = await _service.GetMemoryById(id);
        if (memory == null)
            return NotFound(new ApiResponse<object>(false, "Memoria de gestión no encontrada."));
        return Ok(new ApiResponse<ManagementMemoryResponseDto>(memory, true, "Memoria de gestión encontrada."));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateManagementMemoryDto dto)
    {
        if (dto == null || string.IsNullOrEmpty(dto.Title))
        {
            return BadRequest(new ApiResponse<object>(false, "El título de la memoria es requerido."));
        }
        if (dto.Year < 1900 || dto.Year > DateTime.Now.Year + 10)
        {
            return BadRequest(new ApiResponse<object>(false, "El año debe ser válido."));
        }
        try
        {
            var memoryId = await _service.CreateMemory(dto);
            return Ok(new ApiResponse<object>(new { MemoryId = memoryId }, true, "Memoria de gestión creada correctamente."));
        }
        catch (Exception ex)
        {
            var errorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            return BadRequest(new ApiResponse<object>(false, errorMessage));
        }
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateManagementMemoryDto dto)
    {
        if (dto == null || id != dto.Id)
        {
            return BadRequest(new ApiResponse<object>(false, "Id de la memoria no coincide."));
        }
        if (string.IsNullOrEmpty(dto.Title))
        {
            return BadRequest(new ApiResponse<object>(false, "El título de la memoria es requerido."));
        }
        if (dto.Year < 1900 || dto.Year > DateTime.Now.Year + 10)
        {
            return BadRequest(new ApiResponse<object>(false, "El año debe ser válido."));
        }
        try
        {
            await _service.UpdateMemory(id, dto);
            return Ok(new ApiResponse<object>(true, "Memoria de gestión actualizada correctamente."));
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
            await _service.DeleteMemory(id);
            return Ok(new ApiResponse<object>(true, "Memoria de gestión eliminada correctamente."));
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<object>(false, ex.Message));
        }
    }
}
