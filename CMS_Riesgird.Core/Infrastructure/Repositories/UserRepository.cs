using CMS_Riesgird.Domain.Models;
using CMS_Riesgird.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS_Riesgird.Core.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CMS_Riesgird.Core.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly RiesgirdDbContext _context;

        public UserRepository(RiesgirdDbContext context)
        {
            _context = context;
        }

        public async Task<Users?> GetByEmail(string email)
        {
            if(string.IsNullOrWhiteSpace(email)) return null;
            var result = await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(x => x.Email == email);
            return result;
        }

        public async Task<Users?> GetById(Guid id)
        {
            return await _context.Users
                .Include(u => u.Role)
                .Include(u => u.University)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<Users>> GetAll()
        {
            return await _context.Users
                .Include(u => u.Role)
                .Include(u => u.University)
                .ToListAsync();
        }

        public async Task<Guid> AddUserAsync(Users user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user.Id;
        }

        public async Task Update(Users user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
