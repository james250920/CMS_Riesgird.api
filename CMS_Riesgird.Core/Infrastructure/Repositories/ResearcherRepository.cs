using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Domain.Models;
using CMS_Riesgird.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CMS_Riesgird.Core.Infrastructure.Repositories;

public class ResearcherRepository : IResearcherRepository
{
    private readonly RiesgirdDbContext _context;

    public ResearcherRepository(RiesgirdDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Researchers>> GetAllResearchersAsync()
    {
        return await _context.Researchers
            .Include(r => r.University)
            .OrderBy(r => r.FullName)
            .ToListAsync();
    }

    public async Task<Researchers?> GetResearcherByIdAsync(Guid id)
    {
        return await _context.Researchers
            .Include(r => r.University)
            .Include(r => r.Publications)
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<IEnumerable<Researchers>> GetResearchersByUniversityIdAsync(Guid universityId)
    {
        return await _context.Researchers
            .Where(r => r.UniversityId == universityId)
            .OrderBy(r => r.FullName)
            .ToListAsync();
    }

    public async Task<IEnumerable<Researchers>> GetPublicResearchersAsync()
    {
        return await _context.Researchers
            .Where(r => r.IsPublic)
            .Include(r => r.University)
            .OrderBy(r => r.FullName)
            .ToListAsync();
    }

    public async Task<IEnumerable<Researchers>> GetResearchersByResearchAreaAsync(string researchArea)
    {
        return await _context.Researchers
            .Where(r => r.ResearchAreas.Contains(researchArea))
            .Include(r => r.University)
            .OrderBy(r => r.FullName)
            .ToListAsync();
    }

    public async Task<IEnumerable<Researchers>> GetActiveResearchersAsync()
    {
        return await _context.Researchers
            .Where(r => r.IsActive)
            .Include(r => r.University)
            .OrderBy(r => r.FullName)
            .ToListAsync();
    }

    public async Task AddResearcherAsync(Researchers researcher)
    {
        _context.Researchers.Add(researcher);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateResearcherAsync(Researchers researcher)
    {
        _context.Researchers.Update(researcher);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteResearcherAsync(Guid id)
    {
        var researcher = await _context.Researchers.FindAsync(id);
        if (researcher != null)
        {
            _context.Researchers.Remove(researcher);
            await _context.SaveChangesAsync();
        }
    }
}
