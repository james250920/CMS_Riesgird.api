using CMS_Riesgird.Core.Core.DTOs;

namespace CMS_Riesgird.Core.Core.Interfaces
{
    public interface IAuthorityService
    {
        Task<IEnumerable<AuthorityResponseDto>> GetAllAuthorities();
        Task<IEnumerable<AuthorityResponseDto>> GetAuthoritiesByUniversityId(Guid universityId);
        Task<AuthorityResponseDto?> GetAuthorityById(Guid id);
        Task<Guid> CreateAuthority(CreateAuthorityDto dto);
        Task UpdateAuthority(Guid id, UpdateAuthorityDto dto);
        Task DeleteAuthority(Guid id);
    }
}
