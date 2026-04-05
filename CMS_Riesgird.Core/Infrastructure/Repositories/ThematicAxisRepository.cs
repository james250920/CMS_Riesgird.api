using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Domain.Models;
using CMS_Riesgird.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CMS_Riesgird.Core.Infrastructure.Repositories;

public class ThematicAxisRepository : IThematicAxisRepository
{
    private readonly RiesgirdDbContext _context;

    public ThematicAxisRepository(RiesgirdDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ThematicAxes>> GetAllAxesAsync()
    {
        return await _context.ThematicAxes
            .Include(a => a.Congress)
            .OrderBy(a => a.SortOrder)
            .ThenBy(a => a.Name)
            .ToListAsync();
    }

    public async Task<ThematicAxes?> GetAxisByIdAsync(Guid id)
    {
        return await _context.ThematicAxes
            .Include(a => a.Congress)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<IEnumerable<ThematicAxes>> GetAxesByCongressIdAsync(Guid congressId)
    {
        return await _context.ThematicAxes
            .Where(a => a.CongressId == congressId)
            .OrderBy(a => a.SortOrder)
            .ThenBy(a => a.Name)
            .ToListAsync();
    }

    public async Task AddAxisAsync(ThematicAxes axis)
    {
        _context.ThematicAxes.Add(axis);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAxisAsync(ThematicAxes axis)
    {
        _context.ThematicAxes.Update(axis);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAxisAsync(Guid id)
    {
        var axis = await _context.ThematicAxes.FindAsync(id);
        if (axis != null)
        {
            _context.ThematicAxes.Remove(axis);
            await _context.SaveChangesAsync();
        }
    }
}
