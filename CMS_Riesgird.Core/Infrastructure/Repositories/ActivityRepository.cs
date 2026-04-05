using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Domain.Models;
using CMS_Riesgird.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CMS_Riesgird.Core.Infrastructure.Repositories;

public class ActivityRepository : IActivityRepository
{
    private readonly RiesgirdDbContext _context;

    public ActivityRepository(RiesgirdDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Activities>> GetAllActivitiesAsync()
    {
        return await _context.Activities
            .Include(a => a.Memory)
            .OrderByDescending(a => a.Date)
            .ThenBy(a => a.SortOrder)
            .ToListAsync();
    }

    public async Task<Activities?> GetActivityByIdAsync(Guid id)
    {
        return await _context.Activities
            .Include(a => a.Memory)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<IEnumerable<Activities>> GetActivitiesByMemoryIdAsync(Guid memoryId)
    {
        return await _context.Activities
            .Where(a => a.MemoryId == memoryId)
            .OrderByDescending(a => a.Date)
            .ThenBy(a => a.SortOrder)
            .ToListAsync();
    }

    public async Task<IEnumerable<Activities>> GetActivitiesByDateRangeAsync(DateOnly startDate, DateOnly endDate)
    {
        return await _context.Activities
            .Where(a => a.Date >= startDate && a.Date <= endDate)
            .OrderByDescending(a => a.Date)
            .ThenBy(a => a.SortOrder)
            .ToListAsync();
    }

    public async Task<IEnumerable<Activities>> GetActivitiesByLocationAsync(string location)
    {
        return await _context.Activities
            .Where(a => a.Location == location)
            .OrderByDescending(a => a.Date)
            .ThenBy(a => a.SortOrder)
            .ToListAsync();
    }

    public async Task AddActivityAsync(Activities activity)
    {
        _context.Activities.Add(activity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateActivityAsync(Activities activity)
    {
        _context.Activities.Update(activity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteActivityAsync(Guid id)
    {
        var activity = await _context.Activities.FindAsync(id);
        if (activity != null)
        {
            _context.Activities.Remove(activity);
            await _context.SaveChangesAsync();
        }
    }
}
