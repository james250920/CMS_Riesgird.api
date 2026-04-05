using CMS_Riesgird.Core.Core.DTOs;

namespace CMS_Riesgird.Core.Core.Interfaces;

public interface IUniversityBrigadeService
{
    Task<IEnumerable<UniversityBrigadeResponseDto>> GetAllUniversityBrigades();
    Task<IEnumerable<UniversityBrigadeResponseDto>> GetUniversityBrigadesByUniversityId(Guid universityId);
    Task<UniversityBrigadeResponseDto?> GetUniversityBrigadeById(Guid id);
    Task<Guid> CreateUniversityBrigade(CreateUniversityBrigadeDto dto);
    Task UpdateUniversityBrigade(Guid id, UpdateUniversityBrigadeDto dto);
    Task DeleteUniversityBrigade(Guid id);
}
