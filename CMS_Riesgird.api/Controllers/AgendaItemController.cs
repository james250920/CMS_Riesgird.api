using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CMS_Riesgird.api.Controllers;

[Route("api/v1/agenda-items")]
[ApiController]
public class AgendaItemController : ControllerBase
{
    private readonly IAgendaItemService _service;

    public AgendaItemController(IAgendaItemService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var items = await _service.GetAllItems();
        return Ok(new ApiResponse<IEnumerable<AgendaItemResponseDto>>(items, true, "Lista de puntos de agenda."));
    }

    [HttpGet("assembly/{assemblyId}")]
    public async Task<IActionResult> GetByAssemblyId(Guid assemblyId)
    {
        var items = await _service.GetItemsByAssemblyId(assemblyId);
        return Ok(new ApiResponse<IEnumerable<AgendaItemResponseDto>>(items, true, "Puntos de agenda de la asamblea."));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var item = await _service.GetItemById(id);
        if (item == null)
            return NotFound(new ApiResponse<object>(false, "Punto de agenda no encontrado."));
        return Ok(new ApiResponse<AgendaItemResponseDto>(item, true, "Punto de agenda encontrado."));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAgendaItemDto dto)
    {
        if (dto == null || string.IsNullOrEmpty(dto.Title))
        {
            return BadRequest(new ApiResponse<object>(false, "El título del punto es requerido."));
        }
        if (dto.AssemblyId == Guid.Empty)
        {
            return BadRequest(new ApiResponse<object>(false, "El ID de la asamblea es requerido."));
        }
        try
        {
            var itemId = await _service.CreateItem(dto);
            return Ok(new ApiResponse<object>(new { ItemId = itemId }, true, "Punto de agenda creado correctamente."));
        }
        catch (Exception ex)
        {
            var errorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            return BadRequest(new ApiResponse<object>(false, errorMessage));
        }
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateAgendaItemDto dto)
    {
        if (dto == null || id != dto.Id)
        {
            return BadRequest(new ApiResponse<object>(false, "Id del punto no coincide."));
        }
        if (string.IsNullOrEmpty(dto.Title))
        {
            return BadRequest(new ApiResponse<object>(false, "El título del punto es requerido."));
        }
        try
        {
            await _service.UpdateItem(id, dto);
            return Ok(new ApiResponse<object>(true, "Punto de agenda actualizado correctamente."));
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
            await _service.DeleteItem(id);
            return Ok(new ApiResponse<object>(true, "Punto de agenda eliminado correctamente."));
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<object>(false, ex.Message));
        }
    }
}
