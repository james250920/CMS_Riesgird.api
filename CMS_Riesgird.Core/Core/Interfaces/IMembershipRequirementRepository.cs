using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Core.Interfaces;

public interface IMembershipRequirementRepository
{
    Task<IEnumerable<MembershipRequirements>> GetAllRequirementsAsync();
    Task<MembershipRequirements?> GetRequirementByIdAsync(Guid id);
    Task<IEnumerable<MembershipRequirements>> GetActiveRequirementsAsync();
    Task<IEnumerable<MembershipRequirements>> GetRequiredRequirementsAsync();
    Task AddRequirementAsync(MembershipRequirements requirement);
    Task UpdateRequirementAsync(MembershipRequirements requirement);
    Task DeleteRequirementAsync(Guid id);
}
