using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Core.Services;

public class CongressService : ICongressService
{
    private readonly ICongressRepository _repository;

    public CongressService(ICongressRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<CongressResponseDto>> GetAllCongresses()
    {
        var congresses = await _repository.GetAllCongressesAsync();
        return congresses.Select(c => MapToResponseDto(c));
    }

    public async Task<CongressResponseDto?> GetCongressById(Guid id)
    {
        var congress = await _repository.GetCongressByIdAsync(id);
        if (congress == null)
            return null;

        return MapToResponseDto(congress);
    }

    public async Task<IEnumerable<CongressResponseDto>> GetCongressesByYear(int year)
    {
        var congresses = await _repository.GetCongressesByYearAsync(year);
        return congresses.Select(c => MapToResponseDto(c));
    }

    public async Task<IEnumerable<CongressResponseDto>> GetPublicCongresses()
    {
        var congresses = await _repository.GetPublicCongressesAsync();
        return congresses.Select(c => MapToResponseDto(c));
    }

    public async Task<IEnumerable<CongressResponseDto>> GetCongressesByEdition(int edition)
    {
        var congresses = await _repository.GetCongressesByEditionAsync(edition);
        return congresses.Select(c => MapToResponseDto(c));
    }

    public async Task<Guid> CreateCongress(CreateCongressDto dto)
    {
        var congress = new Congresses
        {
            Id = Guid.NewGuid(),
            Edition = dto.Edition,
            RomanNumber = dto.RomanNumber,
            Name = dto.Name,
            Year = dto.Year,
            Theme = dto.Theme,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate,
            Location = dto.Location,
            Venue = dto.Venue,
            HostUniversity = dto.HostUniversity,
            Description = dto.Description,
            Objectives = dto.Objectives,
            ParticipantsCount = dto.ParticipantsCount,
            PresentationsCount = dto.PresentationsCount,
            SpeakersCount = dto.SpeakersCount,
            BannerUrl = dto.BannerUrl,
            ProceedingsFileUrl = dto.ProceedingsFileUrl,
            AbstractsBookFileUrl = dto.AbstractsBookFileUrl,
            ProgramFileUrl = dto.ProgramFileUrl,
            WebsiteUrl = dto.WebsiteUrl,
            RegistrationUrl = dto.RegistrationUrl,
            PhotosAlbumUrl = dto.PhotosAlbumUrl,
            VideosPlaylistUrl = dto.VideosPlaylistUrl,
            IsPublic = dto.IsPublic,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            CreatedBy = dto.CreatedBy
        };

        await _repository.AddCongressAsync(congress);
        return congress.Id;
    }

    public async Task UpdateCongress(Guid id, UpdateCongressDto dto)
    {
        var congress = await _repository.GetCongressByIdAsync(id);
        if (congress == null)
            throw new Exception("Congreso no encontrado");

        congress.Edition = dto.Edition;
        congress.RomanNumber = dto.RomanNumber ?? congress.RomanNumber;
        congress.Name = dto.Name ?? congress.Name;
        congress.Year = dto.Year;
        congress.Theme = dto.Theme ?? congress.Theme;
        congress.StartDate = dto.StartDate;
        congress.EndDate = dto.EndDate;
        congress.Location = dto.Location ?? congress.Location;
        congress.Venue = dto.Venue ?? congress.Venue;
        congress.HostUniversity = dto.HostUniversity ?? congress.HostUniversity;
        congress.Description = dto.Description ?? congress.Description;
        congress.Objectives = dto.Objectives ?? congress.Objectives;
        congress.ParticipantsCount = dto.ParticipantsCount ?? congress.ParticipantsCount;
        congress.PresentationsCount = dto.PresentationsCount ?? congress.PresentationsCount;
        congress.SpeakersCount = dto.SpeakersCount ?? congress.SpeakersCount;
        congress.BannerUrl = dto.BannerUrl ?? congress.BannerUrl;
        congress.ProceedingsFileUrl = dto.ProceedingsFileUrl ?? congress.ProceedingsFileUrl;
        congress.AbstractsBookFileUrl = dto.AbstractsBookFileUrl ?? congress.AbstractsBookFileUrl;
        congress.ProgramFileUrl = dto.ProgramFileUrl ?? congress.ProgramFileUrl;
        congress.WebsiteUrl = dto.WebsiteUrl ?? congress.WebsiteUrl;
        congress.RegistrationUrl = dto.RegistrationUrl ?? congress.RegistrationUrl;
        congress.PhotosAlbumUrl = dto.PhotosAlbumUrl ?? congress.PhotosAlbumUrl;
        congress.VideosPlaylistUrl = dto.VideosPlaylistUrl ?? congress.VideosPlaylistUrl;
        congress.IsPublic = dto.IsPublic;
        congress.UpdatedAt = DateTime.UtcNow;

        await _repository.UpdateCongressAsync(congress);
    }

    public async Task DeleteCongress(Guid id)
    {
        await _repository.DeleteCongressAsync(id);
    }

    private CongressResponseDto MapToResponseDto(Congresses congress)
    {
        return new CongressResponseDto
        {
            Id = congress.Id,
            Edition = congress.Edition,
            RomanNumber = congress.RomanNumber,
            Name = congress.Name,
            Year = congress.Year,
            Theme = congress.Theme,
            StartDate = congress.StartDate,
            EndDate = congress.EndDate,
            Location = congress.Location,
            Venue = congress.Venue,
            HostUniversity = congress.HostUniversity,
            Description = congress.Description,
            Objectives = congress.Objectives,
            ParticipantsCount = congress.ParticipantsCount,
            PresentationsCount = congress.PresentationsCount,
            SpeakersCount = congress.SpeakersCount,
            BannerUrl = congress.BannerUrl,
            ProceedingsFileUrl = congress.ProceedingsFileUrl,
            AbstractsBookFileUrl = congress.AbstractsBookFileUrl,
            ProgramFileUrl = congress.ProgramFileUrl,
            WebsiteUrl = congress.WebsiteUrl,
            RegistrationUrl = congress.RegistrationUrl,
            PhotosAlbumUrl = congress.PhotosAlbumUrl,
            VideosPlaylistUrl = congress.VideosPlaylistUrl,
            IsPublic = congress.IsPublic,
            CreatedAt = congress.CreatedAt,
            UpdatedAt = congress.UpdatedAt
        };
    }
}
