using CMS_Riesgird.Core.Core.DTOs;

namespace CMS_Riesgird.Core.Core.Interfaces
{
    public interface IUniversityService
    {
        Task<IEnumerable<UniversityResponseDto>> GetAllUniversities();
        Task<UniversityResponseDto?> GetUniversityById(Guid id);
        Task<Guid> CreateUniversity(CreateUniversityDto dto);
        Task UpdateUniversity(Guid id, UpdateUniversityDto dto);
        Task DeleteUniversity(Guid id);
    }
}
