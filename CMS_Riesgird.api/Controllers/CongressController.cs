using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CMS_Riesgird.api.Controllers;

[Route("api/v1/congresses")]
[ApiController]
public class CongressController : ControllerBase
{
    private readonly ICongressService _service;

    public CongressController(ICongressService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var congresses = await _service.GetAllCongresses();
        return Ok(new ApiResponse<IEnumerable<CongressResponseDto>>(congresses, true, "Lista de congresos."));
    }

    [HttpGet("public")]
    public async Task<IActionResult> GetPublic()
    {
        var congresses = await _service.GetPublicCongresses();
        return Ok(new ApiResponse<IEnumerable<CongressResponseDto>>(congresses, true, "Lista de congresos públicos."));
    }

    [HttpGet("year/{year}")]
    public async Task<IActionResult> GetByYear(int year)
    {
        if (year < 1900 || year > DateTime.UtcNow.Year + 10)
        {
            return BadRequest(new ApiResponse<object>(false, "El año proporcionado no es válido."));
        }
        var congresses = await _service.GetCongressesByYear(year);
        return Ok(new ApiResponse<IEnumerable<CongressResponseDto>>(congresses, true, $"Congresos del año {year}."));
    }

    [HttpGet("edition/{edition}")]
    public async Task<IActionResult> GetByEdition(int edition)
    {
        if (edition < 1)
        {
            return BadRequest(new ApiResponse<object>(false, "La edición debe ser mayor a 0."));
        }
        var congresses = await _service.GetCongressesByEdition(edition);
        return Ok(new ApiResponse<IEnumerable<CongressResponseDto>>(congresses, true, $"Congresos de la edición {edition}."));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var congress = await _service.GetCongressById(id);
        if (congress == null)
            return NotFound(new ApiResponse<object>(false, "Congreso no encontrado."));
        return Ok(new ApiResponse<CongressResponseDto>(congress, true, "Congreso encontrado."));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCongressDto dto)
    {
        if (dto == null || string.IsNullOrEmpty(dto.Name))
        {
            return BadRequest(new ApiResponse<object>(false, "El nombre del congreso es requerido."));
        }
        if (string.IsNullOrEmpty(dto.Location))
        {
            return BadRequest(new ApiResponse<object>(false, "La ubicación del congreso es requerida."));
        }
        if (string.IsNullOrEmpty(dto.Description))
        {
            return BadRequest(new ApiResponse<object>(false, "La descripción del congreso es requerida."));
        }
        if (dto.Year < 1900 || dto.Year > DateTime.UtcNow.Year + 10)
        {
            return BadRequest(new ApiResponse<object>(false, "El año proporcionado no es válido."));
        }
        if (dto.Edition < 1)
        {
            return BadRequest(new ApiResponse<object>(false, "La edición debe ser mayor a 0."));
        }
        try
        {
            var congressId = await _service.CreateCongress(dto);
            return Ok(new ApiResponse<object>(new { CongressId = congressId }, true, "Congreso creado correctamente."));
        }
        catch (Exception ex)
        {
            var errorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            return BadRequest(new ApiResponse<object>(false, errorMessage));
        }
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCongressDto dto)
    {
        if (dto == null || id != dto.Id)
        {
            return BadRequest(new ApiResponse<object>(false, "Id del congreso no coincide con el Id en el cuerpo de la solicitud."));
        }
        if (string.IsNullOrEmpty(dto.Name))
        {
            return BadRequest(new ApiResponse<object>(false, "El nombre del congreso es requerido."));
        }
        if (string.IsNullOrEmpty(dto.Location))
        {
            return BadRequest(new ApiResponse<object>(false, "La ubicación del congreso es requerida."));
        }
        if (string.IsNullOrEmpty(dto.Description))
        {
            return BadRequest(new ApiResponse<object>(false, "La descripción del congreso es requerida."));
        }
        try
        {
            await _service.UpdateCongress(id, dto);
            return Ok(new ApiResponse<object>(true, "Congreso actualizado correctamente."));
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
            await _service.DeleteCongress(id);
            return Ok(new ApiResponse<object>(true, "Congreso eliminado correctamente."));
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<object>(false, ex.Message));
        }
    }
}
