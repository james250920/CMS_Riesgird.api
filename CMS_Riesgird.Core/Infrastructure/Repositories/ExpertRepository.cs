using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Domain.Models;
using CMS_Riesgird.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CMS_Riesgird.Core.Infrastructure.Repositories;

public class ExpertRepository : IExpertRepository
{
    private readonly RiesgirdDbContext _context;

    public ExpertRepository(RiesgirdDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Experts>> GetAllExpertsAsync()
    {
        return await _context.Experts
            .OrderBy(e => e.FullName)
            .ToListAsync();
    }

    public async Task<Experts?> GetExpertByIdAsync(Guid id)
    {
        return await _context.Experts.FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<IEnumerable<Experts>> GetPublicExpertsAsync()
    {
        return await _context.Experts
            .Where(e => e.IsPublic)
            .OrderBy(e => e.FullName)
            .ToListAsync();
    }

    public async Task<IEnumerable<Experts>> GetActiveExpertsAsync()
    {
        return await _context.Experts
            .Where(e => e.IsActive)
            .OrderBy(e => e.FullName)
            .ToListAsync();
    }

    public async Task<IEnumerable<Experts>> GetExpertsByExpertiseAreaAsync(string expertiseArea)
    {
        return await _context.Experts
            .Where(e => e.ExpertiseAreas.Contains(expertiseArea))
            .OrderBy(e => e.FullName)
            .ToListAsync();
    }

    public async Task<IEnumerable<Experts>> GetExpertsByCountryAsync(string country)
    {
        return await _context.Experts
            .Where(e => e.Country == country)
            .OrderBy(e => e.FullName)
            .ToListAsync();
    }

    public async Task<IEnumerable<Experts>> GetAvailableExpertsAsync()
    {
        return await _context.Experts
            .Where(e => e.IsAvailable == true)
            .OrderBy(e => e.FullName)
            .ToListAsync();
    }

    public async Task<IEnumerable<Experts>> GetExpertsAvailableForConsultingAsync()
    {
        return await _context.Experts
            .Where(e => e.AvailableForConsulting == true)
            .OrderBy(e => e.FullName)
            .ToListAsync();
    }

    public async Task<IEnumerable<Experts>> GetExpertsAvailableForTrainingAsync()
    {
        return await _context.Experts
            .Where(e => e.AvailableForTraining == true)
            .OrderBy(e => e.FullName)
            .ToListAsync();
    }

    public async Task<IEnumerable<Experts>> GetExpertsAvailableForResearchAsync()
    {
        return await _context.Experts
            .Where(e => e.AvailableForResearch == true)
            .OrderBy(e => e.FullName)
            .ToListAsync();
    }

    public async Task AddExpertAsync(Experts expert)
    {
        _context.Experts.Add(expert);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateExpertAsync(Experts expert)
    {
        _context.Experts.Update(expert);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteExpertAsync(Guid id)
    {
        var expert = await _context.Experts.FindAsync(id);
        if (expert != null)
        {
            _context.Experts.Remove(expert);
            await _context.SaveChangesAsync();
        }
    }
}
