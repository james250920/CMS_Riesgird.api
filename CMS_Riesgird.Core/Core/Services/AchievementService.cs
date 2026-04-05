using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Core.Services;

public class AchievementService : IAchievementService
{
    private readonly IAchievementRepository _repository;

    public AchievementService(IAchievementRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<AchievementResponseDto>> GetAllAchievements()
    {
        var achievements = await _repository.GetAllAchievementsAsync();
        return achievements.Select(a => MapToResponseDto(a));
    }

    public async Task<AchievementResponseDto?> GetAchievementById(Guid id)
    {
        var achievement = await _repository.GetAchievementByIdAsync(id);
        if (achievement == null)
            return null;

        return MapToResponseDto(achievement);
    }

    public async Task<IEnumerable<AchievementResponseDto>> GetAchievementsByMemoryId(Guid memoryId)
    {
        var achievements = await _repository.GetAchievementsByMemoryIdAsync(memoryId);
        return achievements.Select(a => MapToResponseDto(a));
    }

    public async Task<IEnumerable<AchievementResponseDto>> GetAchievementsByCategory(string category)
    {
        var achievements = await _repository.GetAchievementsByCategoryAsync(category);
        return achievements.Select(a => MapToResponseDto(a));
    }

    public async Task<Guid> CreateAchievement(CreateAchievementDto dto)
    {
        var achievement = new Achievements
        {
            Id = Guid.NewGuid(),
            MemoryId = dto.MemoryId,
            Title = dto.Title,
            Description = dto.Description,
            Category = dto.Category,
            Date = dto.Date,
            EvidenceUrl = dto.EvidenceUrl,
            SortOrder = dto.SortOrder
        };

        await _repository.AddAchievementAsync(achievement);
        return achievement.Id;
    }

    public async Task UpdateAchievement(Guid id, UpdateAchievementDto dto)
    {
        var achievement = await _repository.GetAchievementByIdAsync(id);
        if (achievement == null)
            throw new Exception("Logro no encontrado");

        achievement.MemoryId = dto.MemoryId;
        achievement.Title = dto.Title ?? achievement.Title;
        achievement.Description = dto.Description ?? achievement.Description;
        achievement.Category = dto.Category ?? achievement.Category;
        achievement.Date = dto.Date ?? achievement.Date;
        achievement.EvidenceUrl = dto.EvidenceUrl ?? achievement.EvidenceUrl;
        achievement.SortOrder = dto.SortOrder;

        await _repository.UpdateAchievementAsync(achievement);
    }

    public async Task DeleteAchievement(Guid id)
    {
        await _repository.DeleteAchievementAsync(id);
    }

    private AchievementResponseDto MapToResponseDto(Achievements achievement)
    {
        return new AchievementResponseDto
        {
            Id = achievement.Id,
            MemoryId = achievement.MemoryId,
            Title = achievement.Title,
            Description = achievement.Description,
            Category = achievement.Category,
            Date = achievement.Date,
            EvidenceUrl = achievement.EvidenceUrl,
            SortOrder = achievement.SortOrder
        };
    }
}
