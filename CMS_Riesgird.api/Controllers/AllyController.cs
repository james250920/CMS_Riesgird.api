using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CMS_Riesgird.api.Controllers;

[Route("api/v1/allies")]
[ApiController]
public class AllyController : ControllerBase
{
    private readonly IAllyService _service;

    public AllyController(IAllyService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var allies = await _service.GetAllAllies();
        return Ok(new ApiResponse<IEnumerable<AllyResponseDto>>(allies, true, "Lista de aliados estratégicos."));
    }

    [HttpGet("public")]
    public async Task<IActionResult> GetPublic()
    {
        var allies = await _service.GetPublicAllies();
        return Ok(new ApiResponse<IEnumerable<AllyResponseDto>>(allies, true, "Aliados públicos."));
    }

    [HttpGet("active")]
    public async Task<IActionResult> GetActive()
    {
        var allies = await _service.GetActiveAllies();
        return Ok(new ApiResponse<IEnumerable<AllyResponseDto>>(allies, true, "Aliados activos."));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var ally = await _service.GetAllyById(id);
        if (ally == null)
            return NotFound(new ApiResponse<object>(false, "Aliado no encontrado."));
        return Ok(new ApiResponse<AllyResponseDto>(ally, true, "Aliado encontrado."));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAllyDto dto)
    {
        if (dto == null || string.IsNullOrEmpty(dto.Name))
        {
            return BadRequest(new ApiResponse<object>(false, "El nombre del aliado es requerido."));
        }
        if (string.IsNullOrEmpty(dto.LogoUrl))
        {
            return BadRequest(new ApiResponse<object>(false, "La URL del logo es requerida."));
        }
        try
        {
            var allyId = await _service.CreateAlly(dto);
            return Ok(new ApiResponse<object>(new { AllyId = allyId }, true, "Aliado creado correctamente."));
        }
        catch (Exception ex)
        {
            var errorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            return BadRequest(new ApiResponse<object>(false, errorMessage));
        }
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateAllyDto dto)
    {
        if (dto == null || id != dto.Id)
        {
            return BadRequest(new ApiResponse<object>(false, "Id del aliado no coincide."));
        }
        if (string.IsNullOrEmpty(dto.Name))
        {
            return BadRequest(new ApiResponse<object>(false, "El nombre del aliado es requerido."));
        }
        if (string.IsNullOrEmpty(dto.LogoUrl))
        {
            return BadRequest(new ApiResponse<object>(false, "La URL del logo es requerida."));
        }
        try
        {
            await _service.UpdateAlly(id, dto);
            return Ok(new ApiResponse<object>(true, "Aliado actualizado correctamente."));
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
            await _service.DeleteAlly(id);
            return Ok(new ApiResponse<object>(true, "Aliado eliminado correctamente."));
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<object>(false, ex.Message));
        }
    }
}
