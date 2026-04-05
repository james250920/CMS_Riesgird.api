using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Domain.Models;
using CMS_Riesgird.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CMS_Riesgird.Core.Infrastructure.Repositories;

public class AchievementRepository : IAchievementRepository
{
    private readonly RiesgirdDbContext _context;

    public AchievementRepository(RiesgirdDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Achievements>> GetAllAchievementsAsync()
    {
        return await _context.Achievements
            .Include(a => a.Memory)
            .OrderBy(a => a.SortOrder)
            .ThenBy(a => a.Title)
            .ToListAsync();
    }

    public async Task<Achievements?> GetAchievementByIdAsync(Guid id)
    {
        return await _context.Achievements
            .Include(a => a.Memory)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<IEnumerable<Achievements>> GetAchievementsByMemoryIdAsync(Guid memoryId)
    {
        return await _context.Achievements
            .Where(a => a.MemoryId == memoryId)
            .OrderBy(a => a.SortOrder)
            .ThenBy(a => a.Title)
            .ToListAsync();
    }

    public async Task<IEnumerable<Achievements>> GetAchievementsByCategoryAsync(string category)
    {
        return await _context.Achievements
            .Where(a => a.Category == category)
            .OrderBy(a => a.SortOrder)
            .ThenBy(a => a.Title)
            .ToListAsync();
    }

    public async Task AddAchievementAsync(Achievements achievement)
    {
        _context.Achievements.Add(achievement);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAchievementAsync(Achievements achievement)
    {
        _context.Achievements.Update(achievement);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAchievementAsync(Guid id)
    {
        var achievement = await _context.Achievements.FindAsync(id);
        if (achievement != null)
        {
            _context.Achievements.Remove(achievement);
            await _context.SaveChangesAsync();
        }
    }
}
