using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CMS_Riesgird.api.Controllers;

[Route("api/v1/experts")]
[ApiController]
public class ExpertController : ControllerBase
{
    private readonly IExpertService _service;

    public ExpertController(IExpertService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var experts = await _service.GetAllExperts();
        return Ok(new ApiResponse<IEnumerable<ExpertResponseDto>>(experts, true, "Lista de expertos."));
    }

    [HttpGet("public")]
    public async Task<IActionResult> GetPublic()
    {
        var experts = await _service.GetPublicExperts();
        return Ok(new ApiResponse<IEnumerable<ExpertResponseDto>>(experts, true, "Lista de expertos públicos."));
    }

    [HttpGet("active")]
    public async Task<IActionResult> GetActive()
    {
        var experts = await _service.GetActiveExperts();
        return Ok(new ApiResponse<IEnumerable<ExpertResponseDto>>(experts, true, "Expertos activos."));
    }

    [HttpGet("available")]
    public async Task<IActionResult> GetAvailable()
    {
        var experts = await _service.GetAvailableExperts();
        return Ok(new ApiResponse<IEnumerable<ExpertResponseDto>>(experts, true, "Expertos disponibles."));
    }

    [HttpGet("available-consulting")]
    public async Task<IActionResult> GetAvailableForConsulting()
    {
        var experts = await _service.GetExpertsAvailableForConsulting();
        return Ok(new ApiResponse<IEnumerable<ExpertResponseDto>>(experts, true, "Expertos disponibles para consultoría."));
    }

    [HttpGet("available-training")]
    public async Task<IActionResult> GetAvailableForTraining()
    {
        var experts = await _service.GetExpertsAvailableForTraining();
        return Ok(new ApiResponse<IEnumerable<ExpertResponseDto>>(experts, true, "Expertos disponibles para capacitación."));
    }

    [HttpGet("available-research")]
    public async Task<IActionResult> GetAvailableForResearch()
    {
        var experts = await _service.GetExpertsAvailableForResearch();
        return Ok(new ApiResponse<IEnumerable<ExpertResponseDto>>(experts, true, "Expertos disponibles para investigación."));
    }

    [HttpGet("expertise-area/{expertiseArea}")]
    public async Task<IActionResult> GetByExpertiseArea(string expertiseArea)
    {
        if (string.IsNullOrWhiteSpace(expertiseArea))
        {
            return BadRequest(new ApiResponse<object>(false, "El área de expertise es requerida."));
        }
        var experts = await _service.GetExpertsByExpertiseArea(expertiseArea);
        return Ok(new ApiResponse<IEnumerable<ExpertResponseDto>>(experts, true, $"Expertos en área: {expertiseArea}."));
    }

    [HttpGet("country/{country}")]
    public async Task<IActionResult> GetByCountry(string country)
    {
        if (string.IsNullOrWhiteSpace(country))
        {
            return BadRequest(new ApiResponse<object>(false, "El país es requerido."));
        }
        var experts = await _service.GetExpertsByCountry(country);
        return Ok(new ApiResponse<IEnumerable<ExpertResponseDto>>(experts, true, $"Expertos de {country}."));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var expert = await _service.GetExpertById(id);
        if (expert == null)
            return NotFound(new ApiResponse<object>(false, "Experto no encontrado."));
        return Ok(new ApiResponse<ExpertResponseDto>(expert, true, "Experto encontrado."));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateExpertDto dto)
    {
        if (dto == null || string.IsNullOrEmpty(dto.FullName))
        {
            return BadRequest(new ApiResponse<object>(false, "El nombre completo del experto es requerido."));
        }
        if (string.IsNullOrEmpty(dto.Email))
        {
            return BadRequest(new ApiResponse<object>(false, "El email del experto es requerido."));
        }
        if (string.IsNullOrEmpty(dto.Country))
        {
            return BadRequest(new ApiResponse<object>(false, "El país del experto es requerido."));
        }
        if (dto.ExpertiseAreas == null || dto.ExpertiseAreas.Count == 0)
        {
            return BadRequest(new ApiResponse<object>(false, "Al menos una área de expertise es requerida."));
        }
        try
        {
            var expertId = await _service.CreateExpert(dto);
            return Ok(new ApiResponse<object>(new { ExpertId = expertId }, true, "Experto creado correctamente."));
        }
        catch (Exception ex)
        {
            var errorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            return BadRequest(new ApiResponse<object>(false, errorMessage));
        }
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateExpertDto dto)
    {
        if (dto == null || id != dto.Id)
        {
            return BadRequest(new ApiResponse<object>(false, "Id del experto no coincide con el Id en el cuerpo de la solicitud."));
        }
        if (string.IsNullOrEmpty(dto.FullName))
        {
            return BadRequest(new ApiResponse<object>(false, "El nombre completo del experto es requerido."));
        }
        if (string.IsNullOrEmpty(dto.Email))
        {
            return BadRequest(new ApiResponse<object>(false, "El email del experto es requerido."));
        }
        if (string.IsNullOrEmpty(dto.Country))
        {
            return BadRequest(new ApiResponse<object>(false, "El país del experto es requerido."));
        }
        if (dto.ExpertiseAreas == null || dto.ExpertiseAreas.Count == 0)
        {
            return BadRequest(new ApiResponse<object>(false, "Al menos una área de expertise es requerida."));
        }
        try
        {
            await _service.UpdateExpert(id, dto);
            return Ok(new ApiResponse<object>(true, "Experto actualizado correctamente."));
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
            await _service.DeleteExpert(id);
            return Ok(new ApiResponse<object>(true, "Experto eliminado correctamente."));
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<object>(false, ex.Message));
        }
    }
}
