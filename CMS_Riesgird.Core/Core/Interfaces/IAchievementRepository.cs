using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Core.Interfaces;

public interface IAchievementRepository
{
    Task<IEnumerable<Achievements>> GetAllAchievementsAsync();
    Task<Achievements?> GetAchievementByIdAsync(Guid id);
    Task<IEnumerable<Achievements>> GetAchievementsByMemoryIdAsync(Guid memoryId);
    Task<IEnumerable<Achievements>> GetAchievementsByCategoryAsync(string category);
    Task AddAchievementAsync(Achievements achievement);
    Task UpdateAchievementAsync(Achievements achievement);
    Task DeleteAchievementAsync(Guid id);
}
