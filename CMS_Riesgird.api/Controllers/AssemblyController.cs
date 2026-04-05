using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CMS_Riesgird.api.Controllers;

[Route("api/v1/assemblies")]
[ApiController]
public class AssemblyController : ControllerBase
{
    private readonly IAssemblyService _service;

    public AssemblyController(IAssemblyService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var assemblies = await _service.GetAllAssemblies();
        return Ok(new ApiResponse<IEnumerable<AssemblyResponseDto>>(assemblies, true, "Lista de asambleas."));
    }

    [HttpGet("public")]
    public async Task<IActionResult> GetPublic()
    {
        var assemblies = await _service.GetPublicAssemblies();
        return Ok(new ApiResponse<IEnumerable<AssemblyResponseDto>>(assemblies, true, "Lista de asambleas públicas."));
    }

    [HttpGet("year/{year}")]
    public async Task<IActionResult> GetByYear(int year)
    {
        if (year < 1900 || year > DateTime.UtcNow.Year + 10)
        {
            return BadRequest(new ApiResponse<object>(false, "El año proporcionado no es válido."));
        }
        var assemblies = await _service.GetAssembliesByYear(year);
        return Ok(new ApiResponse<IEnumerable<AssemblyResponseDto>>(assemblies, true, $"Asambleas del año {year}."));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var assembly = await _service.GetAssemblyById(id);
        if (assembly == null)
            return NotFound(new ApiResponse<object>(false, "Asamblea no encontrada."));
        return Ok(new ApiResponse<AssemblyResponseDto>(assembly, true, "Asamblea encontrada."));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAssemblyDto dto)
    {
        if (dto == null || string.IsNullOrEmpty(dto.Title))
        {
            return BadRequest(new ApiResponse<object>(false, "El título de la asamblea es requerido."));
        }
        if (string.IsNullOrEmpty(dto.Location))
        {
            return BadRequest(new ApiResponse<object>(false, "La ubicación de la asamblea es requerida."));
        }
        if (dto.Year < 1900 || dto.Year > DateTime.UtcNow.Year + 10)
        {
            return BadRequest(new ApiResponse<object>(false, "El año proporcionado no es válido."));
        }
        try
        {
            var assemblyId = await _service.CreateAssembly(dto);
            return Ok(new ApiResponse<object>(new { AssemblyId = assemblyId }, true, "Asamblea creada correctamente."));
        }
        catch (Exception ex)
        {
            var errorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            return BadRequest(new ApiResponse<object>(false, errorMessage));
        }
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateAssemblyDto dto)
    {
        if (dto == null || id != dto.Id)
        {
            return BadRequest(new ApiResponse<object>(false, "Id de la asamblea no coincide con el Id en el cuerpo de la solicitud."));
        }
        if (string.IsNullOrEmpty(dto.Title))
        {
            return BadRequest(new ApiResponse<object>(false, "El título de la asamblea es requerido."));
        }
        if (string.IsNullOrEmpty(dto.Location))
        {
            return BadRequest(new ApiResponse<object>(false, "La ubicación de la asamblea es requerida."));
        }
        try
        {
            await _service.UpdateAssembly(id, dto);
            return Ok(new ApiResponse<object>(true, "Asamblea actualizada correctamente."));
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
            await _service.DeleteAssembly(id);
            return Ok(new ApiResponse<object>(true, "Asamblea eliminada correctamente."));
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<object>(false, ex.Message));
        }
    }
}
