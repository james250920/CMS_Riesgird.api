using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Core.Interfaces;

public interface IResearcherRepository
{
    Task<IEnumerable<Researchers>> GetAllResearchersAsync();
    Task<Researchers?> GetResearcherByIdAsync(Guid id);
    Task<IEnumerable<Researchers>> GetResearchersByUniversityIdAsync(Guid universityId);
    Task<IEnumerable<Researchers>> GetPublicResearchersAsync();
    Task<IEnumerable<Researchers>> GetResearchersByResearchAreaAsync(string researchArea);
    Task<IEnumerable<Researchers>> GetActiveResearchersAsync();
    Task AddResearcherAsync(Researchers researcher);
    Task UpdateResearcherAsync(Researchers researcher);
    Task DeleteResearcherAsync(Guid id);
}
