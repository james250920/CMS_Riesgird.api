using CMS_Riesgird.Domain.Models;
using CMS_Riesgird.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Riesgird.Core.Infrastructure.Repositories
{
    public class UniversityRepository : IUniversityRepository
    {
        private readonly RiesgirdDbContext _context;

        public UniversityRepository(RiesgirdDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Universities>> GetAllUniversitiesAsync()
        {
            return await _context.Universities
                .Include(u => u.Authorities)
                .Include(u => u.MembershipApplications)
                .Include(u => u.Users)
                .ToListAsync();
        }
        public async Task<Universities?> GetUniversityByIdAsync(string id)
        {
            if (!Guid.TryParse(id, out var guidId))
            {
                return null;
            }
            return await _context.Universities
                .Include(u => u.Authorities)
                .Include(u => u.MembershipApplications)
                .Include(u => u.Users)
                .FirstOrDefaultAsync(r => r.Id == guidId);
        }
        public async Task AddUniversityAsync(Universities university)
        {
            _context.Universities.Add(university);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateUniversityAsync(Universities university)
        {
            _context.Universities.Update(university);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteUniversityAsync(string id)
        {
            if (!Guid.TryParse(id, out var guidId))
            {
                return;
            }
            var university = await _context.Universities.FindAsync(guidId);
            if (university != null)
            {
                _context.Universities.Remove(university);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Universities>> GetActiveUniversitiesAsync()
        {
            return await _context.Universities
                .Where(u => u.IsActive == true)
                .Include(u => u.Authorities)
                .Include(u => u.MembershipApplications)
                .Include(u => u.Users)
                .ToListAsync();
        }
        public async Task<Universities> Delete(String id)
        {
            if (!Guid.TryParse(id, out var guidId))
            {
                return null;
            }
            var university = await _context.Universities.FindAsync(guidId);
            if (university != null)
            {
                _context.Universities.Remove(university);
                await _context.SaveChangesAsync();
            }
            return university;
        }
    }
}
