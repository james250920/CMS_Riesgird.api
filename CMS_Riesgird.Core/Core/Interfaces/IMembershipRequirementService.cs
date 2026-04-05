using CMS_Riesgird.Core.Core.DTOs;

namespace CMS_Riesgird.Core.Core.Interfaces;

public interface IMembershipRequirementService
{
    Task<IEnumerable<MembershipRequirementResponseDto>> GetAllRequirements();
    Task<MembershipRequirementResponseDto?> GetRequirementById(Guid id);
    Task<IEnumerable<MembershipRequirementResponseDto>> GetActiveRequirements();
    Task<IEnumerable<MembershipRequirementResponseDto>> GetRequiredRequirements();
    Task<Guid> CreateRequirement(CreateMembershipRequirementDto dto);
    Task UpdateRequirement(Guid id, UpdateMembershipRequirementDto dto);
    Task DeleteRequirement(Guid id);
}
