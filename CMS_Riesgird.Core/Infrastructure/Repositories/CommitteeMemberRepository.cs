using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Domain.Models;
using CMS_Riesgird.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CMS_Riesgird.Core.Infrastructure.Repositories;

public class CommitteeMemberRepository : ICommitteeMemberRepository
{
    private readonly RiesgirdDbContext _context;

    public CommitteeMemberRepository(RiesgirdDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CommitteeMembers>> GetAllMembersAsync()
    {
        return await _context.CommitteeMembers
            .Include(m => m.Congress)
            .OrderBy(m => m.SortOrder)
            .ThenBy(m => m.FullName)
            .ToListAsync();
    }

    public async Task<CommitteeMembers?> GetMemberByIdAsync(Guid id)
    {
        return await _context.CommitteeMembers
            .Include(m => m.Congress)
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<IEnumerable<CommitteeMembers>> GetMembersByCongressIdAsync(Guid congressId)
    {
        return await _context.CommitteeMembers
            .Where(m => m.CongressId == congressId)
            .OrderBy(m => m.SortOrder)
            .ThenBy(m => m.FullName)
            .ToListAsync();
    }

    public async Task<IEnumerable<CommitteeMembers>> GetMembersByRoleAsync(string role)
    {
        return await _context.CommitteeMembers
            .Where(m => m.Role == role)
            .OrderBy(m => m.SortOrder)
            .ThenBy(m => m.FullName)
            .ToListAsync();
    }

    public async Task AddMemberAsync(CommitteeMembers member)
    {
        _context.CommitteeMembers.Add(member);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateMemberAsync(CommitteeMembers member)
    {
        _context.CommitteeMembers.Update(member);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteMemberAsync(Guid id)
    {
        var member = await _context.CommitteeMembers.FindAsync(id);
        if (member != null)
        {
            _context.CommitteeMembers.Remove(member);
            await _context.SaveChangesAsync();
        }
    }
}
