using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Core.Interfaces;

public interface IUniversityBrigadeRepository
{
    Task<IEnumerable<UniversityBrigades>> GetAllUniversityBrigadesAsync();
    Task<IEnumerable<UniversityBrigades>> GetUniversityBrigadesByUniversityIdAsync(Guid universityId);
    Task<UniversityBrigades?> GetUniversityBrigadeByIdAsync(Guid id);
    Task AddUniversityBrigadeAsync(UniversityBrigades brigade);
    Task UpdateUniversityBrigadeAsync(UniversityBrigades brigade);
    Task DeleteUniversityBrigadeAsync(Guid id);
}
