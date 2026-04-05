using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Core.Services;

public class PublicationService : IPublicationService
{
    private readonly IPublicationRepository _repository;

    public PublicationService(IPublicationRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<PublicationResponseDto>> GetAllPublications()
    {
        var publications = await _repository.GetAllPublicationsAsync();
        return publications.Select(p => MapToResponseDto(p));
    }

    public async Task<PublicationResponseDto?> GetPublicationById(Guid id)
    {
        var publication = await _repository.GetPublicationByIdAsync(id);
        if (publication == null)
            return null;

        return MapToResponseDto(publication);
    }

    public async Task<IEnumerable<PublicationResponseDto>> GetPublicationsByResearcherId(Guid researcherId)
    {
        var publications = await _repository.GetPublicationsByResearcherIdAsync(researcherId);
        return publications.Select(p => MapToResponseDto(p));
    }

    public async Task<IEnumerable<PublicationResponseDto>> GetPublicPublications()
    {
        var publications = await _repository.GetPublicationsAsync();
        return publications.Select(p => MapToResponseDto(p));
    }

    public async Task<IEnumerable<PublicationResponseDto>> GetPublicationsByYear(int year)
    {
        var publications = await _repository.GetPublicationsByYearAsync(year);
        return publications.Select(p => MapToResponseDto(p));
    }

    public async Task<IEnumerable<PublicationResponseDto>> GetPublicationsByJournal(string journal)
    {
        var publications = await _repository.GetPublicationsByJournalAsync(journal);
        return publications.Select(p => MapToResponseDto(p));
    }

    public async Task<IEnumerable<PublicationResponseDto>> GetPublicationsByKeyword(string keyword)
    {
        var publications = await _repository.GetPublicationsByKeywordAsync(keyword);
        return publications.Select(p => MapToResponseDto(p));
    }

    public async Task<Guid> CreatePublication(CreatePublicationDto dto)
    {
        var publication = new Publications
        {
            Id = Guid.NewGuid(),
            ResearcherId = dto.ResearcherId,
            Title = dto.Title,
            Authors = dto.Authors,
            Year = dto.Year,
            Journal = dto.Journal,
            Volume = dto.Volume,
            Pages = dto.Pages,
            Doi = dto.Doi,
            Url = dto.Url,
            FileUrl = dto.FileUrl,
            Abstract = dto.Abstract,
            Keywords = dto.Keywords,
            IsPublic = dto.IsPublic,
            CreatedAt = DateTime.UtcNow
        };

        await _repository.AddPublicationAsync(publication);
        return publication.Id;
    }

    public async Task UpdatePublication(Guid id, UpdatePublicationDto dto)
    {
        var publication = await _repository.GetPublicationByIdAsync(id);
        if (publication == null)
            throw new Exception("Publicación no encontrada");

        publication.ResearcherId = dto.ResearcherId;
        publication.Title = dto.Title ?? publication.Title;
        publication.Authors = dto.Authors ?? publication.Authors;
        publication.Year = dto.Year;
        publication.Journal = dto.Journal ?? publication.Journal;
        publication.Volume = dto.Volume ?? publication.Volume;
        publication.Pages = dto.Pages ?? publication.Pages;
        publication.Doi = dto.Doi ?? publication.Doi;
        publication.Url = dto.Url ?? publication.Url;
        publication.FileUrl = dto.FileUrl ?? publication.FileUrl;
        publication.Abstract = dto.Abstract ?? publication.Abstract;
        publication.Keywords = dto.Keywords ?? publication.Keywords;
        publication.IsPublic = dto.IsPublic;

        await _repository.UpdatePublicationAsync(publication);
    }

    public async Task DeletePublication(Guid id)
    {
        await _repository.DeletePublicationAsync(id);
    }

    private PublicationResponseDto MapToResponseDto(Publications publication)
    {
        return new PublicationResponseDto
        {
            Id = publication.Id,
            ResearcherId = publication.ResearcherId,
            Title = publication.Title,
            Authors = publication.Authors,
            Year = publication.Year,
            Journal = publication.Journal,
            Volume = publication.Volume,
            Pages = publication.Pages,
            Doi = publication.Doi,
            Url = publication.Url,
            FileUrl = publication.FileUrl,
            Abstract = publication.Abstract,
            Keywords = publication.Keywords,
            IsPublic = publication.IsPublic,
            CreatedAt = publication.CreatedAt
        };
    }
}
