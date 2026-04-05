using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CMS_Riesgird.api.Controllers;

[Route("api/v1/album-photos")]
[ApiController]
public class AlbumPhotoController : ControllerBase
{
    private readonly IAlbumPhotoService _service;

    public AlbumPhotoController(IAlbumPhotoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var photos = await _service.GetAllPhotos();
        return Ok(new ApiResponse<IEnumerable<AlbumPhotoResponseDto>>(photos, true, "Lista de fotos del álbum."));
    }

    [HttpGet("album/{albumId}")]
    public async Task<IActionResult> GetByAlbumId(Guid albumId)
    {
        var photos = await _service.GetPhotosByAlbumId(albumId);
        return Ok(new ApiResponse<IEnumerable<AlbumPhotoResponseDto>>(photos, true, "Fotos del álbum."));
    }

    [HttpGet("album/{albumId}/public")]
    public async Task<IActionResult> GetPublicByAlbumId(Guid albumId)
    {
        var photos = await _service.GetPublicPhotosByAlbumId(albumId);
        return Ok(new ApiResponse<IEnumerable<AlbumPhotoResponseDto>>(photos, true, "Fotos públicas del álbum."));
    }

    [HttpGet("album/{albumId}/cover")]
    public async Task<IActionResult> GetCoverByAlbumId(Guid albumId)
    {
        var photo = await _service.GetCoverPhotoByAlbumId(albumId);
        if (photo == null)
            return NotFound(new ApiResponse<object>(false, "Foto de portada no encontrada."));
        return Ok(new ApiResponse<AlbumPhotoResponseDto>(photo, true, "Foto de portada del álbum."));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var photo = await _service.GetPhotoById(id);
        if (photo == null)
            return NotFound(new ApiResponse<object>(false, "Foto no encontrada."));
        return Ok(new ApiResponse<AlbumPhotoResponseDto>(photo, true, "Foto encontrada."));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAlbumPhotoDto dto)
    {
        if (dto == null || string.IsNullOrEmpty(dto.Url))
        {
            return BadRequest(new ApiResponse<object>(false, "La URL de la foto es requerida."));
        }
        if (dto.AlbumId == Guid.Empty)
        {
            return BadRequest(new ApiResponse<object>(false, "El ID del álbum es requerido."));
        }
        try
        {
            var photoId = await _service.CreatePhoto(dto);
            return Ok(new ApiResponse<object>(new { PhotoId = photoId }, true, "Foto agregada correctamente."));
        }
        catch (Exception ex)
        {
            var errorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            return BadRequest(new ApiResponse<object>(false, errorMessage));
        }
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateAlbumPhotoDto dto)
    {
        if (dto == null || id != dto.Id)
        {
            return BadRequest(new ApiResponse<object>(false, "Id de la foto no coincide."));
        }
        if (string.IsNullOrEmpty(dto.Url))
        {
            return BadRequest(new ApiResponse<object>(false, "La URL de la foto es requerida."));
        }
        try
        {
            await _service.UpdatePhoto(id, dto);
            return Ok(new ApiResponse<object>(true, "Foto actualizada correctamente."));
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
            await _service.DeletePhoto(id);
            return Ok(new ApiResponse<object>(true, "Foto eliminada correctamente."));
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<object>(false, ex.Message));
        }
    }
}
