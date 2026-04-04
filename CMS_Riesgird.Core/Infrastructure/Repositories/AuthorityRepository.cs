using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Domain.Models;
using CMS_Riesgird.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CMS_Riesgird.Core.Infrastructure.Repositories
{
    public class AuthorityRepository : IAuthorityRepository
    {
        private readonly RiesgirdDbContext _context;

        public AuthorityRepository(RiesgirdDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Authorities>> GetAllAuthoritiesAsync()
        {
            return await _context.Authorities.ToListAsync();
        }

        public async Task<IEnumerable<Authorities>> GetAuthoritiesByUniversityIdAsync(Guid universityId)
        {
            return await _context.Authorities
                .Where(a => a.UniversityId == universityId)
                .ToListAsync();
        }

        public async Task<Authorities?> GetAuthorityByIdAsync(Guid id)
        {
            return await _context.Authorities.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task AddAuthorityAsync(Authorities authority)
        {
            _context.Authorities.Add(authority);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAuthorityAsync(Authorities authority)
        {
            _context.Authorities.Update(authority);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAuthorityAsync(Guid id)
        {
            var authority = await _context.Authorities.FindAsync(id);
            if (authority != null)
            {
                _context.Authorities.Remove(authority);
                await _context.SaveChangesAsync();
            }
        }
    }
}
