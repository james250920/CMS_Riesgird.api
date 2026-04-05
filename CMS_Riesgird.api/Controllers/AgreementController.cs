using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CMS_Riesgird.api.Controllers;

[Route("api/v1/agreements")]
[ApiController]
public class AgreementController : ControllerBase
{
    private readonly IAgreementService _service;

    public AgreementController(IAgreementService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var agreements = await _service.GetAllAgreements();
        return Ok(new ApiResponse<IEnumerable<AgreementResponseDto>>(agreements, true, "Lista de acuerdos."));
    }

    [HttpGet("public")]
    public async Task<IActionResult> GetPublic()
    {
        var agreements = await _service.GetPublicAgreements();
        return Ok(new ApiResponse<IEnumerable<AgreementResponseDto>>(agreements, true, "Lista de acuerdos públicos."));
    }

    [HttpGet("with-due-date")]
    public async Task<IActionResult> GetWithDueDate()
    {
        var agreements = await _service.GetAgreementsWithDueDate();
        return Ok(new ApiResponse<IEnumerable<AgreementResponseDto>>(agreements, true, "Acuerdos con fecha de vencimiento."));
    }

    [HttpGet("assembly/{assemblyId}")]
    public async Task<IActionResult> GetByAssemblyId(Guid assemblyId)
    {
        var agreements = await _service.GetAgreementsByAssemblyId(assemblyId);
        return Ok(new ApiResponse<IEnumerable<AgreementResponseDto>>(agreements, true, "Acuerdos de la asamblea."));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var agreement = await _service.GetAgreementById(id);
        if (agreement == null)
            return NotFound(new ApiResponse<object>(false, "Acuerdo no encontrado."));
        return Ok(new ApiResponse<AgreementResponseDto>(agreement, true, "Acuerdo encontrado."));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAgreementDto dto)
    {
        if (dto == null || string.IsNullOrEmpty(dto.Number))
        {
            return BadRequest(new ApiResponse<object>(false, "El número del acuerdo es requerido."));
        }
        if (string.IsNullOrEmpty(dto.Title))
        {
            return BadRequest(new ApiResponse<object>(false, "El título del acuerdo es requerido."));
        }
        if (string.IsNullOrEmpty(dto.Description))
        {
            return BadRequest(new ApiResponse<object>(false, "La descripción del acuerdo es requerida."));
        }
        if (dto.AssemblyId == Guid.Empty)
        {
            return BadRequest(new ApiResponse<object>(false, "El ID de la asamblea es requerido."));
        }
        try
        {
            var agreementId = await _service.CreateAgreement(dto);
            return Ok(new ApiResponse<object>(new { AgreementId = agreementId }, true, "Acuerdo creado correctamente."));
        }
        catch (Exception ex)
        {
            var errorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            return BadRequest(new ApiResponse<object>(false, errorMessage));
        }
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateAgreementDto dto)
    {
        if (dto == null || id != dto.Id)
        {
            return BadRequest(new ApiResponse<object>(false, "Id del acuerdo no coincide con el Id en el cuerpo de la solicitud."));
        }
        if (string.IsNullOrEmpty(dto.Number))
        {
            return BadRequest(new ApiResponse<object>(false, "El número del acuerdo es requerido."));
        }
        if (string.IsNullOrEmpty(dto.Title))
        {
            return BadRequest(new ApiResponse<object>(false, "El título del acuerdo es requerido."));
        }
        if (string.IsNullOrEmpty(dto.Description))
        {
            return BadRequest(new ApiResponse<object>(false, "La descripción del acuerdo es requerida."));
        }
        try
        {
            await _service.UpdateAgreement(id, dto);
            return Ok(new ApiResponse<object>(true, "Acuerdo actualizado correctamente."));
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
            await _service.DeleteAgreement(id);
            return Ok(new ApiResponse<object>(true, "Acuerdo eliminado correctamente."));
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<object>(false, ex.Message));
        }
    }
}
