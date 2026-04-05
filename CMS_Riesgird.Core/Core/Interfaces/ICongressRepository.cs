using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Core.Interfaces;

public interface ICongressRepository
{
    Task<IEnumerable<Congresses>> GetAllCongressesAsync();
    Task<Congresses?> GetCongressByIdAsync(Guid id);
    Task<IEnumerable<Congresses>> GetCongressesByYearAsync(int year);
    Task<IEnumerable<Congresses>> GetPublicCongressesAsync();
    Task<IEnumerable<Congresses>> GetCongressesByEditionAsync(int edition);
    Task AddCongressAsync(Congresses congress);
    Task UpdateCongressAsync(Congresses congress);
    Task DeleteCongressAsync(Guid id);
}
