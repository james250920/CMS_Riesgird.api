using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Core.Services;

public class AlbumPhotoService : IAlbumPhotoService
{
    private readonly IAlbumPhotoRepository _repository;

    public AlbumPhotoService(IAlbumPhotoRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<AlbumPhotoResponseDto>> GetAllPhotos()
    {
        var photos = await _repository.GetAllPhotosAsync();
        return photos.Select(p => MapToResponseDto(p));
    }

    public async Task<AlbumPhotoResponseDto?> GetPhotoById(Guid id)
    {
        var photo = await _repository.GetPhotoByIdAsync(id);
        if (photo == null)
            return null;

        return MapToResponseDto(photo);
    }

    public async Task<IEnumerable<AlbumPhotoResponseDto>> GetPhotosByAlbumId(Guid albumId)
    {
        var photos = await _repository.GetPhotosByAlbumIdAsync(albumId);
        return photos.Select(p => MapToResponseDto(p));
    }

    public async Task<AlbumPhotoResponseDto?> GetCoverPhotoByAlbumId(Guid albumId)
    {
        var photo = await _repository.GetCoverPhotoByAlbumIdAsync(albumId);
        if (photo == null)
            return null;

        return MapToResponseDto(photo);
    }

    public async Task<IEnumerable<AlbumPhotoResponseDto>> GetPublicPhotosByAlbumId(Guid albumId)
    {
        var photos = await _repository.GetPublicPhotosByAlbumIdAsync(albumId);
        return photos.Select(p => MapToResponseDto(p));
    }

    public async Task<Guid> CreatePhoto(CreateAlbumPhotoDto dto)
    {
        var photo = new AlbumPhotos
        {
            Id = Guid.NewGuid(),
            AlbumId = dto.AlbumId,
            Url = dto.Url,
            ThumbnailUrl = dto.ThumbnailUrl,
            Caption = dto.Caption,
            Photographer = dto.Photographer,
            TakenAt = dto.TakenAt,
            SortOrder = dto.SortOrder,
            IsCover = dto.IsCover,
            IsPublic = dto.IsPublic
        };

        await _repository.AddPhotoAsync(photo);
        return photo.Id;
    }

    public async Task UpdatePhoto(Guid id, UpdateAlbumPhotoDto dto)
    {
        var photo = await _repository.GetPhotoByIdAsync(id);
        if (photo == null)
            throw new Exception("Foto no encontrada");

        photo.AlbumId = dto.AlbumId;
        photo.Url = dto.Url ?? photo.Url;
        photo.ThumbnailUrl = dto.ThumbnailUrl ?? photo.ThumbnailUrl;
        photo.Caption = dto.Caption ?? photo.Caption;
        photo.Photographer = dto.Photographer ?? photo.Photographer;
        photo.TakenAt = dto.TakenAt ?? photo.TakenAt;
        photo.SortOrder = dto.SortOrder;
        photo.IsCover = dto.IsCover;
        photo.IsPublic = dto.IsPublic;

        await _repository.UpdatePhotoAsync(photo);
    }

    public async Task DeletePhoto(Guid id)
    {
        await _repository.DeletePhotoAsync(id);
    }

    private AlbumPhotoResponseDto MapToResponseDto(AlbumPhotos photo)
    {
        return new AlbumPhotoResponseDto
        {
            Id = photo.Id,
            AlbumId = photo.AlbumId,
            Url = photo.Url,
            ThumbnailUrl = photo.ThumbnailUrl,
            Caption = photo.Caption,
            Photographer = photo.Photographer,
            TakenAt = photo.TakenAt,
            SortOrder = photo.SortOrder,
            IsCover = photo.IsCover,
            IsPublic = photo.IsPublic
        };
    }
}
