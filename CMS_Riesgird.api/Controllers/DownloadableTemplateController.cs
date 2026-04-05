using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CMS_Riesgird.api.Controllers;

[Route("api/v1/downloadable-templates")]
[ApiController]
public class DownloadableTemplateController : ControllerBase
{
    private readonly IDownloadableTemplateService _service;

    public DownloadableTemplateController(IDownloadableTemplateService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var templates = await _service.GetAllTemplates();
        return Ok(new ApiResponse<IEnumerable<DownloadableTemplateResponseDto>>(templates, true, "Lista de plantillas descargables."));
    }

    [HttpGet("active")]
    public async Task<IActionResult> GetActive()
    {
        var templates = await _service.GetActiveTemplates();
        return Ok(new ApiResponse<IEnumerable<DownloadableTemplateResponseDto>>(templates, true, "Plantillas activas."));
    }

    [HttpGet("version/{version}")]
    public async Task<IActionResult> GetByVersion(string version)
    {
        if (string.IsNullOrWhiteSpace(version))
        {
            return BadRequest(new ApiResponse<object>(false, "La versión es requerida."));
        }
        var templates = await _service.GetTemplatesByVersion(version);
        return Ok(new ApiResponse<IEnumerable<DownloadableTemplateResponseDto>>(templates, true, $"Plantillas de versión: {version}."));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var template = await _service.GetTemplateById(id);
        if (template == null)
            return NotFound(new ApiResponse<object>(false, "Plantilla no encontrada."));
        return Ok(new ApiResponse<DownloadableTemplateResponseDto>(template, true, "Plantilla encontrada."));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateDownloadableTemplateDto dto)
    {
        if (dto == null || string.IsNullOrEmpty(dto.Name))
        {
            return BadRequest(new ApiResponse<object>(false, "El nombre de la plantilla es requerido."));
        }
        try
        {
            var templateId = await _service.CreateTemplate(dto);
            return Ok(new ApiResponse<object>(new { TemplateId = templateId }, true, "Plantilla creada correctamente."));
        }
        catch (Exception ex)
        {
            var errorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            return BadRequest(new ApiResponse<object>(false, errorMessage));
        }
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateDownloadableTemplateDto dto)
    {
        if (dto == null || id != dto.Id)
        {
            return BadRequest(new ApiResponse<object>(false, "Id de la plantilla no coincide."));
        }
        if (string.IsNullOrEmpty(dto.Name))
        {
            return BadRequest(new ApiResponse<object>(false, "El nombre de la plantilla es requerido."));
        }
        try
        {
            await _service.UpdateTemplate(id, dto);
            return Ok(new ApiResponse<object>(true, "Plantilla actualizada correctamente."));
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
            await _service.DeleteTemplate(id);
            return Ok(new ApiResponse<object>(true, "Plantilla eliminada correctamente."));
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<object>(false, ex.Message));
        }
    }

    [HttpPost("{id}/download")]
    public async Task<IActionResult> RecordDownload(Guid id)
    {
        try
        {
            var template = await _service.GetTemplateById(id);
            if (template == null)
                return NotFound(new ApiResponse<object>(false, "Plantilla no encontrada."));

            await _service.RecordDownloadAsync(id);
            return Ok(new ApiResponse<object>(true, "Descarga registrada."));
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<object>(false, ex.Message));
        }
    }
}
