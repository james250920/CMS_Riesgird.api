using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Domain.Models;
using CMS_Riesgird.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CMS_Riesgird.Core.Infrastructure.Repositories;

public class DownloadableTemplateRepository : IDownloadableTemplateRepository
{
    private readonly RiesgirdDbContext _context;

    public DownloadableTemplateRepository(RiesgirdDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<DownloadableTemplates>> GetAllTemplatesAsync()
    {
        return await _context.DownloadableTemplates
            .OrderByDescending(t => t.UploadDate)
            .ToListAsync();
    }

    public async Task<DownloadableTemplates?> GetTemplateByIdAsync(Guid id)
    {
        return await _context.DownloadableTemplates.FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<IEnumerable<DownloadableTemplates>> GetActiveTemplatesAsync()
    {
        return await _context.DownloadableTemplates
            .Where(t => t.IsActive)
            .OrderByDescending(t => t.UploadDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<DownloadableTemplates>> GetTemplatesByVersionAsync(string version)
    {
        return await _context.DownloadableTemplates
            .Where(t => t.Version == version)
            .OrderByDescending(t => t.UploadDate)
            .ToListAsync();
    }

    public async Task AddTemplateAsync(DownloadableTemplates template)
    {
        _context.DownloadableTemplates.Add(template);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateTemplateAsync(DownloadableTemplates template)
    {
        _context.DownloadableTemplates.Update(template);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteTemplateAsync(Guid id)
    {
        var template = await _context.DownloadableTemplates.FindAsync(id);
        if (template != null)
        {
            _context.DownloadableTemplates.Remove(template);
            await _context.SaveChangesAsync();
        }
    }

    public async Task IncrementDownloadCountAsync(Guid id)
    {
        var template = await _context.DownloadableTemplates.FindAsync(id);
        if (template != null)
        {
            template.DownloadCount++;
            _context.DownloadableTemplates.Update(template);
            await _context.SaveChangesAsync();
        }
    }
}
