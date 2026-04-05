using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Core.Services;

public class ActivityService : IActivityService
{
    private readonly IActivityRepository _repository;

    public ActivityService(IActivityRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ActivityResponseDto>> GetAllActivities()
    {
        var activities = await _repository.GetAllActivitiesAsync();
        return activities.Select(a => MapToResponseDto(a));
    }

    public async Task<ActivityResponseDto?> GetActivityById(Guid id)
    {
        var activity = await _repository.GetActivityByIdAsync(id);
        if (activity == null)
            return null;

        return MapToResponseDto(activity);
    }

    public async Task<IEnumerable<ActivityResponseDto>> GetActivitiesByMemoryId(Guid memoryId)
    {
        var activities = await _repository.GetActivitiesByMemoryIdAsync(memoryId);
        return activities.Select(a => MapToResponseDto(a));
    }

    public async Task<IEnumerable<ActivityResponseDto>> GetActivitiesByDateRange(DateOnly startDate, DateOnly endDate)
    {
        if (startDate > endDate)
            throw new Exception("La fecha de inicio no puede ser mayor a la fecha de fin");

        var activities = await _repository.GetActivitiesByDateRangeAsync(startDate, endDate);
        return activities.Select(a => MapToResponseDto(a));
    }

    public async Task<IEnumerable<ActivityResponseDto>> GetActivitiesByLocation(string location)
    {
        var activities = await _repository.GetActivitiesByLocationAsync(location);
        return activities.Select(a => MapToResponseDto(a));
    }

    public async Task<Guid> CreateActivity(CreateActivityDto dto)
    {
        var activity = new Activities
        {
            Id = Guid.NewGuid(),
            MemoryId = dto.MemoryId,
            Title = dto.Title,
            Description = dto.Description,
            Date = dto.Date,
            Location = dto.Location,
            Participants = dto.Participants,
            Photos = dto.Photos,
            DocumentsUrls = dto.DocumentsUrls,
            SortOrder = dto.SortOrder
        };

        await _repository.AddActivityAsync(activity);
        return activity.Id;
    }

    public async Task UpdateActivity(Guid id, UpdateActivityDto dto)
    {
        var activity = await _repository.GetActivityByIdAsync(id);
        if (activity == null)
            throw new Exception("Actividad no encontrada");

        activity.MemoryId = dto.MemoryId;
        activity.Title = dto.Title ?? activity.Title;
        activity.Description = dto.Description ?? activity.Description;
        activity.Date = dto.Date;
        activity.Location = dto.Location ?? activity.Location;
        activity.Participants = dto.Participants ?? activity.Participants;
        activity.Photos = dto.Photos ?? activity.Photos;
        activity.DocumentsUrls = dto.DocumentsUrls ?? activity.DocumentsUrls;
        activity.SortOrder = dto.SortOrder;

        await _repository.UpdateActivityAsync(activity);
    }

    public async Task DeleteActivity(Guid id)
    {
        await _repository.DeleteActivityAsync(id);
    }

    private ActivityResponseDto MapToResponseDto(Activities activity)
    {
        return new ActivityResponseDto
        {
            Id = activity.Id,
            MemoryId = activity.MemoryId,
            Title = activity.Title,
            Description = activity.Description,
            Date = activity.Date,
            Location = activity.Location,
            Participants = activity.Participants,
            Photos = activity.Photos,
            DocumentsUrls = activity.DocumentsUrls,
            SortOrder = activity.SortOrder
        };
    }
}
