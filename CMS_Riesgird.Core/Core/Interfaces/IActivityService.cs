using CMS_Riesgird.Core.Core.DTOs;

namespace CMS_Riesgird.Core.Core.Interfaces;

public interface IActivityService
{
    Task<IEnumerable<ActivityResponseDto>> GetAllActivities();
    Task<ActivityResponseDto?> GetActivityById(Guid id);
    Task<IEnumerable<ActivityResponseDto>> GetActivitiesByMemoryId(Guid memoryId);
    Task<IEnumerable<ActivityResponseDto>> GetActivitiesByDateRange(DateOnly startDate, DateOnly endDate);
    Task<IEnumerable<ActivityResponseDto>> GetActivitiesByLocation(string location);
    Task<Guid> CreateActivity(CreateActivityDto dto);
    Task UpdateActivity(Guid id, UpdateActivityDto dto);
    Task DeleteActivity(Guid id);
}
