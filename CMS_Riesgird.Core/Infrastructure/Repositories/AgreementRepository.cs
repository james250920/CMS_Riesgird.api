using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Domain.Models;
using CMS_Riesgird.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CMS_Riesgird.Core.Infrastructure.Repositories;

public class AgreementRepository : IAgreementRepository
{
    private readonly RiesgirdDbContext _context;

    public AgreementRepository(RiesgirdDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Agreements>> GetAllAgreementsAsync()
    {
        return await _context.Agreements
            .Include(a => a.Assembly)
            .OrderByDescending(a => a.DueDate)
            .ToListAsync();
    }

    public async Task<Agreements?> GetAgreementByIdAsync(Guid id)
    {
        return await _context.Agreements
            .Include(a => a.Assembly)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<IEnumerable<Agreements>> GetAgreementsByAssemblyIdAsync(Guid assemblyId)
    {
        return await _context.Agreements
            .Where(a => a.AssemblyId == assemblyId)
            .OrderByDescending(a => a.DueDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<Agreements>> GetPublicAgreementsAsync()
    {
        return await _context.Agreements
            .Where(a => a.IsPublic)
            .Include(a => a.Assembly)
            .OrderByDescending(a => a.DueDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<Agreements>> GetAgreementsWithDueDateAsync()
    {
        return await _context.Agreements
            .Where(a => a.DueDate.HasValue)
            .Include(a => a.Assembly)
            .OrderBy(a => a.DueDate)
            .ToListAsync();
    }

    public async Task AddAgreementAsync(Agreements agreement)
    {
        _context.Agreements.Add(agreement);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAgreementAsync(Agreements agreement)
    {
        _context.Agreements.Update(agreement);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAgreementAsync(Guid id)
    {
        var agreement = await _context.Agreements.FindAsync(id);
        if (agreement != null)
        {
            _context.Agreements.Remove(agreement);
            await _context.SaveChangesAsync();
        }
    }
}
