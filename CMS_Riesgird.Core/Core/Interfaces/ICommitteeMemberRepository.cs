using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Core.Interfaces;

public interface ICommitteeMemberRepository
{
    Task<IEnumerable<CommitteeMembers>> GetAllMembersAsync();
    Task<CommitteeMembers?> GetMemberByIdAsync(Guid id);
    Task<IEnumerable<CommitteeMembers>> GetMembersByCongressIdAsync(Guid congressId);
    Task<IEnumerable<CommitteeMembers>> GetMembersByRoleAsync(string role);
    Task AddMemberAsync(CommitteeMembers member);
    Task UpdateMemberAsync(CommitteeMembers member);
    Task DeleteMemberAsync(Guid id);
}
