using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Core.Interfaces;

public interface IAlbumPhotoRepository
{
    Task<IEnumerable<AlbumPhotos>> GetAllPhotosAsync();
    Task<AlbumPhotos?> GetPhotoByIdAsync(Guid id);
    Task<IEnumerable<AlbumPhotos>> GetPhotosByAlbumIdAsync(Guid albumId);
    Task<AlbumPhotos?> GetCoverPhotoByAlbumIdAsync(Guid albumId);
    Task<IEnumerable<AlbumPhotos>> GetPublicPhotosByAlbumIdAsync(Guid albumId);
    Task AddPhotoAsync(AlbumPhotos photo);
    Task UpdatePhotoAsync(AlbumPhotos photo);
    Task DeletePhotoAsync(Guid id);
}
