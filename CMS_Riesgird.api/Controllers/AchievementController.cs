using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CMS_Riesgird.api.Controllers;

[Route("api/v1/achievements")]
[ApiController]
public class AchievementController : ControllerBase
{
    private readonly IAchievementService _service;

    public AchievementController(IAchievementService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var achievements = await _service.GetAllAchievements();
        return Ok(new ApiResponse<IEnumerable<AchievementResponseDto>>(achievements, true, "Lista de logros."));
    }

    [HttpGet("memory/{memoryId}")]
    public async Task<IActionResult> GetByMemoryId(Guid memoryId)
    {
        var achievements = await _service.GetAchievementsByMemoryId(memoryId);
        return Ok(new ApiResponse<IEnumerable<AchievementResponseDto>>(achievements, true, "Logros de la memoria de gestión."));
    }

    [HttpGet("category/{category}")]
    public async Task<IActionResult> GetByCategory(string category)
    {
        if (string.IsNullOrWhiteSpace(category))
        {
            return BadRequest(new ApiResponse<object>(false, "La categoría es requerida."));
        }
        var achievements = await _service.GetAchievementsByCategory(category);
        return Ok(new ApiResponse<IEnumerable<AchievementResponseDto>>(achievements, true, $"Logros en categoría: {category}."));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var achievement = await _service.GetAchievementById(id);
        if (achievement == null)
            return NotFound(new ApiResponse<object>(false, "Logro no encontrado."));
        return Ok(new ApiResponse<AchievementResponseDto>(achievement, true, "Logro encontrado."));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAchievementDto dto)
    {
        if (dto == null || string.IsNullOrEmpty(dto.Title))
        {
            return BadRequest(new ApiResponse<object>(false, "El título del logro es requerido."));
        }
        if (string.IsNullOrEmpty(dto.Description))
        {
            return BadRequest(new ApiResponse<object>(false, "La descripción del logro es requerida."));
        }
        if (string.IsNullOrEmpty(dto.Category))
        {
            return BadRequest(new ApiResponse<object>(false, "La categoría del logro es requerida."));
        }
        if (dto.MemoryId == Guid.Empty)
        {
            return BadRequest(new ApiResponse<object>(false, "El ID de la memoria es requerido."));
        }
        try
        {
            var achievementId = await _service.CreateAchievement(dto);
            return Ok(new ApiResponse<object>(new { AchievementId = achievementId }, true, "Logro creado correctamente."));
        }
        catch (Exception ex)
        {
            var errorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            return BadRequest(new ApiResponse<object>(false, errorMessage));
        }
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateAchievementDto dto)
    {
        if (dto == null || id != dto.Id)
        {
            return BadRequest(new ApiResponse<object>(false, "Id del logro no coincide."));
        }
        if (string.IsNullOrEmpty(dto.Title))
        {
            return BadRequest(new ApiResponse<object>(false, "El título del logro es requerido."));
        }
        if (string.IsNullOrEmpty(dto.Description))
        {
            return BadRequest(new ApiResponse<object>(false, "La descripción del logro es requerida."));
        }
        if (string.IsNullOrEmpty(dto.Category))
        {
            return BadRequest(new ApiResponse<object>(false, "La categoría del logro es requerida."));
        }
        try
        {
            await _service.UpdateAchievement(id, dto);
            return Ok(new ApiResponse<object>(true, "Logro actualizado correctamente."));
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
            await _service.DeleteAchievement(id);
            return Ok(new ApiResponse<object>(true, "Logro eliminado correctamente."));
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<object>(false, ex.Message));
        }
    }
}
