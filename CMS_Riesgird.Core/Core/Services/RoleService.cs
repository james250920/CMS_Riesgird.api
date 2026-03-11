using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Core.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<IEnumerable<RoleResponseDto>> GetAllRoles()
        {
            var roles = await _roleRepository.GetAllRolesAsync();
            return roles.Select(r => new RoleResponseDto
            {
                Id = r.Id,
                Name = r.Name,
                Level = r.Level,
                Color = r.Color,
                Description = r.Description,
                IsActive = r.IsActive,
                CreatedAt = r.CreatedAt,
                UpdatedAt = r.UpdatedAt
            });
        }

        public async Task<RoleResponseDto?> GetRoleById(Guid id)
        {
            var role = await _roleRepository.GetRoleByIdAsync(id);
            if (role == null)
                return null;

            return new RoleResponseDto
            {
                Id = role.Id,
                Name = role.Name,
                Level = role.Level,
                Color = role.Color,
                Description = role.Description,
                IsActive = role.IsActive,
                CreatedAt = role.CreatedAt,
                UpdatedAt = role.UpdatedAt
            };
        }

        public async Task<Guid> CreateRole(CreateRoleDto dto)
        {
            var role = new Roles
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Level = dto.Level,
                Color = dto.Color,
                Description = dto.Description,
                IsActive = dto.IsActive,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _roleRepository.AddRoleAsync(role);
            return role.Id;
        }

        public async Task UpdateRole(Guid id, UpdateRoleDto dto)
        {
            var role = await _roleRepository.GetRoleByIdAsync(id);
            if (role == null)
                throw new Exception("Rol no encontrado");

            role.Name = dto.Name ?? role.Name;
            role.Level = dto.Level;
            role.Color = dto.Color ?? role.Color;
            role.Description = dto.Description ?? role.Description;
            role.IsActive = dto.IsActive;
            role.UpdatedAt = DateTime.UtcNow;

            await _roleRepository.UpdateRoleAsync(role);
        }

        public async Task DeleteRole(Guid id)
        {
            await _roleRepository.DeleteRoleAsync(id);
        }
    }
}
