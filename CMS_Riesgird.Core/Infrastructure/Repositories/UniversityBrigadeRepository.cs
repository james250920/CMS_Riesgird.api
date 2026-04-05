using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Domain.Models;
using CMS_Riesgird.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CMS_Riesgird.Core.Infrastructure.Repositories;

public class UniversityBrigadeRepository : IUniversityBrigadeRepository
{
    private readonly RiesgirdDbContext _context;

    public UniversityBrigadeRepository(RiesgirdDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<UniversityBrigades>> GetAllUniversityBrigadesAsync()
    {
        return await _context.UniversityBrigades.ToListAsync();
    }

    public async Task<IEnumerable<UniversityBrigades>> GetUniversityBrigadesByUniversityIdAsync(Guid universityId)
    {
        return await _context.UniversityBrigades
            .Where(b => b.UniversityId == universityId)
            .ToListAsync();
    }

    public async Task<UniversityBrigades?> GetUniversityBrigadeByIdAsync(Guid id)
    {
        return await _context.UniversityBrigades.FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task AddUniversityBrigadeAsync(UniversityBrigades brigade)
    {
        _context.UniversityBrigades.Add(brigade);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateUniversityBrigadeAsync(UniversityBrigades brigade)
    {
        _context.UniversityBrigades.Update(brigade);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteUniversityBrigadeAsync(Guid id)
    {
        var brigade = await _context.UniversityBrigades.FindAsync(id);
        if (brigade != null)
        {
            _context.UniversityBrigades.Remove(brigade);
            await _context.SaveChangesAsync();
        }
    }
}
