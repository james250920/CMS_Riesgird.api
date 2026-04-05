using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Core.Interfaces;

public interface IAllyRepository
{
    Task<IEnumerable<Allies>> GetAllAlliesAsync();
    Task<Allies?> GetAllyByIdAsync(Guid id);
    Task<IEnumerable<Allies>> GetPublicAlliesAsync();
    Task<IEnumerable<Allies>> GetActiveAlliesAsync();
    Task AddAllyAsync(Allies ally);
    Task UpdateAllyAsync(Allies ally);
    Task DeleteAllyAsync(Guid id);
}
