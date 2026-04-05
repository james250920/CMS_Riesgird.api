using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Domain.Models;
using CMS_Riesgird.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CMS_Riesgird.Core.Infrastructure.Repositories;

public class ForumEventRepository : IForumEventRepository
{
    private readonly RiesgirdDbContext _context;

    public ForumEventRepository(RiesgirdDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ForumEvents>> GetAllForumEventsAsync()
    {
        return await _context.ForumEvents
            .OrderByDescending(f => f.StartDate)
            .ToListAsync();
    }

    public async Task<ForumEvents?> GetForumEventByIdAsync(Guid id)
    {
        return await _context.ForumEvents.FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task<IEnumerable<ForumEvents>> GetUpcomingForumEventsAsync()
    {
        var now = DateTime.UtcNow;
        return await _context.ForumEvents
            .Where(f => f.StartDate >= now)
            .OrderBy(f => f.StartDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<ForumEvents>> GetPublicForumEventsAsync()
    {
        return await _context.ForumEvents
            .Where(f => f.IsPublic)
            .OrderByDescending(f => f.StartDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<ForumEvents>> GetForumEventsByMonthAsync(int month, int year)
    {
        return await _context.ForumEvents
            .Where(f => f.StartDate.Month == month && f.StartDate.Year == year)
            .OrderBy(f => f.StartDate)
            .ToListAsync();
    }

    public async Task AddForumEventAsync(ForumEvents forumEvent)
    {
        _context.ForumEvents.Add(forumEvent);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateForumEventAsync(ForumEvents forumEvent)
    {
        _context.ForumEvents.Update(forumEvent);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteForumEventAsync(Guid id)
    {
        var forumEvent = await _context.ForumEvents.FindAsync(id);
        if (forumEvent != null)
        {
            _context.ForumEvents.Remove(forumEvent);
            await _context.SaveChangesAsync();
        }
    }
}
