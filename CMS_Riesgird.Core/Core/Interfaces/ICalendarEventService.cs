using CMS_Riesgird.Core.Core.DTOs;

namespace CMS_Riesgird.Core.Core.Interfaces;

public interface ICalendarEventService
{
    Task<IEnumerable<CalendarEventResponseDto>> GetAllEvents();
    Task<CalendarEventResponseDto?> GetEventById(Guid id);
    Task<IEnumerable<CalendarEventResponseDto>> GetPublicEvents();
    Task<IEnumerable<CalendarEventResponseDto>> GetEventsByDateRange(DateTime startDate, DateTime endDate);
    Task<IEnumerable<CalendarEventResponseDto>> GetUpcomingEvents();
    Task<IEnumerable<CalendarEventResponseDto>> GetEventsByLocation(string location);
    Task<Guid> CreateEvent(CreateCalendarEventDto dto);
    Task UpdateEvent(Guid id, UpdateCalendarEventDto dto);
    Task DeleteEvent(Guid id);
}
