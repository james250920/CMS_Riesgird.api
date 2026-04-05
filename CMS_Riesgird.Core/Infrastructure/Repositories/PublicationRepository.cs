using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Domain.Models;
using CMS_Riesgird.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CMS_Riesgird.Core.Infrastructure.Repositories;

public class PublicationRepository : IPublicationRepository
{
    private readonly RiesgirdDbContext _context;

    public PublicationRepository(RiesgirdDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Publications>> GetAllPublicationsAsync()
    {
        return await _context.Publications
            .Include(p => p.Researcher)
            .OrderByDescending(p => p.Year)
            .ThenBy(p => p.Title)
            .ToListAsync();
    }

    public async Task<Publications?> GetPublicationByIdAsync(Guid id)
    {
        return await _context.Publications
            .Include(p => p.Researcher)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Publications>> GetPublicationsByResearcherIdAsync(Guid researcherId)
    {
        return await _context.Publications
            .Where(p => p.ResearcherId == researcherId)
            .OrderByDescending(p => p.Year)
            .ThenBy(p => p.Title)
            .ToListAsync();
    }

    public async Task<IEnumerable<Publications>> GetPublicationsAsync()
    {
        return await _context.Publications
            .Where(p => p.IsPublic)
            .Include(p => p.Researcher)
            .OrderByDescending(p => p.Year)
            .ThenBy(p => p.Title)
            .ToListAsync();
    }

    public async Task<IEnumerable<Publications>> GetPublicationsByYearAsync(int year)
    {
        return await _context.Publications
            .Where(p => p.Year == year)
            .OrderByDescending(p => p.CreatedAt)
            .ToListAsync();
    }

    public async Task<IEnumerable<Publications>> GetPublicationsByJournalAsync(string journal)
    {
        return await _context.Publications
            .Where(p => p.Journal != null && p.Journal.Contains(journal))
            .OrderByDescending(p => p.Year)
            .ThenBy(p => p.Title)
            .ToListAsync();
    }

    public async Task<IEnumerable<Publications>> GetPublicationsByKeywordAsync(string keyword)
    {
        return await _context.Publications
            .Where(p => p.Keywords.Contains(keyword))
            .OrderByDescending(p => p.Year)
            .ThenBy(p => p.Title)
            .ToListAsync();
    }

    public async Task AddPublicationAsync(Publications publication)
    {
        _context.Publications.Add(publication);
        await _context.SaveChangesAsync();
    }

    public async Task UpdatePublicationAsync(Publications publication)
    {
        _context.Publications.Update(publication);
        await _context.SaveChangesAsync();
    }

    public async Task DeletePublicationAsync(Guid id)
    {
        var publication = await _context.Publications.FindAsync(id);
        if (publication != null)
        {
            _context.Publications.Remove(publication);
            await _context.SaveChangesAsync();
        }
    }
}
