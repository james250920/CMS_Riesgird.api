using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Domain.Models;
using CMS_Riesgird.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

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
            return await _context.Universities.ToListAsync();
        }

        public async Task<Universities?> GetUniversityByIdAsync(Guid id)
        {
            return await _context.Universities.FirstOrDefaultAsync(u => u.Id == id);
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

        public async Task DeleteUniversityAsync(Guid id)
        {
            var university = await _context.Universities.FindAsync(id);
            if (university != null)
            {
                _context.Universities.Remove(university);
                await _context.SaveChangesAsync();
            }
        }
    }
}
