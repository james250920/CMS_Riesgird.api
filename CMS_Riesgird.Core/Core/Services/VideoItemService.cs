using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Core.Services;

public class VideoItemService : IVideoItemService
{
    private readonly IVideoItemRepository _repository;

    public VideoItemService(IVideoItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<VideoItemResponseDto>> GetAllVideos()
    {
        var videos = await _repository.GetAllVideosAsync();
        return videos.Select(v => MapToResponseDto(v));
    }

    public async Task<VideoItemResponseDto?> GetVideoById(Guid id)
    {
        var video = await _repository.GetVideoByIdAsync(id);
        if (video == null)
            return null;

        return MapToResponseDto(video);
    }

    public async Task<IEnumerable<VideoItemResponseDto>> GetVideosByCongressId(Guid congressId)
    {
        var videos = await _repository.GetVideosByCongressIdAsync(congressId);
        return videos.Select(v => MapToResponseDto(v));
    }

    public async Task<IEnumerable<VideoItemResponseDto>> GetVideosByAlbumId(Guid albumId)
    {
        var videos = await _repository.GetVideosByAlbumIdAsync(albumId);
        return videos.Select(v => MapToResponseDto(v));
    }

    public async Task<Guid> CreateVideo(CreateVideoItemDto dto)
    {
        var video = new VideoItems
        {
            Id = Guid.NewGuid(),
            CongressId = dto.CongressId,
            AlbumId = dto.AlbumId,
            Title = dto.Title,
            Description = dto.Description,
            Url = dto.Url,
            ThumbnailUrl = dto.ThumbnailUrl,
            Duration = dto.Duration,
            SortOrder = dto.SortOrder
        };

        await _repository.AddVideoAsync(video);
        return video.Id;
    }

    public async Task UpdateVideo(Guid id, UpdateVideoItemDto dto)
    {
        var video = await _repository.GetVideoByIdAsync(id);
        if (video == null)
            throw new Exception("Video no encontrado");

        video.CongressId = dto.CongressId ?? video.CongressId;
        video.AlbumId = dto.AlbumId ?? video.AlbumId;
        video.Title = dto.Title ?? video.Title;
        video.Description = dto.Description ?? video.Description;
        video.Url = dto.Url ?? video.Url;
        video.ThumbnailUrl = dto.ThumbnailUrl ?? video.ThumbnailUrl;
        video.Duration = dto.Duration ?? video.Duration;
        video.SortOrder = dto.SortOrder;

        await _repository.UpdateVideoAsync(video);
    }

    public async Task DeleteVideo(Guid id)
    {
        await _repository.DeleteVideoAsync(id);
    }

    private VideoItemResponseDto MapToResponseDto(VideoItems video)
    {
        return new VideoItemResponseDto
        {
            Id = video.Id,
            CongressId = video.CongressId,
            AlbumId = video.AlbumId,
            Title = video.Title,
            Description = video.Description,
            Url = video.Url,
            ThumbnailUrl = video.ThumbnailUrl,
            Duration = video.Duration,
            SortOrder = video.SortOrder
        };
    }
}
