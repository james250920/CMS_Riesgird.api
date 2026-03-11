using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Core.Interfaces
{
    public interface IRoleRepository
    {
        Task AddRoleAsync(Roles role);
        Task DeleteRoleAsync(string id);
        Task<IEnumerable<Roles>> GetAllRolesAsync();
        Task<Roles?> GetRoleByIdAsync(string id);
        Task UpdateRoleAsync(Roles role);
    }
}