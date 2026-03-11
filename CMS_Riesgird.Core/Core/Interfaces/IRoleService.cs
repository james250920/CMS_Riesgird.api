using CMS_Riesgird.Core.Core.DTOs;

namespace CMS_Riesgird.Core.Core.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleResponseDto>> GetAllRoles();
        Task<RoleResponseDto?> GetRoleById(Guid id);
        Task<Guid> CreateRole(CreateRoleDto dto);
        Task UpdateRole(Guid id, UpdateRoleDto dto);
        Task DeleteRole(Guid id);
    }
}
