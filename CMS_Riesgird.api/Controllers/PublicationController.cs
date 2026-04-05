using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CMS_Riesgird.api.Controllers;

[Route("api/v1/publications")]
[ApiController]
public class PublicationController : ControllerBase
{
    private readonly IPublicationService _service;

    public PublicationController(IPublicationService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var publications = await _service.GetAllPublications();
        return Ok(new ApiResponse<IEnumerable<PublicationResponseDto>>(publications, true, "Lista de publicaciones."));
    }

    [HttpGet("public")]
    public async Task<IActionResult> GetPublic()
    {
        var publications = await _service.GetPublicPublications();
        return Ok(new ApiResponse<IEnumerable<PublicationResponseDto>>(publications, true, "Lista de publicaciones públicas."));
    }

    [HttpGet("year/{year}")]
    public async Task<IActionResult> GetByYear(int year)
    {
        if (year < 1900 || year > DateTime.UtcNow.Year + 5)
        {
            return BadRequest(new ApiResponse<object>(false, "El año proporcionado no es válido."));
        }
        var publications = await _service.GetPublicationsByYear(year);
        return Ok(new ApiResponse<IEnumerable<PublicationResponseDto>>(publications, true, $"Publicaciones del año {year}."));
    }

    [HttpGet("journal/{journal}")]
    public async Task<IActionResult> GetByJournal(string journal)
    {
        if (string.IsNullOrWhiteSpace(journal))
        {
            return BadRequest(new ApiResponse<object>(false, "El nombre del journal es requerido."));
        }
        var publications = await _service.GetPublicationsByJournal(journal);
        return Ok(new ApiResponse<IEnumerable<PublicationResponseDto>>(publications, true, $"Publicaciones en {journal}."));
    }

    [HttpGet("keyword/{keyword}")]
    public async Task<IActionResult> GetByKeyword(string keyword)
    {
        if (string.IsNullOrWhiteSpace(keyword))
        {
            return BadRequest(new ApiResponse<object>(false, "La palabra clave es requerida."));
        }
        var publications = await _service.GetPublicationsByKeyword(keyword);
        return Ok(new ApiResponse<IEnumerable<PublicationResponseDto>>(publications, true, $"Publicaciones con palabra clave: {keyword}."));
    }

    [HttpGet("researcher/{researcherId}")]
    public async Task<IActionResult> GetByResearcherId(Guid researcherId)
    {
        var publications = await _service.GetPublicationsByResearcherId(researcherId);
        return Ok(new ApiResponse<IEnumerable<PublicationResponseDto>>(publications, true, "Publicaciones del investigador."));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var publication = await _service.GetPublicationById(id);
        if (publication == null)
            return NotFound(new ApiResponse<object>(false, "Publicación no encontrada."));
        return Ok(new ApiResponse<PublicationResponseDto>(publication, true, "Publicación encontrada."));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePublicationDto dto)
    {
        if (dto == null || string.IsNullOrEmpty(dto.Title))
        {
            return BadRequest(new ApiResponse<object>(false, "El título de la publicación es requerido."));
        }
        if (dto.Authors == null || dto.Authors.Count == 0)
        {
            return BadRequest(new ApiResponse<object>(false, "Al menos un autor es requerido."));
        }
        if (dto.Year < 1900 || dto.Year > DateTime.UtcNow.Year + 5)
        {
            return BadRequest(new ApiResponse<object>(false, "El año de la publicación no es válido."));
        }
        if (dto.ResearcherId == Guid.Empty)
        {
            return BadRequest(new ApiResponse<object>(false, "El ID del investigador es requerido."));
        }
        if (dto.Keywords == null || dto.Keywords.Count == 0)
        {
            return BadRequest(new ApiResponse<object>(false, "Al menos una palabra clave es requerida."));
        }
        try
        {
            var publicationId = await _service.CreatePublication(dto);
            return Ok(new ApiResponse<object>(new { PublicationId = publicationId }, true, "Publicación creada correctamente."));
        }
        catch (Exception ex)
        {
            var errorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            return BadRequest(new ApiResponse<object>(false, errorMessage));
        }
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdatePublicationDto dto)
    {
        if (dto == null || id != dto.Id)
        {
            return BadRequest(new ApiResponse<object>(false, "Id de la publicación no coincide con el Id en el cuerpo de la solicitud."));
        }
        if (string.IsNullOrEmpty(dto.Title))
        {
            return BadRequest(new ApiResponse<object>(false, "El título de la publicación es requerido."));
        }
        if (dto.Authors == null || dto.Authors.Count == 0)
        {
            return BadRequest(new ApiResponse<object>(false, "Al menos un autor es requerido."));
        }
        if (dto.Keywords == null || dto.Keywords.Count == 0)
        {
            return BadRequest(new ApiResponse<object>(false, "Al menos una palabra clave es requerida."));
        }
        try
        {
            await _service.UpdatePublication(id, dto);
            return Ok(new ApiResponse<object>(true, "Publicación actualizada correctamente."));
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
            await _service.DeletePublication(id);
            return Ok(new ApiResponse<object>(true, "Publicación eliminada correctamente."));
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<object>(false, ex.Message));
        }
    }
}
