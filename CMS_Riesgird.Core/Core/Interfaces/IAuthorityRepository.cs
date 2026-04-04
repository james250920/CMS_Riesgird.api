using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Core.Interfaces
{
    public interface IAuthorityRepository
    {
        Task<IEnumerable<Authorities>> GetAllAuthoritiesAsync();
        Task<IEnumerable<Authorities>> GetAuthoritiesByUniversityIdAsync(Guid universityId);
        Task<Authorities?> GetAuthorityByIdAsync(Guid id);
        Task AddAuthorityAsync(Authorities authority);
        Task UpdateAuthorityAsync(Authorities authority);
        Task DeleteAuthorityAsync(Guid id);
    }
}
