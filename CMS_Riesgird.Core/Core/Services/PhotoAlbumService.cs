using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Core.Services;

public class PhotoAlbumService : IPhotoAlbumService
{
    private readonly IPhotoAlbumRepository _repository;

    public PhotoAlbumService(IPhotoAlbumRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<PhotoAlbumResponseDto>> GetAllAlbums()
    {
        var albums = await _repository.GetAllAlbumsAsync();
        return albums.Select(a => MapToResponseDto(a));
    }

    public async Task<PhotoAlbumResponseDto?> GetAlbumById(Guid id)
    {
        var album = await _repository.GetAlbumByIdAsync(id);
        if (album == null)
            return null;

        return MapToResponseDto(album);
    }

    public async Task<IEnumerable<PhotoAlbumResponseDto>> GetPublicAlbums()
    {
        var albums = await _repository.GetPublicAlbumsAsync();
        return albums.Select(a => MapToResponseDto(a));
    }

    public async Task<IEnumerable<PhotoAlbumResponseDto>> GetFeaturedAlbums()
    {
        var albums = await _repository.GetFeaturedAlbumsAsync();
        return albums.Select(a => MapToResponseDto(a));
    }

    public async Task<IEnumerable<PhotoAlbumResponseDto>> GetAlbumsByEventId(Guid eventId)
    {
        var albums = await _repository.GetAlbumsByEventIdAsync(eventId);
        return albums.Select(a => MapToResponseDto(a));
    }

    public async Task<IEnumerable<PhotoAlbumResponseDto>> GetAlbumsByTag(string tag)
    {
        var albums = await _repository.GetAlbumsByTagAsync(tag);
        return albums.Select(a => MapToResponseDto(a));
    }

    public async Task<Guid> CreateAlbum(CreatePhotoAlbumDto dto)
    {
        var album = new PhotoAlbums
        {
            Id = Guid.NewGuid(),
            Title = dto.Title,
            Description = dto.Description,
            EventId = dto.EventId,
            EventName = dto.EventName,
            EventDate = dto.EventDate,
            Date = dto.Date,
            CoverPhotoUrl = dto.CoverPhotoUrl,
            CoverImageUrl = dto.CoverImageUrl,
            ExternalUrl = dto.ExternalUrl,
            DownloadUrl = dto.DownloadUrl,
            ItemsCount = dto.ItemsCount,
            Tags = dto.Tags,
            IsPublic = dto.IsPublic,
            IsFeatured = dto.IsFeatured,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            CreatedBy = dto.CreatedBy
        };

        await _repository.AddAlbumAsync(album);
        return album.Id;
    }

    public async Task UpdateAlbum(Guid id, UpdatePhotoAlbumDto dto)
    {
        var album = await _repository.GetAlbumByIdAsync(id);
        if (album == null)
            throw new Exception("Álbum de fotos no encontrado");

        album.Title = dto.Title ?? album.Title;
        album.Description = dto.Description ?? album.Description;
        album.EventId = dto.EventId ?? album.EventId;
        album.EventName = dto.EventName ?? album.EventName;
        album.EventDate = dto.EventDate ?? album.EventDate;
        album.Date = dto.Date;
        album.CoverPhotoUrl = dto.CoverPhotoUrl ?? album.CoverPhotoUrl;
        album.CoverImageUrl = dto.CoverImageUrl ?? album.CoverImageUrl;
        album.ExternalUrl = dto.ExternalUrl ?? album.ExternalUrl;
        album.DownloadUrl = dto.DownloadUrl ?? album.DownloadUrl;
        album.ItemsCount = dto.ItemsCount ?? album.ItemsCount;
        album.Tags = dto.Tags ?? album.Tags;
        album.IsPublic = dto.IsPublic;
        album.IsFeatured = dto.IsFeatured;
        album.UpdatedAt = DateTime.UtcNow;

        await _repository.UpdateAlbumAsync(album);
    }

    public async Task DeleteAlbum(Guid id)
    {
        await _repository.DeleteAlbumAsync(id);
    }

    private PhotoAlbumResponseDto MapToResponseDto(PhotoAlbums album)
    {
        return new PhotoAlbumResponseDto
        {
            Id = album.Id,
            Title = album.Title,
            Description = album.Description,
            EventId = album.EventId,
            EventName = album.EventName,
            EventDate = album.EventDate,
            Date = album.Date,
            CoverPhotoUrl = album.CoverPhotoUrl,
            CoverImageUrl = album.CoverImageUrl,
            ExternalUrl = album.ExternalUrl,
            DownloadUrl = album.DownloadUrl,
            ItemsCount = album.ItemsCount,
            Tags = album.Tags,
            IsPublic = album.IsPublic,
            IsFeatured = album.IsFeatured,
            CreatedAt = album.CreatedAt,
            UpdatedAt = album.UpdatedAt
        };
    }
}
