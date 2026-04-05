using CMS_Riesgird.Core.Core.DTOs;

namespace CMS_Riesgird.Core.Core.Interfaces;

public interface IAchievementService
{
    Task<IEnumerable<AchievementResponseDto>> GetAllAchievements();
    Task<AchievementResponseDto?> GetAchievementById(Guid id);
    Task<IEnumerable<AchievementResponseDto>> GetAchievementsByMemoryId(Guid memoryId);
    Task<IEnumerable<AchievementResponseDto>> GetAchievementsByCategory(string category);
    Task<Guid> CreateAchievement(CreateAchievementDto dto);
    Task UpdateAchievement(Guid id, UpdateAchievementDto dto);
    Task DeleteAchievement(Guid id);
}
