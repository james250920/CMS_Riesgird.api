using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Core.Interfaces;

public interface IPhotoAlbumRepository
{
    Task<IEnumerable<PhotoAlbums>> GetAllAlbumsAsync();
    Task<PhotoAlbums?> GetAlbumByIdAsync(Guid id);
    Task<IEnumerable<PhotoAlbums>> GetPublicAlbumsAsync();
    Task<IEnumerable<PhotoAlbums>> GetFeaturedAlbumsAsync();
    Task<IEnumerable<PhotoAlbums>> GetAlbumsByEventIdAsync(Guid eventId);
    Task<IEnumerable<PhotoAlbums>> GetAlbumsByTagAsync(string tag);
    Task AddAlbumAsync(PhotoAlbums album);
    Task UpdateAlbumAsync(PhotoAlbums album);
    Task DeleteAlbumAsync(Guid id);
}
