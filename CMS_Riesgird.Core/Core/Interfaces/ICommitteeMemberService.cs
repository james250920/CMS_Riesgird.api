using CMS_Riesgird.Core.Core.DTOs;

namespace CMS_Riesgird.Core.Core.Interfaces;

public interface ICommitteeMemberService
{
    Task<IEnumerable<CommitteeMemberResponseDto>> GetAllMembers();
    Task<CommitteeMemberResponseDto?> GetMemberById(Guid id);
    Task<IEnumerable<CommitteeMemberResponseDto>> GetMembersByCongressId(Guid congressId);
    Task<IEnumerable<CommitteeMemberResponseDto>> GetMembersByRole(string role);
    Task<Guid> CreateMember(CreateCommitteeMemberDto dto);
    Task UpdateMember(Guid id, UpdateCommitteeMemberDto dto);
    Task DeleteMember(Guid id);
}
