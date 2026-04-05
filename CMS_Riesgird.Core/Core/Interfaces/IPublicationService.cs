using CMS_Riesgird.Core.Core.DTOs;

namespace CMS_Riesgird.Core.Core.Interfaces;

public interface IPublicationService
{
    Task<IEnumerable<PublicationResponseDto>> GetAllPublications();
    Task<PublicationResponseDto?> GetPublicationById(Guid id);
    Task<IEnumerable<PublicationResponseDto>> GetPublicationsByResearcherId(Guid researcherId);
    Task<IEnumerable<PublicationResponseDto>> GetPublicPublications();
    Task<IEnumerable<PublicationResponseDto>> GetPublicationsByYear(int year);
    Task<IEnumerable<PublicationResponseDto>> GetPublicationsByJournal(string journal);
    Task<IEnumerable<PublicationResponseDto>> GetPublicationsByKeyword(string keyword);
    Task<Guid> CreatePublication(CreatePublicationDto dto);
    Task UpdatePublication(Guid id, UpdatePublicationDto dto);
    Task DeletePublication(Guid id);
}
