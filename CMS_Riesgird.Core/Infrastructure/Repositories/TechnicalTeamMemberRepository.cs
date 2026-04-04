using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Domain.Models;
using CMS_Riesgird.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CMS_Riesgird.Core.Infrastructure.Repositories;

public class TechnicalTeamMemberRepository : ITechnicalTeamMemberRepository
{
    private readonly RiesgirdDbContext _context;

    public TechnicalTeamMemberRepository(RiesgirdDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TechnicalTeamMembers>> GetAllTechnicalTeamMembersAsync()
    {
        return await _context.TechnicalTeamMembers.ToListAsync();
    }

    public async Task<IEnumerable<TechnicalTeamMembers>> GetTechnicalTeamMembersByUniversityIdAsync(Guid universityId)
    {
        return await _context.TechnicalTeamMembers
            .Where(m => m.UniversityId == universityId)
            .ToListAsync();
    }

    public async Task<TechnicalTeamMembers?> GetTechnicalTeamMemberByIdAsync(Guid id)
    {
        return await _context.TechnicalTeamMembers.FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task AddTechnicalTeamMemberAsync(TechnicalTeamMembers member)
    {
        _context.TechnicalTeamMembers.Add(member);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateTechnicalTeamMemberAsync(TechnicalTeamMembers member)
    {
        _context.TechnicalTeamMembers.Update(member);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteTechnicalTeamMemberAsync(Guid id)
    {
        var member = await _context.TechnicalTeamMembers.FindAsync(id);
        if (member != null)
        {
            _context.TechnicalTeamMembers.Remove(member);
            await _context.SaveChangesAsync();
        }
    }
}
