using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Domain.Models;
using CMS_Riesgird.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CMS_Riesgird.Core.Infrastructure.Repositories;

public class CalendarEventRepository : ICalendarEventRepository
{
    private readonly RiesgirdDbContext _context;

    public CalendarEventRepository(RiesgirdDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CalendarEvents>> GetAllEventsAsync()
    {
        return await _context.CalendarEvents
            .OrderByDescending(e => e.StartDate)
            .ToListAsync();
    }

    public async Task<CalendarEvents?> GetEventByIdAsync(Guid id)
    {
        return await _context.CalendarEvents.FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<IEnumerable<CalendarEvents>> GetPublicEventsAsync()
    {
        return await _context.CalendarEvents
            .Where(e => e.IsPublic)
            .OrderByDescending(e => e.StartDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<CalendarEvents>> GetEventsByDateRangeAsync(DateTime startDate, DateTime endDate)
    {
        return await _context.CalendarEvents
            .Where(e => e.StartDate >= startDate && (e.EndDate == null || e.EndDate <= endDate))
            .OrderByDescending(e => e.StartDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<CalendarEvents>> GetUpcomingEventsAsync()
    {
        var today = DateTime.UtcNow;
        return await _context.CalendarEvents
            .Where(e => e.StartDate >= today)
            .OrderBy(e => e.StartDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<CalendarEvents>> GetEventsByLocationAsync(string location)
    {
        return await _context.CalendarEvents
            .Where(e => e.Location == location)
            .OrderByDescending(e => e.StartDate)
            .ToListAsync();
    }

    public async Task AddEventAsync(CalendarEvents calendarEvent)
    {
        _context.CalendarEvents.Add(calendarEvent);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateEventAsync(CalendarEvents calendarEvent)
    {
        _context.CalendarEvents.Update(calendarEvent);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteEventAsync(Guid id)
    {
        var calendarEvent = await _context.CalendarEvents.FindAsync(id);
        if (calendarEvent != null)
        {
            _context.CalendarEvents.Remove(calendarEvent);
            await _context.SaveChangesAsync();
        }
    }
}
