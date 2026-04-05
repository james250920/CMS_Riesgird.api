using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Core.Services;

public class CalendarEventService : ICalendarEventService
{
    private readonly ICalendarEventRepository _repository;

    public CalendarEventService(ICalendarEventRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<CalendarEventResponseDto>> GetAllEvents()
    {
        var events = await _repository.GetAllEventsAsync();
        return events.Select(e => MapToResponseDto(e));
    }

    public async Task<CalendarEventResponseDto?> GetEventById(Guid id)
    {
        var calendarEvent = await _repository.GetEventByIdAsync(id);
        if (calendarEvent == null)
            return null;

        return MapToResponseDto(calendarEvent);
    }

    public async Task<IEnumerable<CalendarEventResponseDto>> GetPublicEvents()
    {
        var events = await _repository.GetPublicEventsAsync();
        return events.Select(e => MapToResponseDto(e));
    }

    public async Task<IEnumerable<CalendarEventResponseDto>> GetEventsByDateRange(DateTime startDate, DateTime endDate)
    {
        if (startDate > endDate)
            throw new Exception("La fecha de inicio no puede ser mayor a la fecha de fin");

        var events = await _repository.GetEventsByDateRangeAsync(startDate, endDate);
        return events.Select(e => MapToResponseDto(e));
    }

    public async Task<IEnumerable<CalendarEventResponseDto>> GetUpcomingEvents()
    {
        var events = await _repository.GetUpcomingEventsAsync();
        return events.Select(e => MapToResponseDto(e));
    }

    public async Task<IEnumerable<CalendarEventResponseDto>> GetEventsByLocation(string location)
    {
        var events = await _repository.GetEventsByLocationAsync(location);
        return events.Select(e => MapToResponseDto(e));
    }

    public async Task<Guid> CreateEvent(CreateCalendarEventDto dto)
    {
        if (dto.EndDate.HasValue && dto.StartDate > dto.EndDate)
            throw new Exception("La fecha de inicio no puede ser mayor a la fecha de fin");

        var calendarEvent = new CalendarEvents
        {
            Id = Guid.NewGuid(),
            Title = dto.Title,
            Description = dto.Description,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate,
            AllDay = dto.AllDay,
            Location = dto.Location,
            Color = dto.Color,
            RelatedEntityId = dto.RelatedEntityId,
            RelatedEntityType = dto.RelatedEntityType,
            IsPublic = dto.IsPublic,
            CreatedBy = dto.CreatedBy,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        await _repository.AddEventAsync(calendarEvent);
        return calendarEvent.Id;
    }

    public async Task UpdateEvent(Guid id, UpdateCalendarEventDto dto)
    {
        var calendarEvent = await _repository.GetEventByIdAsync(id);
        if (calendarEvent == null)
            throw new Exception("Evento de calendario no encontrado");

        if (dto.EndDate.HasValue && dto.StartDate > dto.EndDate)
            throw new Exception("La fecha de inicio no puede ser mayor a la fecha de fin");

        calendarEvent.Title = dto.Title ?? calendarEvent.Title;
        calendarEvent.Description = dto.Description ?? calendarEvent.Description;
        calendarEvent.StartDate = dto.StartDate;
        calendarEvent.EndDate = dto.EndDate ?? calendarEvent.EndDate;
        calendarEvent.AllDay = dto.AllDay;
        calendarEvent.Location = dto.Location ?? calendarEvent.Location;
        calendarEvent.Color = dto.Color ?? calendarEvent.Color;
        calendarEvent.RelatedEntityId = dto.RelatedEntityId ?? calendarEvent.RelatedEntityId;
        calendarEvent.RelatedEntityType = dto.RelatedEntityType ?? calendarEvent.RelatedEntityType;
        calendarEvent.IsPublic = dto.IsPublic;
        calendarEvent.UpdatedAt = DateTime.UtcNow;

        await _repository.UpdateEventAsync(calendarEvent);
    }

    public async Task DeleteEvent(Guid id)
    {
        await _repository.DeleteEventAsync(id);
    }

    private CalendarEventResponseDto MapToResponseDto(CalendarEvents calendarEvent)
    {
        return new CalendarEventResponseDto
        {
            Id = calendarEvent.Id,
            Title = calendarEvent.Title,
            Description = calendarEvent.Description,
            StartDate = calendarEvent.StartDate,
            EndDate = calendarEvent.EndDate,
            AllDay = calendarEvent.AllDay,
            Location = calendarEvent.Location,
            Color = calendarEvent.Color,
            RelatedEntityId = calendarEvent.RelatedEntityId,
            RelatedEntityType = calendarEvent.RelatedEntityType,
            IsPublic = calendarEvent.IsPublic,
            CreatedAt = calendarEvent.CreatedAt,
            UpdatedAt = calendarEvent.UpdatedAt
        };
    }
}
