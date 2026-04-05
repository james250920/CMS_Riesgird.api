using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Core.Interfaces;

public interface IApplicationStatusHistoryRepository
{
    Task<IEnumerable<ApplicationStatusHistory>> GetAllHistoriesAsync();
    Task<ApplicationStatusHistory?> GetHistoryByIdAsync(Guid id);
    Task<IEnumerable<ApplicationStatusHistory>> GetHistoriesByApplicationIdAsync(Guid applicationId);
    Task<IEnumerable<ApplicationStatusHistory>> GetHistoriesByStatusAsync(string status);
    Task AddHistoryAsync(ApplicationStatusHistory history);
    Task UpdateHistoryAsync(ApplicationStatusHistory history);
    Task DeleteHistoryAsync(Guid id);
}
