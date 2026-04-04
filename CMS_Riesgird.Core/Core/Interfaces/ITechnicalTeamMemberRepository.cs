using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Core.Interfaces;

public interface ITechnicalTeamMemberRepository
{
    Task<IEnumerable<TechnicalTeamMembers>> GetAllTechnicalTeamMembersAsync();
    Task<IEnumerable<TechnicalTeamMembers>> GetTechnicalTeamMembersByUniversityIdAsync(Guid universityId);
    Task<TechnicalTeamMembers?> GetTechnicalTeamMemberByIdAsync(Guid id);
    Task AddTechnicalTeamMemberAsync(TechnicalTeamMembers member);
    Task UpdateTechnicalTeamMemberAsync(TechnicalTeamMembers member);
    Task DeleteTechnicalTeamMemberAsync(Guid id);
}
