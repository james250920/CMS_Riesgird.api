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
            return Ok(universities);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var university = await _universityService.GetUniversityById(id);
            if (university == null)
                return NotFound();
            return Ok(university);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUniversityDto dto)
        {
            if (dto == null || string.IsNullOrEmpty(dto.Name))
            {
                return BadRequest("El nombre de la universidad es requerido");
            }
            try
            {
                var universityId = await _universityService.CreateUniversity(dto);
                return Ok(new { UniversityId = universityId });
            }
            catch (Exception ex)
            {
                var errorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest(errorMessage);
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateUniversityDto dto)
        {
            if (dto == null || id != dto.Id)
            {
                return BadRequest("Id de la universidad no coincide con el Id en el cuerpo de la solicitud");
            }
            try
            {
                await _universityService.UpdateUniversity(id, dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _universityService.DeleteUniversity(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
