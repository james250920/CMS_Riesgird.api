using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Core.Interfaces
{
    public interface IUniversityRepository
    {
        Task<IEnumerable<Universities>> GetAllUniversitiesAsync();
        Task<Universities?> GetUniversityByIdAsync(Guid id);
        Task AddUniversityAsync(Universities university);
        Task UpdateUniversityAsync(Universities university);
        Task DeleteUniversityAsync(Guid id);
    }
}