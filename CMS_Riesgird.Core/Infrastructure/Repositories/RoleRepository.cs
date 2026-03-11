using CMS_Riesgird.Infrastructure.Data;
using CMS_Riesgird.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS_Riesgird.Core.Core.Interfaces;

namespace CMS_Riesgird.Core.Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly RiesgirdDbContext _context;

        public RoleRepository(RiesgirdDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Roles>> GetAllRolesAsync()
        {
            return await _context.Roles
                .Include(p => p.RolePermissions)
                .ToListAsync();
        }

        public async Task<Roles?> GetRoleByIdAsync(Guid id)
        {
            return await _context.Roles
                .Include(p => p.RolePermissions)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task AddRoleAsync(Roles role)
        {
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRoleAsync(Roles role)
        {
            _context.Roles.Update(role);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoleAsync(Guid id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role != null)
            {
                _context.Roles.Remove(role);
                await _context.SaveChangesAsync();
            }
        }
    }
}
