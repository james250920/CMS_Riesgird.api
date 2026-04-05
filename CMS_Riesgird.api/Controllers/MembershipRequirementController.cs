using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CMS_Riesgird.api.Controllers;

[Route("api/v1/membership-requirements")]
[ApiController]
public class MembershipRequirementController : ControllerBase
{
    private readonly IMembershipRequirementService _service;

    public MembershipRequirementController(IMembershipRequirementService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var requirements = await _service.GetAllRequirements();
        return Ok(new ApiResponse<IEnumerable<MembershipRequirementResponseDto>>(requirements, true, "Lista de requisitos de membresía."));
    }

    [HttpGet("active")]
    public async Task<IActionResult> GetActive()
    {
        var requirements = await _service.GetActiveRequirements();
        return Ok(new ApiResponse<IEnumerable<MembershipRequirementResponseDto>>(requirements, true, "Requisitos activos."));
    }

    [HttpGet("required")]
    public async Task<IActionResult> GetRequired()
    {
        var requirements = await _service.GetRequiredRequirements();
        return Ok(new ApiResponse<IEnumerable<MembershipRequirementResponseDto>>(requirements, true, "Requisitos obligatorios."));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var requirement = await _service.GetRequirementById(id);
        if (requirement == null)
            return NotFound(new ApiResponse<object>(false, "Requisito no encontrado."));
        return Ok(new ApiResponse<MembershipRequirementResponseDto>(requirement, true, "Requisito encontrado."));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateMembershipRequirementDto dto)
    {
        if (dto == null || string.IsNullOrEmpty(dto.Title))
        {
            return BadRequest(new ApiResponse<object>(false, "El título del requisito es requerido."));
        }
        if (string.IsNullOrEmpty(dto.Description))
        {
            return BadRequest(new ApiResponse<object>(false, "La descripción del requisito es requerida."));
        }
        try
        {
            var requirementId = await _service.CreateRequirement(dto);
            return Ok(new ApiResponse<object>(new { RequirementId = requirementId }, true, "Requisito creado correctamente."));
        }
        catch (Exception ex)
        {
            var errorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            return BadRequest(new ApiResponse<object>(false, errorMessage));
        }
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateMembershipRequirementDto dto)
    {
        if (dto == null || id != dto.Id)
        {
            return BadRequest(new ApiResponse<object>(false, "Id del requisito no coincide."));
        }
        if (string.IsNullOrEmpty(dto.Title))
        {
            return BadRequest(new ApiResponse<object>(false, "El título del requisito es requerido."));
        }
        if (string.IsNullOrEmpty(dto.Description))
        {
            return BadRequest(new ApiResponse<object>(false, "La descripción del requisito es requerida."));
        }
        try
        {
            await _service.UpdateRequirement(id, dto);
            return Ok(new ApiResponse<object>(true, "Requisito actualizado correctamente."));
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
            await _service.DeleteRequirement(id);
            return Ok(new ApiResponse<object>(true, "Requisito eliminado correctamente."));
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<object>(false, ex.Message));
        }
    }
}
