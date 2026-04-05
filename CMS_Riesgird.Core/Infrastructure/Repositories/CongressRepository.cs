using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Domain.Models;
using CMS_Riesgird.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CMS_Riesgird.Core.Infrastructure.Repositories;

public class CongressRepository : ICongressRepository
{
    private readonly RiesgirdDbContext _context;

    public CongressRepository(RiesgirdDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Congresses>> GetAllCongressesAsync()
    {
        return await _context.Congresses
            .OrderByDescending(c => c.StartDate)
            .ToListAsync();
    }

    public async Task<Congresses?> GetCongressByIdAsync(Guid id)
    {
        return await _context.Congresses
            .Include(c => c.Speakers)
            .Include(c => c.ThematicAxes)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<IEnumerable<Congresses>> GetCongressesByYearAsync(int year)
    {
        return await _context.Congresses
            .Where(c => c.Year == year)
            .OrderByDescending(c => c.StartDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<Congresses>> GetPublicCongressesAsync()
    {
        return await _context.Congresses
            .Where(c => c.IsPublic)
            .OrderByDescending(c => c.StartDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<Congresses>> GetCongressesByEditionAsync(int edition)
    {
        return await _context.Congresses
            .Where(c => c.Edition == edition)
            .OrderByDescending(c => c.StartDate)
            .ToListAsync();
    }

    public async Task AddCongressAsync(Congresses congress)
    {
        _context.Congresses.Add(congress);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateCongressAsync(Congresses congress)
    {
        _context.Congresses.Update(congress);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCongressAsync(Guid id)
    {
        var congress = await _context.Congresses.FindAsync(id);
        if (congress != null)
        {
            _context.Congresses.Remove(congress);
            await _context.SaveChangesAsync();
        }
    }
}
