using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Domain.Models;
using CMS_Riesgird.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CMS_Riesgird.Core.Infrastructure.Repositories;

public class ApplicationStatusHistoryRepository : IApplicationStatusHistoryRepository
{
    private readonly RiesgirdDbContext _context;

    public ApplicationStatusHistoryRepository(RiesgirdDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ApplicationStatusHistory>> GetAllHistoriesAsync()
    {
        return await _context.ApplicationStatusHistory
            .OrderByDescending(h => h.ChangedAt)
            .ToListAsync();
    }

    public async Task<ApplicationStatusHistory?> GetHistoryByIdAsync(Guid id)
    {
        return await _context.ApplicationStatusHistory
            .Include(h => h.ChangedByNavigation)
            .FirstOrDefaultAsync(h => h.Id == id);
    }

    public async Task<IEnumerable<ApplicationStatusHistory>> GetHistoriesByApplicationIdAsync(Guid applicationId)
    {
        return await _context.ApplicationStatusHistory
            .Where(h => h.ApplicationId == applicationId)
            .OrderByDescending(h => h.ChangedAt)
            .ToListAsync();
    }

    public async Task<IEnumerable<ApplicationStatusHistory>> GetHistoriesByStatusAsync(string status)
    {
        return await _context.ApplicationStatusHistory
            .Where(h => h.Status == status)
            .OrderByDescending(h => h.ChangedAt)
            .ToListAsync();
    }

    public async Task AddHistoryAsync(ApplicationStatusHistory history)
    {
        _context.ApplicationStatusHistory.Add(history);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateHistoryAsync(ApplicationStatusHistory history)
    {
        _context.ApplicationStatusHistory.Update(history);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteHistoryAsync(Guid id)
    {
        var history = await _context.ApplicationStatusHistory.FindAsync(id);
        if (history != null)
        {
            _context.ApplicationStatusHistory.Remove(history);
            await _context.SaveChangesAsync();
        }
    }
}
