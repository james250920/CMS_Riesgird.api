using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CMS_Riesgird.api.Controllers;

[Route("api/v1/thematic-axes")]
[ApiController]
public class ThematicAxisController : ControllerBase
{
    private readonly IThematicAxisService _service;

    public ThematicAxisController(IThematicAxisService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var axes = await _service.GetAllAxes();
        return Ok(new ApiResponse<IEnumerable<ThematicAxisResponseDto>>(axes, true, "Lista de ejes temáticos."));
    }

    [HttpGet("congress/{congressId}")]
    public async Task<IActionResult> GetByCongressId(Guid congressId)
    {
        var axes = await _service.GetAxesByCongressId(congressId);
        return Ok(new ApiResponse<IEnumerable<ThematicAxisResponseDto>>(axes, true, "Ejes temáticos del congreso."));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var axis = await _service.GetAxisById(id);
        if (axis == null)
            return NotFound(new ApiResponse<object>(false, "Eje temático no encontrado."));
        return Ok(new ApiResponse<ThematicAxisResponseDto>(axis, true, "Eje temático encontrado."));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateThematicAxisDto dto)
    {
        if (dto == null || string.IsNullOrEmpty(dto.Name))
        {
            return BadRequest(new ApiResponse<object>(false, "El nombre del eje temático es requerido."));
        }
        if (string.IsNullOrEmpty(dto.Description))
        {
            return BadRequest(new ApiResponse<object>(false, "La descripción del eje temático es requerida."));
        }
        if (dto.CongressId == Guid.Empty)
        {
            return BadRequest(new ApiResponse<object>(false, "El ID del congreso es requerido."));
        }
        try
        {
            var axisId = await _service.CreateAxis(dto);
            return Ok(new ApiResponse<object>(new { AxisId = axisId }, true, "Eje temático creado correctamente."));
        }
        catch (Exception ex)
        {
            var errorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            return BadRequest(new ApiResponse<object>(false, errorMessage));
        }
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateThematicAxisDto dto)
    {
        if (dto == null || id != dto.Id)
        {
            return BadRequest(new ApiResponse<object>(false, "Id del eje no coincide."));
        }
        if (string.IsNullOrEmpty(dto.Name))
        {
            return BadRequest(new ApiResponse<object>(false, "El nombre del eje temático es requerido."));
        }
        if (string.IsNullOrEmpty(dto.Description))
        {
            return BadRequest(new ApiResponse<object>(false, "La descripción del eje temático es requerida."));
        }
        try
        {
            await _service.UpdateAxis(id, dto);
            return Ok(new ApiResponse<object>(true, "Eje temático actualizado correctamente."));
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
            await _service.DeleteAxis(id);
            return Ok(new ApiResponse<object>(true, "Eje temático eliminado correctamente."));
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<object>(false, ex.Message));
        }
    }
}
