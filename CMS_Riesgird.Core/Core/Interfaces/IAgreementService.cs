using CMS_Riesgird.Core.Core.DTOs;

namespace CMS_Riesgird.Core.Core.Interfaces;

public interface IAgreementService
{
    Task<IEnumerable<AgreementResponseDto>> GetAllAgreements();
    Task<AgreementResponseDto?> GetAgreementById(Guid id);
    Task<IEnumerable<AgreementResponseDto>> GetAgreementsByAssemblyId(Guid assemblyId);
    Task<IEnumerable<AgreementResponseDto>> GetPublicAgreements();
    Task<IEnumerable<AgreementResponseDto>> GetAgreementsWithDueDate();
    Task<Guid> CreateAgreement(CreateAgreementDto dto);
    Task UpdateAgreement(Guid id, UpdateAgreementDto dto);
    Task DeleteAgreement(Guid id);
}
