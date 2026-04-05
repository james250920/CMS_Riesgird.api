using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CMS_Riesgird.api.Controllers;

[Route("api/v1/specialization-programs")]
[ApiController]
public class SpecializationProgramController : ControllerBase
{
    private readonly ISpecializationProgramService _service;

    public SpecializationProgramController(ISpecializationProgramService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var programs = await _service.GetAllPrograms();
        return Ok(new ApiResponse<IEnumerable<SpecializationProgramResponseDto>>(programs, true, "Lista de programas de especialización."));
    }

    [HttpGet("public")]
    public async Task<IActionResult> GetPublic()
    {
        var programs = await _service.GetPublicPrograms();
        return Ok(new ApiResponse<IEnumerable<SpecializationProgramResponseDto>>(programs, true, "Lista de programas públicos."));
    }

    [HttpGet("open-enrollment")]
    public async Task<IActionResult> GetOpenEnrollment()
    {
        var programs = await _service.GetOpenEnrollmentPrograms();
        return Ok(new ApiResponse<IEnumerable<SpecializationProgramResponseDto>>(programs, true, "Programas con inscripción abierta."));
    }

    [HttpGet("upcoming")]
    public async Task<IActionResult> GetUpcoming()
    {
        var programs = await _service.GetUpcomingPrograms();
        return Ok(new ApiResponse<IEnumerable<SpecializationProgramResponseDto>>(programs, true, "Próximos programas."));
    }

    [HttpGet("university/{university}")]
    public async Task<IActionResult> GetByUniversity(string university)
    {
        if (string.IsNullOrWhiteSpace(university))
        {
            return BadRequest(new ApiResponse<object>(false, "El nombre de la universidad es requerido."));
        }
        var programs = await _service.GetProgramsByUniversity(university);
        return Ok(new ApiResponse<IEnumerable<SpecializationProgramResponseDto>>(programs, true, $"Programas de {university}."));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var program = await _service.GetProgramById(id);
        if (program == null)
            return NotFound(new ApiResponse<object>(false, "Programa de especialización no encontrado."));
        return Ok(new ApiResponse<SpecializationProgramResponseDto>(program, true, "Programa encontrado."));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSpecializationProgramDto dto)
    {
        if (dto == null || string.IsNullOrEmpty(dto.Name))
        {
            return BadRequest(new ApiResponse<object>(false, "El nombre del programa es requerido."));
        }
        if (string.IsNullOrEmpty(dto.Description))
        {
            return BadRequest(new ApiResponse<object>(false, "La descripción del programa es requerida."));
        }
        if (string.IsNullOrEmpty(dto.Duration))
        {
            return BadRequest(new ApiResponse<object>(false, "La duración del programa es requerida."));
        }
        try
        {
            var programId = await _service.CreateProgram(dto);
            return Ok(new ApiResponse<object>(new { ProgramId = programId }, true, "Programa creado correctamente."));
        }
        catch (Exception ex)
        {
            var errorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            return BadRequest(new ApiResponse<object>(false, errorMessage));
        }
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateSpecializationProgramDto dto)
    {
        if (dto == null || id != dto.Id)
        {
            return BadRequest(new ApiResponse<object>(false, "Id del programa no coincide con el Id en el cuerpo de la solicitud."));
        }
        if (string.IsNullOrEmpty(dto.Name))
        {
            return BadRequest(new ApiResponse<object>(false, "El nombre del programa es requerido."));
        }
        if (string.IsNullOrEmpty(dto.Description))
        {
            return BadRequest(new ApiResponse<object>(false, "La descripción del programa es requerida."));
        }
        if (string.IsNullOrEmpty(dto.Duration))
        {
            return BadRequest(new ApiResponse<object>(false, "La duración del programa es requerida."));
        }
        try
        {
            await _service.UpdateProgram(id, dto);
            return Ok(new ApiResponse<object>(true, "Programa actualizado correctamente."));
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
            await _service.DeleteProgram(id);
            return Ok(new ApiResponse<object>(true, "Programa eliminado correctamente."));
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<object>(false, ex.Message));
        }
    }
}
