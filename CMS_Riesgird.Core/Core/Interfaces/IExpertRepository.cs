using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Core.Interfaces;

public interface IExpertRepository
{
    Task<IEnumerable<Experts>> GetAllExpertsAsync();
    Task<Experts?> GetExpertByIdAsync(Guid id);
    Task<IEnumerable<Experts>> GetPublicExpertsAsync();
    Task<IEnumerable<Experts>> GetActiveExpertsAsync();
    Task<IEnumerable<Experts>> GetExpertsByExpertiseAreaAsync(string expertiseArea);
    Task<IEnumerable<Experts>> GetExpertsByCountryAsync(string country);
    Task<IEnumerable<Experts>> GetAvailableExpertsAsync();
    Task<IEnumerable<Experts>> GetExpertsAvailableForConsultingAsync();
    Task<IEnumerable<Experts>> GetExpertsAvailableForTrainingAsync();
    Task<IEnumerable<Experts>> GetExpertsAvailableForResearchAsync();
    Task AddExpertAsync(Experts expert);
    Task UpdateExpertAsync(Experts expert);
    Task DeleteExpertAsync(Guid id);
}
