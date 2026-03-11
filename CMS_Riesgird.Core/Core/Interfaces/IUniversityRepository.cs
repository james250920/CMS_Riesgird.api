using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Infrastructure.Repositories
{
    public interface IUniversityRepository
    {
        Task AddUniversityAsync(Universities university);
        Task<Universities> Delete(string id);
        Task DeleteUniversityAsync(string id);
        Task<IEnumerable<Universities>> GetActiveUniversitiesAsync();
        Task<IEnumerable<Universities>> GetAllUniversitiesAsync();
        Task<Universities?> GetUniversityByIdAsync(string id);
        Task UpdateUniversityAsync(Universities university);
    }
}