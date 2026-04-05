using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CMS_Riesgird.api.Controllers;

[Route("api/v1/speakers")]
[ApiController]
public class SpeakerController : ControllerBase
{
    private readonly ISpeakerService _service;

    public SpeakerController(ISpeakerService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var speakers = await _service.GetAllSpeakers();
        return Ok(new ApiResponse<IEnumerable<SpeakerResponseDto>>(speakers, true, "Lista de ponentes."));
    }

    [HttpGet("congress/{congressId}")]
    public async Task<IActionResult> GetByCongressId(Guid congressId)
    {
        var speakers = await _service.GetSpeakersByCongressId(congressId);
        return Ok(new ApiResponse<IEnumerable<SpeakerResponseDto>>(speakers, true, "Ponentes del congreso."));
    }

    [HttpGet("country/{country}")]
    public async Task<IActionResult> GetByCountry(string country)
    {
        if (string.IsNullOrWhiteSpace(country))
        {
            return BadRequest(new ApiResponse<object>(false, "El país es requerido."));
        }
        var speakers = await _service.GetSpeakersByCountry(country);
        return Ok(new ApiResponse<IEnumerable<SpeakerResponseDto>>(speakers, true, $"Ponentes de {country}."));
    }

    [HttpGet("institution/{institution}")]
    public async Task<IActionResult> GetByInstitution(string institution)
    {
        if (string.IsNullOrWhiteSpace(institution))
        {
            return BadRequest(new ApiResponse<object>(false, "La institución es requerida."));
        }
        var speakers = await _service.GetSpeakersByInstitution(institution);
        return Ok(new ApiResponse<IEnumerable<SpeakerResponseDto>>(speakers, true, $"Ponentes de {institution}."));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var speaker = await _service.GetSpeakerById(id);
        if (speaker == null)
            return NotFound(new ApiResponse<object>(false, "Ponente no encontrado."));
        return Ok(new ApiResponse<SpeakerResponseDto>(speaker, true, "Ponente encontrado."));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSpeakerDto dto)
    {
        if (dto == null || string.IsNullOrEmpty(dto.FullName))
        {
            return BadRequest(new ApiResponse<object>(false, "El nombre completo del ponente es requerido."));
        }
        if (string.IsNullOrEmpty(dto.Title))
        {
            return BadRequest(new ApiResponse<object>(false, "El título del ponente es requerido."));
        }
        if (string.IsNullOrEmpty(dto.Institution))
        {
            return BadRequest(new ApiResponse<object>(false, "La institución del ponente es requerida."));
        }
        if (string.IsNullOrEmpty(dto.Country))
        {
            return BadRequest(new ApiResponse<object>(false, "El país del ponente es requerido."));
        }
        if (dto.CongressId == Guid.Empty)
        {
            return BadRequest(new ApiResponse<object>(false, "El ID del congreso es requerido."));
        }
        try
        {
            var speakerId = await _service.CreateSpeaker(dto);
            return Ok(new ApiResponse<object>(new { SpeakerId = speakerId }, true, "Ponente creado correctamente."));
        }
        catch (Exception ex)
        {
            var errorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            return BadRequest(new ApiResponse<object>(false, errorMessage));
        }
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateSpeakerDto dto)
    {
        if (dto == null || id != dto.Id)
        {
            return BadRequest(new ApiResponse<object>(false, "Id del ponente no coincide con el Id en el cuerpo de la solicitud."));
        }
        if (string.IsNullOrEmpty(dto.FullName))
        {
            return BadRequest(new ApiResponse<object>(false, "El nombre completo del ponente es requerido."));
        }
        if (string.IsNullOrEmpty(dto.Title))
        {
            return BadRequest(new ApiResponse<object>(false, "El título del ponente es requerido."));
        }
        if (string.IsNullOrEmpty(dto.Institution))
        {
            return BadRequest(new ApiResponse<object>(false, "La institución del ponente es requerida."));
        }
        if (string.IsNullOrEmpty(dto.Country))
        {
            return BadRequest(new ApiResponse<object>(false, "El país del ponente es requerido."));
        }
        try
        {
            await _service.UpdateSpeaker(id, dto);
            return Ok(new ApiResponse<object>(true, "Ponente actualizado correctamente."));
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
            await _service.DeleteSpeaker(id);
            return Ok(new ApiResponse<object>(true, "Ponente eliminado correctamente."));
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<object>(false, ex.Message));
        }
    }
}
