using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Domain.Models;
using CMS_Riesgird.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CMS_Riesgird.Core.Infrastructure.Repositories;

public class MembershipRequirementRepository : IMembershipRequirementRepository
{
    private readonly RiesgirdDbContext _context;

    public MembershipRequirementRepository(RiesgirdDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<MembershipRequirements>> GetAllRequirementsAsync()
    {
        return await _context.MembershipRequirements
            .OrderBy(r => r.SortOrder)
            .ToListAsync();
    }

    public async Task<MembershipRequirements?> GetRequirementByIdAsync(Guid id)
    {
        return await _context.MembershipRequirements.FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<IEnumerable<MembershipRequirements>> GetActiveRequirementsAsync()
    {
        return await _context.MembershipRequirements
            .Where(r => r.IsActive)
            .OrderBy(r => r.SortOrder)
            .ToListAsync();
    }

    public async Task<IEnumerable<MembershipRequirements>> GetRequiredRequirementsAsync()
    {
        return await _context.MembershipRequirements
            .Where(r => r.IsRequired)
            .OrderBy(r => r.SortOrder)
            .ToListAsync();
    }

    public async Task AddRequirementAsync(MembershipRequirements requirement)
    {
        _context.MembershipRequirements.Add(requirement);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateRequirementAsync(MembershipRequirements requirement)
    {
        _context.MembershipRequirements.Update(requirement);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteRequirementAsync(Guid id)
    {
        var requirement = await _context.MembershipRequirements.FindAsync(id);
        if (requirement != null)
        {
            _context.MembershipRequirements.Remove(requirement);
            await _context.SaveChangesAsync();
        }
    }
}
