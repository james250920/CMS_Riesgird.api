using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Core.Interfaces;

public interface ICalendarEventRepository
{
    Task<IEnumerable<CalendarEvents>> GetAllEventsAsync();
    Task<CalendarEvents?> GetEventByIdAsync(Guid id);
    Task<IEnumerable<CalendarEvents>> GetPublicEventsAsync();
    Task<IEnumerable<CalendarEvents>> GetEventsByDateRangeAsync(DateTime startDate, DateTime endDate);
    Task<IEnumerable<CalendarEvents>> GetUpcomingEventsAsync();
    Task<IEnumerable<CalendarEvents>> GetEventsByLocationAsync(string location);
    Task AddEventAsync(CalendarEvents calendarEvent);
    Task UpdateEventAsync(CalendarEvents calendarEvent);
    Task DeleteEventAsync(Guid id);
}
