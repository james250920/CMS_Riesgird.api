using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Domain.Models;
using CMS_Riesgird.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CMS_Riesgird.Core.Infrastructure.Repositories;

public class AssemblyRepository : IAssemblyRepository
{
    private readonly RiesgirdDbContext _context;

    public AssemblyRepository(RiesgirdDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Assemblies>> GetAllAssembliesAsync()
    {
        return await _context.Assemblies.OrderByDescending(a => a.Date).ToListAsync();
    }

    public async Task<Assemblies?> GetAssemblyByIdAsync(Guid id)
    {
        return await _context.Assemblies.FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<IEnumerable<Assemblies>> GetAssembliesByYearAsync(int year)
    {
        return await _context.Assemblies
            .Where(a => a.Year == year)
            .OrderByDescending(a => a.Date)
            .ToListAsync();
    }

    public async Task<IEnumerable<Assemblies>> GetPublicAssembliesAsync()
    {
        return await _context.Assemblies
            .Where(a => a.IsPublic)
            .OrderByDescending(a => a.Date)
            .ToListAsync();
    }

    public async Task AddAssemblyAsync(Assemblies assembly)
    {
        _context.Assemblies.Add(assembly);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAssemblyAsync(Assemblies assembly)
    {
        _context.Assemblies.Update(assembly);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAssemblyAsync(Guid id)
    {
        var assembly = await _context.Assemblies.FindAsync(id);
        if (assembly != null)
        {
            _context.Assemblies.Remove(assembly);
            await _context.SaveChangesAsync();
        }
    }
}
