using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CMS_Riesgird.api.Controllers;

[Route("api/v1/researchers")]
[ApiController]
public class ResearcherController : ControllerBase
{
    private readonly IResearcherService _service;

    public ResearcherController(IResearcherService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var researchers = await _service.GetAllResearchers();
        return Ok(new ApiResponse<IEnumerable<ResearcherResponseDto>>(researchers, true, "Lista de investigadores."));
    }

    [HttpGet("public")]
    public async Task<IActionResult> GetPublic()
    {
        var researchers = await _service.GetPublicResearchers();
        return Ok(new ApiResponse<IEnumerable<ResearcherResponseDto>>(researchers, true, "Lista de investigadores públicos."));
    }

    [HttpGet("active")]
    public async Task<IActionResult> GetActive()
    {
        var researchers = await _service.GetActiveResearchers();
        return Ok(new ApiResponse<IEnumerable<ResearcherResponseDto>>(researchers, true, "Investigadores activos."));
    }

    [HttpGet("research-area/{researchArea}")]
    public async Task<IActionResult> GetByResearchArea(string researchArea)
    {
        if (string.IsNullOrWhiteSpace(researchArea))
        {
            return BadRequest(new ApiResponse<object>(false, "El área de investigación es requerida."));
        }
        var researchers = await _service.GetResearchersByResearchArea(researchArea);
        return Ok(new ApiResponse<IEnumerable<ResearcherResponseDto>>(researchers, true, $"Investigadores del área: {researchArea}."));
    }

    [HttpGet("university/{universityId}")]
    public async Task<IActionResult> GetByUniversityId(Guid universityId)
    {
        var researchers = await _service.GetResearchersByUniversityId(universityId);
        return Ok(new ApiResponse<IEnumerable<ResearcherResponseDto>>(researchers, true, "Investigadores de la universidad."));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var researcher = await _service.GetResearcherById(id);
        if (researcher == null)
            return NotFound(new ApiResponse<object>(false, "Investigador no encontrado."));
        return Ok(new ApiResponse<ResearcherResponseDto>(researcher, true, "Investigador encontrado."));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateResearcherDto dto)
    {
        if (dto == null || string.IsNullOrEmpty(dto.FullName))
        {
            return BadRequest(new ApiResponse<object>(false, "El nombre completo del investigador es requerido."));
        }
        if (string.IsNullOrEmpty(dto.Email))
        {
            return BadRequest(new ApiResponse<object>(false, "El email del investigador es requerido."));
        }
        if (dto.UniversityId == Guid.Empty)
        {
            return BadRequest(new ApiResponse<object>(false, "El ID de la universidad es requerido."));
        }
        if (dto.ResearchAreas == null || dto.ResearchAreas.Count == 0)
        {
            return BadRequest(new ApiResponse<object>(false, "Al menos un área de investigación es requerida."));
        }
        try
        {
            var researcherId = await _service.CreateResearcher(dto);
            return Ok(new ApiResponse<object>(new { ResearcherId = researcherId }, true, "Investigador creado correctamente."));
        }
        catch (Exception ex)
        {
            var errorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            return BadRequest(new ApiResponse<object>(false, errorMessage));
        }
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateResearcherDto dto)
    {
        if (dto == null || id != dto.Id)
        {
            return BadRequest(new ApiResponse<object>(false, "Id del investigador no coincide con el Id en el cuerpo de la solicitud."));
        }
        if (string.IsNullOrEmpty(dto.FullName))
        {
            return BadRequest(new ApiResponse<object>(false, "El nombre completo del investigador es requerido."));
        }
        if (string.IsNullOrEmpty(dto.Email))
        {
            return BadRequest(new ApiResponse<object>(false, "El email del investigador es requerido."));
        }
        if (dto.ResearchAreas == null || dto.ResearchAreas.Count == 0)
        {
            return BadRequest(new ApiResponse<object>(false, "Al menos un área de investigación es requerida."));
        }
        try
        {
            await _service.UpdateResearcher(id, dto);
            return Ok(new ApiResponse<object>(true, "Investigador actualizado correctamente."));
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
            await _service.DeleteResearcher(id);
            return Ok(new ApiResponse<object>(true, "Investigador eliminado correctamente."));
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<object>(false, ex.Message));
        }
    }
}
