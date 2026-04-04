using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CMS_Riesgird.api.Controllers;

[Route("api/v1/technical-team-members")]
[ApiController]
public class TechnicalTeamMemberController : ControllerBase
{
    private readonly ITechnicalTeamMemberService _service;

    public TechnicalTeamMemberController(ITechnicalTeamMemberService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var members = await _service.GetAllTechnicalTeamMembers();
        return Ok(new ApiResponse<IEnumerable<TechnicalTeamMemberResponseDto>>(members, true, "Lista de miembros del equipo técnico."));
    }

    [HttpGet("university/{universityId}")]
    public async Task<IActionResult> GetByUniversityId(Guid universityId)
    {
        var members = await _service.GetTechnicalTeamMembersByUniversityId(universityId);
        return Ok(new ApiResponse<IEnumerable<TechnicalTeamMemberResponseDto>>(members, true, "Lista de miembros del equipo técnico de la universidad."));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var member = await _service.GetTechnicalTeamMemberById(id);
        if (member == null)
            return NotFound(new ApiResponse<object>(false, "Miembro del equipo técnico no encontrado."));
        return Ok(new ApiResponse<TechnicalTeamMemberResponseDto>(member, true, "Miembro del equipo técnico encontrado."));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTechnicalTeamMemberDto dto)
    {
        if (dto == null || string.IsNullOrEmpty(dto.FullName))
        {
            return BadRequest(new ApiResponse<object>(false, "El nombre completo del miembro es requerido."));
        }
        if (dto.UniversityId == Guid.Empty)
        {
            return BadRequest(new ApiResponse<object>(false, "El ID de la universidad es requerido."));
        }
        try
        {
            var memberId = await _service.CreateTechnicalTeamMember(dto);
            return Ok(new ApiResponse<object>(new { MemberId = memberId }, true, "Miembro del equipo técnico creado correctamente."));
        }
        catch (Exception ex)
        {
            var errorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            return BadRequest(new ApiResponse<object>(false, errorMessage));
        }
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateTechnicalTeamMemberDto dto)
    {
        if (dto == null || id != dto.Id)
        {
            return BadRequest(new ApiResponse<object>(false, "Id del miembro no coincide con el Id en el cuerpo de la solicitud."));
        }
        if (string.IsNullOrEmpty(dto.FullName))
        {
            return BadRequest(new ApiResponse<object>(false, "El nombre completo del miembro es requerido."));
        }
        try
        {
            await _service.UpdateTechnicalTeamMember(id, dto);
            return Ok(new ApiResponse<object>(true, "Miembro del equipo técnico actualizado correctamente."));
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
            await _service.DeleteTechnicalTeamMember(id);
            return Ok(new ApiResponse<object>(true, "Miembro del equipo técnico eliminado correctamente."));
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<object>(false, ex.Message));
        }
    }
}
