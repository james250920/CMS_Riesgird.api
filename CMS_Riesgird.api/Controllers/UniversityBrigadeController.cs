using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CMS_Riesgird.api.Controllers;

[Route("api/v1/university-brigades")]
[ApiController]
public class UniversityBrigadeController : ControllerBase
{
    private readonly IUniversityBrigadeService _service;

    public UniversityBrigadeController(IUniversityBrigadeService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var brigades = await _service.GetAllUniversityBrigades();
        return Ok(new ApiResponse<IEnumerable<UniversityBrigadeResponseDto>>(brigades, true, "Lista de brigadas universitarias."));
    }

    [HttpGet("university/{universityId}")]
    public async Task<IActionResult> GetByUniversityId(Guid universityId)
    {
        var brigades = await _service.GetUniversityBrigadesByUniversityId(universityId);
        return Ok(new ApiResponse<IEnumerable<UniversityBrigadeResponseDto>>(brigades, true, "Lista de brigadas de la universidad."));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var brigade = await _service.GetUniversityBrigadeById(id);
        if (brigade == null)
            return NotFound(new ApiResponse<object>(false, "Brigada universitaria no encontrada."));
        return Ok(new ApiResponse<UniversityBrigadeResponseDto>(brigade, true, "Brigada universitaria encontrada."));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUniversityBrigadeDto dto)
    {
        if (dto == null || string.IsNullOrEmpty(dto.Name))
        {
            return BadRequest(new ApiResponse<object>(false, "El nombre de la brigada es requerido."));
        }
        if (dto.UniversityId == Guid.Empty)
        {
            return BadRequest(new ApiResponse<object>(false, "El ID de la universidad es requerido."));
        }
        try
        {
            var brigadeId = await _service.CreateUniversityBrigade(dto);
            return Ok(new ApiResponse<object>(new { BrigadeId = brigadeId }, true, "Brigada universitaria creada correctamente."));
        }
        catch (Exception ex)
        {
            var errorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            return BadRequest(new ApiResponse<object>(false, errorMessage));
        }
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateUniversityBrigadeDto dto)
    {
        if (dto == null || id != dto.Id)
        {
            return BadRequest(new ApiResponse<object>(false, "Id de la brigada no coincide con el Id en el cuerpo de la solicitud."));
        }
        if (string.IsNullOrEmpty(dto.Name))
        {
            return BadRequest(new ApiResponse<object>(false, "El nombre de la brigada es requerido."));
        }
        try
        {
            await _service.UpdateUniversityBrigade(id, dto);
            return Ok(new ApiResponse<object>(true, "Brigada universitaria actualizada correctamente."));
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
            await _service.DeleteUniversityBrigade(id);
            return Ok(new ApiResponse<object>(true, "Brigada universitaria eliminada correctamente."));
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<object>(false, ex.Message));
        }
    }
}
