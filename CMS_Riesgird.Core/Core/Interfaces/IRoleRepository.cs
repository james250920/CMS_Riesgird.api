using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Core.Interfaces
{
    public interface IRoleRepository
    {
        Task AddRoleAsync(Roles role);
        Task DeleteRoleAsync(Guid id);
        Task<IEnumerable<Roles>> GetAllRolesAsync();
        Task<Roles?> GetRoleByIdAsync(Guid id);
        Task UpdateRoleAsync(Roles role);
    }
}