using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Domain.Models;
using CMS_Riesgird.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CMS_Riesgird.Core.Infrastructure.Repositories;

public class PhotoAlbumRepository : IPhotoAlbumRepository
{
    private readonly RiesgirdDbContext _context;

    public PhotoAlbumRepository(RiesgirdDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PhotoAlbums>> GetAllAlbumsAsync()
    {
        return await _context.PhotoAlbums
            .Include(a => a.AlbumPhotos)
            .OrderByDescending(a => a.Date)
            .ThenBy(a => a.Title)
            .ToListAsync();
    }

    public async Task<PhotoAlbums?> GetAlbumByIdAsync(Guid id)
    {
        return await _context.PhotoAlbums
            .Include(a => a.AlbumPhotos)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<IEnumerable<PhotoAlbums>> GetPublicAlbumsAsync()
    {
        return await _context.PhotoAlbums
            .Where(a => a.IsPublic)
            .Include(a => a.AlbumPhotos)
            .OrderByDescending(a => a.Date)
            .ThenBy(a => a.Title)
            .ToListAsync();
    }

    public async Task<IEnumerable<PhotoAlbums>> GetFeaturedAlbumsAsync()
    {
        return await _context.PhotoAlbums
            .Where(a => a.IsFeatured)
            .Include(a => a.AlbumPhotos)
            .OrderByDescending(a => a.Date)
            .ThenBy(a => a.Title)
            .ToListAsync();
    }

    public async Task<IEnumerable<PhotoAlbums>> GetAlbumsByEventIdAsync(Guid eventId)
    {
        return await _context.PhotoAlbums
            .Where(a => a.EventId == eventId)
            .Include(a => a.AlbumPhotos)
            .OrderByDescending(a => a.Date)
            .ToListAsync();
    }

    public async Task<IEnumerable<PhotoAlbums>> GetAlbumsByTagAsync(string tag)
    {
        return await _context.PhotoAlbums
            .Where(a => a.Tags != null && a.Tags.Contains(tag))
            .Include(a => a.AlbumPhotos)
            .OrderByDescending(a => a.Date)
            .ThenBy(a => a.Title)
            .ToListAsync();
    }

    public async Task AddAlbumAsync(PhotoAlbums album)
    {
        _context.PhotoAlbums.Add(album);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAlbumAsync(PhotoAlbums album)
    {
        _context.PhotoAlbums.Update(album);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAlbumAsync(Guid id)
    {
        var album = await _context.PhotoAlbums.FindAsync(id);
        if (album != null)
        {
            _context.PhotoAlbums.Remove(album);
            await _context.SaveChangesAsync();
        }
    }
}
