using CMS_Riesgird.Core.Core.DTOs;

namespace CMS_Riesgird.Core.Core.Interfaces;

public interface ITechnicalTeamMemberService
{
    Task<IEnumerable<TechnicalTeamMemberResponseDto>> GetAllTechnicalTeamMembers();
    Task<IEnumerable<TechnicalTeamMemberResponseDto>> GetTechnicalTeamMembersByUniversityId(Guid universityId);
    Task<TechnicalTeamMemberResponseDto?> GetTechnicalTeamMemberById(Guid id);
    Task<Guid> CreateTechnicalTeamMember(CreateTechnicalTeamMemberDto dto);
    Task UpdateTechnicalTeamMember(Guid id, UpdateTechnicalTeamMemberDto dto);
    Task DeleteTechnicalTeamMember(Guid id);
}
