using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Domain.Models;
using CMS_Riesgird.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CMS_Riesgird.Core.Infrastructure.Repositories;

public class ManagementMemoryRepository : IManagementMemoryRepository
{
    private readonly RiesgirdDbContext _context;

    public ManagementMemoryRepository(RiesgirdDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ManagementMemories>> GetAllMemoriesAsync()
    {
        return await _context.ManagementMemories
            .OrderByDescending(m => m.Year)
            .ThenByDescending(m => m.PublishedAt)
            .ToListAsync();
    }

    public async Task<ManagementMemories?> GetMemoryByIdAsync(Guid id)
    {
        return await _context.ManagementMemories
            .Include(m => m.Achievements)
            .Include(m => m.Activities)
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<IEnumerable<ManagementMemories>> GetPublicMemoriesAsync()
    {
        return await _context.ManagementMemories
            .Where(m => m.IsPublic)
            .OrderByDescending(m => m.Year)
            .ThenByDescending(m => m.PublishedAt)
            .ToListAsync();
    }

    public async Task<IEnumerable<ManagementMemories>> GetMemoriesByYearAsync(int year)
    {
        return await _context.ManagementMemories
            .Where(m => m.Year == year)
            .OrderByDescending(m => m.PublishedAt)
            .ToListAsync();
    }

    public async Task<IEnumerable<ManagementMemories>> GetMemoriesByPeriodAsync(string period)
    {
        return await _context.ManagementMemories
            .Where(m => m.Period == period)
            .OrderByDescending(m => m.Year)
            .ToListAsync();
    }

    public async Task<ManagementMemories?> GetLatestMemoryAsync()
    {
        return await _context.ManagementMemories
            .OrderByDescending(m => m.Year)
            .ThenByDescending(m => m.PublishedAt)
            .FirstOrDefaultAsync();
    }

    public async Task AddMemoryAsync(ManagementMemories memory)
    {
        _context.ManagementMemories.Add(memory);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateMemoryAsync(ManagementMemories memory)
    {
        _context.ManagementMemories.Update(memory);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteMemoryAsync(Guid id)
    {
        var memory = await _context.ManagementMemories.FindAsync(id);
        if (memory != null)
        {
            _context.ManagementMemories.Remove(memory);
            await _context.SaveChangesAsync();
        }
    }
}
