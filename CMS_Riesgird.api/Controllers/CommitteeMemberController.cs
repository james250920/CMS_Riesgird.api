using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CMS_Riesgird.api.Controllers;

[Route("api/v1/committee-members")]
[ApiController]
public class CommitteeMemberController : ControllerBase
{
    private readonly ICommitteeMemberService _service;

    public CommitteeMemberController(ICommitteeMemberService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var members = await _service.GetAllMembers();
        return Ok(new ApiResponse<IEnumerable<CommitteeMemberResponseDto>>(members, true, "Lista de miembros del comité."));
    }

    [HttpGet("congress/{congressId}")]
    public async Task<IActionResult> GetByCongressId(Guid congressId)
    {
        var members = await _service.GetMembersByCongressId(congressId);
        return Ok(new ApiResponse<IEnumerable<CommitteeMemberResponseDto>>(members, true, "Miembros del comité del congreso."));
    }

    [HttpGet("role/{role}")]
    public async Task<IActionResult> GetByRole(string role)
    {
        if (string.IsNullOrWhiteSpace(role))
        {
            return BadRequest(new ApiResponse<object>(false, "El rol es requerido."));
        }
        var members = await _service.GetMembersByRole(role);
        return Ok(new ApiResponse<IEnumerable<CommitteeMemberResponseDto>>(members, true, $"Miembros con rol: {role}."));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var member = await _service.GetMemberById(id);
        if (member == null)
            return NotFound(new ApiResponse<object>(false, "Miembro del comité no encontrado."));
        return Ok(new ApiResponse<CommitteeMemberResponseDto>(member, true, "Miembro encontrado."));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCommitteeMemberDto dto)
    {
        if (dto == null || string.IsNullOrEmpty(dto.FullName))
        {
            return BadRequest(new ApiResponse<object>(false, "El nombre completo del miembro es requerido."));
        }
        if (string.IsNullOrEmpty(dto.Role))
        {
            return BadRequest(new ApiResponse<object>(false, "El rol del miembro es requerido."));
        }
        if (string.IsNullOrEmpty(dto.Institution))
        {
            return BadRequest(new ApiResponse<object>(false, "La institución del miembro es requerida."));
        }
        if (dto.CongressId == Guid.Empty)
        {
            return BadRequest(new ApiResponse<object>(false, "El ID del congreso es requerido."));
        }
        try
        {
            var memberId = await _service.CreateMember(dto);
            return Ok(new ApiResponse<object>(new { MemberId = memberId }, true, "Miembro del comité creado correctamente."));
        }
        catch (Exception ex)
        {
            var errorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            return BadRequest(new ApiResponse<object>(false, errorMessage));
        }
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCommitteeMemberDto dto)
    {
        if (dto == null || id != dto.Id)
        {
            return BadRequest(new ApiResponse<object>(false, "Id del miembro no coincide con el Id en el cuerpo de la solicitud."));
        }
        if (string.IsNullOrEmpty(dto.FullName))
        {
            return BadRequest(new ApiResponse<object>(false, "El nombre completo del miembro es requerido."));
        }
        if (string.IsNullOrEmpty(dto.Role))
        {
            return BadRequest(new ApiResponse<object>(false, "El rol del miembro es requerido."));
        }
        if (string.IsNullOrEmpty(dto.Institution))
        {
            return BadRequest(new ApiResponse<object>(false, "La institución del miembro es requerida."));
        }
        try
        {
            await _service.UpdateMember(id, dto);
            return Ok(new ApiResponse<object>(true, "Miembro del comité actualizado correctamente."));
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
            await _service.DeleteMember(id);
            return Ok(new ApiResponse<object>(true, "Miembro del comité eliminado correctamente."));
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<object>(false, ex.Message));
        }
    }
}
