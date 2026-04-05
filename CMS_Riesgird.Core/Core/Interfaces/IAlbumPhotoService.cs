using CMS_Riesgird.Core.Core.DTOs;

namespace CMS_Riesgird.Core.Core.Interfaces;

public interface IAlbumPhotoService
{
    Task<IEnumerable<AlbumPhotoResponseDto>> GetAllPhotos();
    Task<AlbumPhotoResponseDto?> GetPhotoById(Guid id);
    Task<IEnumerable<AlbumPhotoResponseDto>> GetPhotosByAlbumId(Guid albumId);
    Task<AlbumPhotoResponseDto?> GetCoverPhotoByAlbumId(Guid albumId);
    Task<IEnumerable<AlbumPhotoResponseDto>> GetPublicPhotosByAlbumId(Guid albumId);
    Task<Guid> CreatePhoto(CreateAlbumPhotoDto dto);
    Task UpdatePhoto(Guid id, UpdateAlbumPhotoDto dto);
    Task DeletePhoto(Guid id);
}
