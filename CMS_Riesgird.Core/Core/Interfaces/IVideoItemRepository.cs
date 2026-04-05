using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Core.Interfaces;

public interface IVideoItemRepository
{
    Task<IEnumerable<VideoItems>> GetAllVideosAsync();
    Task<VideoItems?> GetVideoByIdAsync(Guid id);
    Task<IEnumerable<VideoItems>> GetVideosByCongressIdAsync(Guid congressId);
    Task<IEnumerable<VideoItems>> GetVideosByAlbumIdAsync(Guid albumId);
    Task AddVideoAsync(VideoItems video);
    Task UpdateVideoAsync(VideoItems video);
    Task DeleteVideoAsync(Guid id);
}
