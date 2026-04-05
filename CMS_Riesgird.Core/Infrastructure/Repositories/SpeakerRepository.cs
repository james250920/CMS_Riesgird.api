using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Domain.Models;
using CMS_Riesgird.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CMS_Riesgird.Core.Infrastructure.Repositories;

public class SpeakerRepository : ISpeakerRepository
{
    private readonly RiesgirdDbContext _context;

    public SpeakerRepository(RiesgirdDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Speakers>> GetAllSpeakersAsync()
    {
        return await _context.Speakers
            .Include(s => s.Congress)
            .OrderBy(s => s.FullName)
            .ToListAsync();
    }

    public async Task<Speakers?> GetSpeakerByIdAsync(Guid id)
    {
        return await _context.Speakers
            .Include(s => s.Congress)
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<IEnumerable<Speakers>> GetSpeakersByCongressIdAsync(Guid congressId)
    {
        return await _context.Speakers
            .Where(s => s.CongressId == congressId)
            .OrderBy(s => s.FullName)
            .ToListAsync();
    }

    public async Task<IEnumerable<Speakers>> GetSpeakersByCountryAsync(string country)
    {
        return await _context.Speakers
            .Where(s => s.Country == country)
            .OrderBy(s => s.FullName)
            .ToListAsync();
    }

    public async Task<IEnumerable<Speakers>> GetSpeakersByInstitutionAsync(string institution)
    {
        return await _context.Speakers
            .Where(s => s.Institution.Contains(institution))
            .OrderBy(s => s.FullName)
            .ToListAsync();
    }

    public async Task AddSpeakerAsync(Speakers speaker)
    {
        _context.Speakers.Add(speaker);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateSpeakerAsync(Speakers speaker)
    {
        _context.Speakers.Update(speaker);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteSpeakerAsync(Guid id)
    {
        var speaker = await _context.Speakers.FindAsync(id);
        if (speaker != null)
        {
            _context.Speakers.Remove(speaker);
            await _context.SaveChangesAsync();
        }
    }
}
