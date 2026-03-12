using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CMS_Riesgird.api.Controllers
{
    [Route("api/v1/universities")]
    [ApiController]
    public class UniversityController : ControllerBase
    {
        private readonly IUniversityService _universityService;

        public UniversityController(IUniversityService universityService)
        {
            _universityService = universityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var universities = await _universityService.GetAllUniversities();
            return Ok(new ApiResponse<IEnumerable<UniversityResponseDto>>(universities, true, "Lista de universidades."));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var university = await _universityService.GetUniversityById(id);
            if (university == null)
                return NotFound(new ApiResponse<object>(false, "Universidad no encontrada."));
            return Ok(new ApiResponse<UniversityResponseDto>(university, true, "Universidad encontrada."));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUniversityDto dto)
        {
            if (dto == null || string.IsNullOrEmpty(dto.Name))
            {
                return BadRequest(new ApiResponse<object>(false, "El nombre de la universidad es requerido."));
            }
            try
            {
                var universityId = await _universityService.CreateUniversity(dto);
                return Ok(new ApiResponse<object>(new { UniversityId = universityId }, true, "Universidad creada correctamente."));
            }
            catch (Exception ex)
            {
                var errorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest(new ApiResponse<object>(false, errorMessage));
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateUniversityDto dto)
        {
            if (dto == null || id != dto.Id)
            {
                return BadRequest(new ApiResponse<object>(false, "Id de la universidad no coincide con el Id en el cuerpo de la solicitud."));
            }
            try
            {
                await _universityService.UpdateUniversity(id, dto);
                return Ok(new ApiResponse<object>(true, "Universidad actualizada correctamente."));
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
                await _universityService.DeleteUniversity(id);
                return Ok(new ApiResponse<object>(true, "Universidad eliminada correctamente."));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<object>(false, ex.Message));
            }
        }
    }
}
