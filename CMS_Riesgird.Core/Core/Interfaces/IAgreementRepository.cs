using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Core.Interfaces;

public interface IAgreementRepository
{
    Task<IEnumerable<Agreements>> GetAllAgreementsAsync();
    Task<Agreements?> GetAgreementByIdAsync(Guid id);
    Task<IEnumerable<Agreements>> GetAgreementsByAssemblyIdAsync(Guid assemblyId);
    Task<IEnumerable<Agreements>> GetPublicAgreementsAsync();
    Task<IEnumerable<Agreements>> GetAgreementsWithDueDateAsync();
    Task AddAgreementAsync(Agreements agreement);
    Task UpdateAgreementAsync(Agreements agreement);
    Task DeleteAgreementAsync(Guid id);
}
