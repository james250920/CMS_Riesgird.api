using CMS_Riesgird.Core.Core.DTOs;

namespace CMS_Riesgird.Core.Core.Interfaces;

public interface IPhotoAlbumService
{
    Task<IEnumerable<PhotoAlbumResponseDto>> GetAllAlbums();
    Task<PhotoAlbumResponseDto?> GetAlbumById(Guid id);
    Task<IEnumerable<PhotoAlbumResponseDto>> GetPublicAlbums();
    Task<IEnumerable<PhotoAlbumResponseDto>> GetFeaturedAlbums();
    Task<IEnumerable<PhotoAlbumResponseDto>> GetAlbumsByEventId(Guid eventId);
    Task<IEnumerable<PhotoAlbumResponseDto>> GetAlbumsByTag(string tag);
    Task<Guid> CreateAlbum(CreatePhotoAlbumDto dto);
    Task UpdateAlbum(Guid id, UpdatePhotoAlbumDto dto);
    Task DeleteAlbum(Guid id);
}
