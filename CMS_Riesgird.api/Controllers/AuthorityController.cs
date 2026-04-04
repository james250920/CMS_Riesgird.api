using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CMS_Riesgird.api.Controllers
{
    [Route("api/v1/authorities")]
    [ApiController]
    public class AuthorityController : ControllerBase
    {
        private readonly IAuthorityService _authorityService;

        public AuthorityController(IAuthorityService authorityService)
        {
            _authorityService = authorityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var authorities = await _authorityService.GetAllAuthorities();
            return Ok(new ApiResponse<IEnumerable<AuthorityResponseDto>>(authorities, true, "Lista de autoridades."));
        }

        [HttpGet("university/{universityId}")]
        public async Task<IActionResult> GetByUniversityId(Guid universityId)
        {
            var authorities = await _authorityService.GetAuthoritiesByUniversityId(universityId);
            return Ok(new ApiResponse<IEnumerable<AuthorityResponseDto>>(authorities, true, "Lista de autoridades de la universidad."));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var authority = await _authorityService.GetAuthorityById(id);
            if (authority == null)
                return NotFound(new ApiResponse<object>(false, "Autoridad no encontrada."));
            return Ok(new ApiResponse<AuthorityResponseDto>(authority, true, "Autoridad encontrada."));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAuthorityDto dto)
        {
            if (dto == null || string.IsNullOrEmpty(dto.FullName))
            {
                return BadRequest(new ApiResponse<object>(false, "El nombre completo de la autoridad es requerido."));
            }
            if (dto.UniversityId == Guid.Empty)
            {
                return BadRequest(new ApiResponse<object>(false, "El ID de la universidad es requerido."));
            }
            if (string.IsNullOrEmpty(dto.Role))
            {
                return BadRequest(new ApiResponse<object>(false, "El rol de la autoridad es requerido."));
            }
            try
            {
                var authorityId = await _authorityService.CreateAuthority(dto);
                return Ok(new ApiResponse<object>(new { AuthorityId = authorityId }, true, "Autoridad creada correctamente."));
            }
            catch (Exception ex)
            {
                var errorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest(new ApiResponse<object>(false, errorMessage));
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateAuthorityDto dto)
        {
            if (dto == null || id != dto.Id)
            {
                return BadRequest(new ApiResponse<object>(false, "Id de la autoridad no coincide con el Id en el cuerpo de la solicitud."));
            }
            if (string.IsNullOrEmpty(dto.FullName))
            {
                return BadRequest(new ApiResponse<object>(false, "El nombre completo de la autoridad es requerido."));
            }
            if (string.IsNullOrEmpty(dto.Role))
            {
                return BadRequest(new ApiResponse<object>(false, "El rol de la autoridad es requerido."));
            }
            try
            {
                await _authorityService.UpdateAuthority(id, dto);
                return Ok(new ApiResponse<object>(true, "Autoridad actualizada correctamente."));
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
                await _authorityService.DeleteAuthority(id);
                return Ok(new ApiResponse<object>(true, "Autoridad eliminada correctamente."));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<object>(false, ex.Message));
            }
        }
    }
}
