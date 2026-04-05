using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Core.Interfaces;

public interface IActivityRepository
{
    Task<IEnumerable<Activities>> GetAllActivitiesAsync();
    Task<Activities?> GetActivityByIdAsync(Guid id);
    Task<IEnumerable<Activities>> GetActivitiesByMemoryIdAsync(Guid memoryId);
    Task<IEnumerable<Activities>> GetActivitiesByDateRangeAsync(DateOnly startDate, DateOnly endDate);
    Task<IEnumerable<Activities>> GetActivitiesByLocationAsync(string location);
    Task AddActivityAsync(Activities activity);
    Task UpdateActivityAsync(Activities activity);
    Task DeleteActivityAsync(Guid id);
}
