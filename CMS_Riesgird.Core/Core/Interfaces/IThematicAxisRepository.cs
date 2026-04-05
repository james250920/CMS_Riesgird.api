using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Core.Interfaces;

public interface IThematicAxisRepository
{
    Task<IEnumerable<ThematicAxes>> GetAllAxesAsync();
    Task<ThematicAxes?> GetAxisByIdAsync(Guid id);
    Task<IEnumerable<ThematicAxes>> GetAxesByCongressIdAsync(Guid congressId);
    Task AddAxisAsync(ThematicAxes axis);
    Task UpdateAxisAsync(ThematicAxes axis);
    Task DeleteAxisAsync(Guid id);
}
