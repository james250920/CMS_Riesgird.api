using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CMS_Riesgird.api.Controllers;

[Route("api/v1/photo-albums")]
[ApiController]
public class PhotoAlbumController : ControllerBase
{
    private readonly IPhotoAlbumService _service;

    public PhotoAlbumController(IPhotoAlbumService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var albums = await _service.GetAllAlbums();
        return Ok(new ApiResponse<IEnumerable<PhotoAlbumResponseDto>>(albums, true, "Lista de álbumes de fotos."));
    }

    [HttpGet("public")]
    public async Task<IActionResult> GetPublic()
    {
        var albums = await _service.GetPublicAlbums();
        return Ok(new ApiResponse<IEnumerable<PhotoAlbumResponseDto>>(albums, true, "Álbumes públicos."));
    }

    [HttpGet("featured")]
    public async Task<IActionResult> GetFeatured()
    {
        var albums = await _service.GetFeaturedAlbums();
        return Ok(new ApiResponse<IEnumerable<PhotoAlbumResponseDto>>(albums, true, "Álbumes destacados."));
    }

    [HttpGet("event/{eventId}")]
    public async Task<IActionResult> GetByEventId(Guid eventId)
    {
        var albums = await _service.GetAlbumsByEventId(eventId);
        return Ok(new ApiResponse<IEnumerable<PhotoAlbumResponseDto>>(albums, true, "Álbumes del evento."));
    }

    [HttpGet("tag/{tag}")]
    public async Task<IActionResult> GetByTag(string tag)
    {
        if (string.IsNullOrWhiteSpace(tag))
        {
            return BadRequest(new ApiResponse<object>(false, "La etiqueta es requerida."));
        }
        var albums = await _service.GetAlbumsByTag(tag);
        return Ok(new ApiResponse<IEnumerable<PhotoAlbumResponseDto>>(albums, true, $"Álbumes con etiqueta: {tag}."));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var album = await _service.GetAlbumById(id);
        if (album == null)
            return NotFound(new ApiResponse<object>(false, "Álbum no encontrado."));
        return Ok(new ApiResponse<PhotoAlbumResponseDto>(album, true, "Álbum encontrado."));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePhotoAlbumDto dto)
    {
        if (dto == null || string.IsNullOrEmpty(dto.Title))
        {
            return BadRequest(new ApiResponse<object>(false, "El título del álbum es requerido."));
        }
        try
        {
            var albumId = await _service.CreateAlbum(dto);
            return Ok(new ApiResponse<object>(new { AlbumId = albumId }, true, "Álbum creado correctamente."));
        }
        catch (Exception ex)
        {
            var errorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            return BadRequest(new ApiResponse<object>(false, errorMessage));
        }
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdatePhotoAlbumDto dto)
    {
        if (dto == null || id != dto.Id)
        {
            return BadRequest(new ApiResponse<object>(false, "Id del álbum no coincide."));
        }
        if (string.IsNullOrEmpty(dto.Title))
        {
            return BadRequest(new ApiResponse<object>(false, "El título del álbum es requerido."));
        }
        try
        {
            await _service.UpdateAlbum(id, dto);
            return Ok(new ApiResponse<object>(true, "Álbum actualizado correctamente."));
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
            await _service.DeleteAlbum(id);
            return Ok(new ApiResponse<object>(true, "Álbum eliminado correctamente."));
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<object>(false, ex.Message));
        }
    }
}
