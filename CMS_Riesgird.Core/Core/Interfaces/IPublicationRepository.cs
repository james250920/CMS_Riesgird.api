using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Core.Interfaces;

public interface IPublicationRepository
{
    Task<IEnumerable<Publications>> GetAllPublicationsAsync();
    Task<Publications?> GetPublicationByIdAsync(Guid id);
    Task<IEnumerable<Publications>> GetPublicationsByResearcherIdAsync(Guid researcherId);
    Task<IEnumerable<Publications>> GetPublicationsAsync();
    Task<IEnumerable<Publications>> GetPublicationsByYearAsync(int year);
    Task<IEnumerable<Publications>> GetPublicationsByJournalAsync(string journal);
    Task<IEnumerable<Publications>> GetPublicationsByKeywordAsync(string keyword);
    Task AddPublicationAsync(Publications publication);
    Task UpdatePublicationAsync(Publications publication);
    Task DeletePublicationAsync(Guid id);
}
