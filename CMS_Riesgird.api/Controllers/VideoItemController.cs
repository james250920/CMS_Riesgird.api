using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CMS_Riesgird.api.Controllers;

[Route("api/v1/video-items")]
[ApiController]
public class VideoItemController : ControllerBase
{
    private readonly IVideoItemService _service;

    public VideoItemController(IVideoItemService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var videos = await _service.GetAllVideos();
        return Ok(new ApiResponse<IEnumerable<VideoItemResponseDto>>(videos, true, "Lista de videos."));
    }

    [HttpGet("congress/{congressId}")]
    public async Task<IActionResult> GetByCongressId(Guid congressId)
    {
        var videos = await _service.GetVideosByCongressId(congressId);
        return Ok(new ApiResponse<IEnumerable<VideoItemResponseDto>>(videos, true, "Videos del congreso."));
    }

    [HttpGet("album/{albumId}")]
    public async Task<IActionResult> GetByAlbumId(Guid albumId)
    {
        var videos = await _service.GetVideosByAlbumId(albumId);
        return Ok(new ApiResponse<IEnumerable<VideoItemResponseDto>>(videos, true, "Videos del álbum."));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var video = await _service.GetVideoById(id);
        if (video == null)
            return NotFound(new ApiResponse<object>(false, "Video no encontrado."));
        return Ok(new ApiResponse<VideoItemResponseDto>(video, true, "Video encontrado."));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateVideoItemDto dto)
    {
        if (dto == null || string.IsNullOrEmpty(dto.Title))
        {
            return BadRequest(new ApiResponse<object>(false, "El título del video es requerido."));
        }
        if (string.IsNullOrEmpty(dto.Url))
        {
            return BadRequest(new ApiResponse<object>(false, "La URL del video es requerida."));
        }
        try
        {
            var videoId = await _service.CreateVideo(dto);
            return Ok(new ApiResponse<object>(new { VideoId = videoId }, true, "Video agregado correctamente."));
        }
        catch (Exception ex)
        {
            var errorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            return BadRequest(new ApiResponse<object>(false, errorMessage));
        }
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateVideoItemDto dto)
    {
        if (dto == null || id != dto.Id)
        {
            return BadRequest(new ApiResponse<object>(false, "Id del video no coincide."));
        }
        if (string.IsNullOrEmpty(dto.Title))
        {
            return BadRequest(new ApiResponse<object>(false, "El título del video es requerido."));
        }
        if (string.IsNullOrEmpty(dto.Url))
        {
            return BadRequest(new ApiResponse<object>(false, "La URL del video es requerida."));
        }
        try
        {
            await _service.UpdateVideo(id, dto);
            return Ok(new ApiResponse<object>(true, "Video actualizado correctamente."));
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
            await _service.DeleteVideo(id);
            return Ok(new ApiResponse<object>(true, "Video eliminado correctamente."));
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<object>(false, ex.Message));
        }
    }
}
