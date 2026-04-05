using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Core.Services;

public class MembershipRequirementService : IMembershipRequirementService
{
    private readonly IMembershipRequirementRepository _repository;

    public MembershipRequirementService(IMembershipRequirementRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<MembershipRequirementResponseDto>> GetAllRequirements()
    {
        var requirements = await _repository.GetAllRequirementsAsync();
        return requirements.Select(r => MapToResponseDto(r));
    }

    public async Task<MembershipRequirementResponseDto?> GetRequirementById(Guid id)
    {
        var requirement = await _repository.GetRequirementByIdAsync(id);
        if (requirement == null)
            return null;

        return MapToResponseDto(requirement);
    }

    public async Task<IEnumerable<MembershipRequirementResponseDto>> GetActiveRequirements()
    {
        var requirements = await _repository.GetActiveRequirementsAsync();
        return requirements.Select(r => MapToResponseDto(r));
    }

    public async Task<IEnumerable<MembershipRequirementResponseDto>> GetRequiredRequirements()
    {
        var requirements = await _repository.GetRequiredRequirementsAsync();
        return requirements.Select(r => MapToResponseDto(r));
    }

    public async Task<Guid> CreateRequirement(CreateMembershipRequirementDto dto)
    {
        var requirement = new MembershipRequirements
        {
            Id = Guid.NewGuid(),
            SortOrder = dto.SortOrder,
            Title = dto.Title,
            Description = dto.Description,
            DocumentFormat = dto.DocumentFormat,
            MaxFileSize = dto.MaxFileSize,
            IsRequired = dto.IsRequired,
            IsActive = dto.IsActive
        };

        await _repository.AddRequirementAsync(requirement);
        return requirement.Id;
    }

    public async Task UpdateRequirement(Guid id, UpdateMembershipRequirementDto dto)
    {
        var requirement = await _repository.GetRequirementByIdAsync(id);
        if (requirement == null)
            throw new Exception("Requisito de membresía no encontrado");

        requirement.SortOrder = dto.SortOrder;
        requirement.Title = dto.Title ?? requirement.Title;
        requirement.Description = dto.Description ?? requirement.Description;
        requirement.DocumentFormat = dto.DocumentFormat ?? requirement.DocumentFormat;
        requirement.MaxFileSize = dto.MaxFileSize ?? requirement.MaxFileSize;
        requirement.IsRequired = dto.IsRequired;
        requirement.IsActive = dto.IsActive;

        await _repository.UpdateRequirementAsync(requirement);
    }

    public async Task DeleteRequirement(Guid id)
    {
        await _repository.DeleteRequirementAsync(id);
    }

    private MembershipRequirementResponseDto MapToResponseDto(MembershipRequirements requirement)
    {
        return new MembershipRequirementResponseDto
        {
            Id = requirement.Id,
            SortOrder = requirement.SortOrder,
            Title = requirement.Title,
            Description = requirement.Description,
            DocumentFormat = requirement.DocumentFormat,
            MaxFileSize = requirement.MaxFileSize,
            IsRequired = requirement.IsRequired,
            IsActive = requirement.IsActive
        };
    }
}
