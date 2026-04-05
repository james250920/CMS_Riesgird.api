using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Core.Services;

public class SpeakerService : ISpeakerService
{
    private readonly ISpeakerRepository _repository;

    public SpeakerService(ISpeakerRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<SpeakerResponseDto>> GetAllSpeakers()
    {
        var speakers = await _repository.GetAllSpeakersAsync();
        return speakers.Select(s => MapToResponseDto(s));
    }

    public async Task<SpeakerResponseDto?> GetSpeakerById(Guid id)
    {
        var speaker = await _repository.GetSpeakerByIdAsync(id);
        if (speaker == null)
            return null;

        return MapToResponseDto(speaker);
    }

    public async Task<IEnumerable<SpeakerResponseDto>> GetSpeakersByCongressId(Guid congressId)
    {
        var speakers = await _repository.GetSpeakersByCongressIdAsync(congressId);
        return speakers.Select(s => MapToResponseDto(s));
    }

    public async Task<IEnumerable<SpeakerResponseDto>> GetSpeakersByCountry(string country)
    {
        var speakers = await _repository.GetSpeakersByCountryAsync(country);
        return speakers.Select(s => MapToResponseDto(s));
    }

    public async Task<IEnumerable<SpeakerResponseDto>> GetSpeakersByInstitution(string institution)
    {
        var speakers = await _repository.GetSpeakersByInstitutionAsync(institution);
        return speakers.Select(s => MapToResponseDto(s));
    }

    public async Task<Guid> CreateSpeaker(CreateSpeakerDto dto)
    {
        var speaker = new Speakers
        {
            Id = Guid.NewGuid(),
            CongressId = dto.CongressId,
            FullName = dto.FullName,
            Title = dto.Title,
            Institution = dto.Institution,
            Country = dto.Country,
            PhotoUrl = dto.PhotoUrl,
            Biography = dto.Biography,
            PresentationTitle = dto.PresentationTitle
        };

        await _repository.AddSpeakerAsync(speaker);
        return speaker.Id;
    }

    public async Task UpdateSpeaker(Guid id, UpdateSpeakerDto dto)
    {
        var speaker = await _repository.GetSpeakerByIdAsync(id);
        if (speaker == null)
            throw new Exception("Ponente no encontrado");

        speaker.CongressId = dto.CongressId;
        speaker.FullName = dto.FullName ?? speaker.FullName;
        speaker.Title = dto.Title ?? speaker.Title;
        speaker.Institution = dto.Institution ?? speaker.Institution;
        speaker.Country = dto.Country ?? speaker.Country;
        speaker.PhotoUrl = dto.PhotoUrl ?? speaker.PhotoUrl;
        speaker.Biography = dto.Biography ?? speaker.Biography;
        speaker.PresentationTitle = dto.PresentationTitle ?? speaker.PresentationTitle;

        await _repository.UpdateSpeakerAsync(speaker);
    }

    public async Task DeleteSpeaker(Guid id)
    {
        await _repository.DeleteSpeakerAsync(id);
    }

    private SpeakerResponseDto MapToResponseDto(Speakers speaker)
    {
        return new SpeakerResponseDto
        {
            Id = speaker.Id,
            CongressId = speaker.CongressId,
            FullName = speaker.FullName,
            Title = speaker.Title,
            Institution = speaker.Institution,
            Country = speaker.Country,
            PhotoUrl = speaker.PhotoUrl,
            Biography = speaker.Biography,
            PresentationTitle = speaker.PresentationTitle
        };
    }
}
