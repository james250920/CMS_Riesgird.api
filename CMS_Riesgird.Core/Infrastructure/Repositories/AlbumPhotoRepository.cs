using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Domain.Models;
using CMS_Riesgird.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CMS_Riesgird.Core.Infrastructure.Repositories;

public class AlbumPhotoRepository : IAlbumPhotoRepository
{
    private readonly RiesgirdDbContext _context;

    public AlbumPhotoRepository(RiesgirdDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<AlbumPhotos>> GetAllPhotosAsync()
    {
        return await _context.AlbumPhotos
            .Include(p => p.Album)
            .OrderBy(p => p.SortOrder)
            .ToListAsync();
    }

    public async Task<AlbumPhotos?> GetPhotoByIdAsync(Guid id)
    {
        return await _context.AlbumPhotos
            .Include(p => p.Album)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<AlbumPhotos>> GetPhotosByAlbumIdAsync(Guid albumId)
    {
        return await _context.AlbumPhotos
            .Where(p => p.AlbumId == albumId)
            .OrderBy(p => p.SortOrder)
            .ToListAsync();
    }

    public async Task<AlbumPhotos?> GetCoverPhotoByAlbumIdAsync(Guid albumId)
    {
        return await _context.AlbumPhotos
            .FirstOrDefaultAsync(p => p.AlbumId == albumId && p.IsCover);
    }

    public async Task<IEnumerable<AlbumPhotos>> GetPublicPhotosByAlbumIdAsync(Guid albumId)
    {
        return await _context.AlbumPhotos
            .Where(p => p.AlbumId == albumId && p.IsPublic)
            .OrderBy(p => p.SortOrder)
            .ToListAsync();
    }

    public async Task AddPhotoAsync(AlbumPhotos photo)
    {
        _context.AlbumPhotos.Add(photo);
        await _context.SaveChangesAsync();
    }

    public async Task UpdatePhotoAsync(AlbumPhotos photo)
    {
        _context.AlbumPhotos.Update(photo);
        await _context.SaveChangesAsync();
    }

    public async Task DeletePhotoAsync(Guid id)
    {
        var photo = await _context.AlbumPhotos.FindAsync(id);
        if (photo != null)
        {
            _context.AlbumPhotos.Remove(photo);
            await _context.SaveChangesAsync();
        }
    }
}
