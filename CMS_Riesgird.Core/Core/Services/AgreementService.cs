using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Core.Services;

public class AgreementService : IAgreementService
{
    private readonly IAgreementRepository _repository;

    public AgreementService(IAgreementRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<AgreementResponseDto>> GetAllAgreements()
    {
        var agreements = await _repository.GetAllAgreementsAsync();
        return agreements.Select(a => MapToResponseDto(a));
    }

    public async Task<AgreementResponseDto?> GetAgreementById(Guid id)
    {
        var agreement = await _repository.GetAgreementByIdAsync(id);
        if (agreement == null)
            return null;

        return MapToResponseDto(agreement);
    }

    public async Task<IEnumerable<AgreementResponseDto>> GetAgreementsByAssemblyId(Guid assemblyId)
    {
        var agreements = await _repository.GetAgreementsByAssemblyIdAsync(assemblyId);
        return agreements.Select(a => MapToResponseDto(a));
    }

    public async Task<IEnumerable<AgreementResponseDto>> GetPublicAgreements()
    {
        var agreements = await _repository.GetPublicAgreementsAsync();
        return agreements.Select(a => MapToResponseDto(a));
    }

    public async Task<IEnumerable<AgreementResponseDto>> GetAgreementsWithDueDate()
    {
        var agreements = await _repository.GetAgreementsWithDueDateAsync();
        return agreements.Select(a => MapToResponseDto(a));
    }

    public async Task<Guid> CreateAgreement(CreateAgreementDto dto)
    {
        var agreement = new Agreements
        {
            Id = Guid.NewGuid(),
            AssemblyId = dto.AssemblyId,
            Number = dto.Number,
            Title = dto.Title,
            Description = dto.Description,
            Responsible = dto.Responsible,
            DueDate = dto.DueDate,
            IsPublic = dto.IsPublic
        };

        await _repository.AddAgreementAsync(agreement);
        return agreement.Id;
    }

    public async Task UpdateAgreement(Guid id, UpdateAgreementDto dto)
    {
        var agreement = await _repository.GetAgreementByIdAsync(id);
        if (agreement == null)
            throw new Exception("Acuerdo no encontrado");

        agreement.AssemblyId = dto.AssemblyId;
        agreement.Number = dto.Number ?? agreement.Number;
        agreement.Title = dto.Title ?? agreement.Title;
        agreement.Description = dto.Description ?? agreement.Description;
        agreement.Responsible = dto.Responsible ?? agreement.Responsible;
        agreement.DueDate = dto.DueDate ?? agreement.DueDate;
        agreement.IsPublic = dto.IsPublic;

        await _repository.UpdateAgreementAsync(agreement);
    }

    public async Task DeleteAgreement(Guid id)
    {
        await _repository.DeleteAgreementAsync(id);
    }

    private AgreementResponseDto MapToResponseDto(Agreements agreement)
    {
        return new AgreementResponseDto
        {
            Id = agreement.Id,
            AssemblyId = agreement.AssemblyId,
            Number = agreement.Number,
            Title = agreement.Title,
            Description = agreement.Description,
            Responsible = agreement.Responsible,
            DueDate = agreement.DueDate,
            IsPublic = agreement.IsPublic
        };
    }
}
