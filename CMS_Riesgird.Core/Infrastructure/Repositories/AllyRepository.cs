using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Domain.Models;
using CMS_Riesgird.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CMS_Riesgird.Core.Infrastructure.Repositories;

public class AllyRepository : IAllyRepository
{
    private readonly RiesgirdDbContext _context;

    public AllyRepository(RiesgirdDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Allies>> GetAllAlliesAsync()
    {
        return await _context.Allies
            .OrderBy(a => a.SortOrder)
            .ThenBy(a => a.Name)
            .ToListAsync();
    }

    public async Task<Allies?> GetAllyByIdAsync(Guid id)
    {
        return await _context.Allies.FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<IEnumerable<Allies>> GetPublicAlliesAsync()
    {
        return await _context.Allies
            .Where(a => a.IsPublic)
            .OrderBy(a => a.SortOrder)
            .ThenBy(a => a.Name)
            .ToListAsync();
    }

    public async Task<IEnumerable<Allies>> GetActiveAlliesAsync()
    {
        return await _context.Allies
            .Where(a => a.IsActive)
            .OrderBy(a => a.SortOrder)
            .ThenBy(a => a.Name)
            .ToListAsync();
    }

    public async Task AddAllyAsync(Allies ally)
    {
        _context.Allies.Add(ally);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAllyAsync(Allies ally)
    {
        _context.Allies.Update(ally);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAllyAsync(Guid id)
    {
        var ally = await _context.Allies.FindAsync(id);
        if (ally != null)
        {
            _context.Allies.Remove(ally);
            await _context.SaveChangesAsync();
        }
    }
}
