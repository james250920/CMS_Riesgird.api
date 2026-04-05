using CMS_Riesgird.Core.Core.DTOs;

namespace CMS_Riesgird.Core.Core.Interfaces;

public interface IVideoItemService
{
    Task<IEnumerable<VideoItemResponseDto>> GetAllVideos();
    Task<VideoItemResponseDto?> GetVideoById(Guid id);
    Task<IEnumerable<VideoItemResponseDto>> GetVideosByCongressId(Guid congressId);
    Task<IEnumerable<VideoItemResponseDto>> GetVideosByAlbumId(Guid albumId);
    Task<Guid> CreateVideo(CreateVideoItemDto dto);
    Task UpdateVideo(Guid id, UpdateVideoItemDto dto);
    Task DeleteVideo(Guid id);
}
