using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Domain.Models;
using CMS_Riesgird.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CMS_Riesgird.Core.Infrastructure.Repositories;

public class VideoItemRepository : IVideoItemRepository
{
    private readonly RiesgirdDbContext _context;

    public VideoItemRepository(RiesgirdDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<VideoItems>> GetAllVideosAsync()
    {
        return await _context.VideoItems
            .Include(v => v.Congress)
            .Include(v => v.Album)
            .OrderBy(v => v.SortOrder)
            .ThenBy(v => v.Title)
            .ToListAsync();
    }

    public async Task<VideoItems?> GetVideoByIdAsync(Guid id)
    {
        return await _context.VideoItems
            .Include(v => v.Congress)
            .Include(v => v.Album)
            .FirstOrDefaultAsync(v => v.Id == id);
    }

    public async Task<IEnumerable<VideoItems>> GetVideosByCongressIdAsync(Guid congressId)
    {
        return await _context.VideoItems
            .Where(v => v.CongressId == congressId)
            .OrderBy(v => v.SortOrder)
            .ThenBy(v => v.Title)
            .ToListAsync();
    }

    public async Task<IEnumerable<VideoItems>> GetVideosByAlbumIdAsync(Guid albumId)
    {
        return await _context.VideoItems
            .Where(v => v.AlbumId == albumId)
            .OrderBy(v => v.SortOrder)
            .ThenBy(v => v.Title)
            .ToListAsync();
    }

    public async Task AddVideoAsync(VideoItems video)
    {
        _context.VideoItems.Add(video);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateVideoAsync(VideoItems video)
    {
        _context.VideoItems.Update(video);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteVideoAsync(Guid id)
    {
        var video = await _context.VideoItems.FindAsync(id);
        if (video != null)
        {
            _context.VideoItems.Remove(video);
            await _context.SaveChangesAsync();
        }
    }
}
