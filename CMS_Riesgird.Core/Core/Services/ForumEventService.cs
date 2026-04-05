using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Core.Services;

public class ForumEventService : IForumEventService
{
    private readonly IForumEventRepository _repository;

    public ForumEventService(IForumEventRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ForumEventResponseDto>> GetAllForumEvents()
    {
        var forumEvents = await _repository.GetAllForumEventsAsync();
        return forumEvents.Select(f => MapToResponseDto(f));
    }

    public async Task<ForumEventResponseDto?> GetForumEventById(Guid id)
    {
        var forumEvent = await _repository.GetForumEventByIdAsync(id);
        if (forumEvent == null)
            return null;

        return MapToResponseDto(forumEvent);
    }

    public async Task<IEnumerable<ForumEventResponseDto>> GetUpcomingForumEvents()
    {
        var forumEvents = await _repository.GetUpcomingForumEventsAsync();
        return forumEvents.Select(f => MapToResponseDto(f));
    }

    public async Task<IEnumerable<ForumEventResponseDto>> GetPublicForumEvents()
    {
        var forumEvents = await _repository.GetPublicForumEventsAsync();
        return forumEvents.Select(f => MapToResponseDto(f));
    }

    public async Task<IEnumerable<ForumEventResponseDto>> GetForumEventsByMonth(int month, int year)
    {
        var forumEvents = await _repository.GetForumEventsByMonthAsync(month, year);
        return forumEvents.Select(f => MapToResponseDto(f));
    }

    public async Task<Guid> CreateForumEvent(CreateForumEventDto dto)
    {
        var forumEvent = new ForumEvents
        {
            Id = Guid.NewGuid(),
            Title = dto.Title,
            Description = dto.Description,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate,
            Location = dto.Location,
            BannerUrl = dto.BannerUrl,
            Organizers = dto.Organizers,
            TargetAudience = dto.TargetAudience,
            Capacity = dto.Capacity,
            RegisteredCount = dto.RegisteredCount,
            RequiresRegistration = dto.RequiresRegistration,
            VirtualLink = dto.VirtualLink,
            ProgramFileUrl = dto.ProgramFileUrl,
            RegistrationUrl = dto.RegistrationUrl,
            MaxParticipants = dto.MaxParticipants,
            CurrentParticipants = dto.CurrentParticipants,
            IsPublic = dto.IsPublic,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            CreatedBy = dto.CreatedBy
        };

        await _repository.AddForumEventAsync(forumEvent);
        return forumEvent.Id;
    }

    public async Task UpdateForumEvent(Guid id, UpdateForumEventDto dto)
    {
        var forumEvent = await _repository.GetForumEventByIdAsync(id);
        if (forumEvent == null)
            throw new Exception("Evento de foro no encontrado");

        forumEvent.Title = dto.Title ?? forumEvent.Title;
        forumEvent.Description = dto.Description ?? forumEvent.Description;
        forumEvent.StartDate = dto.StartDate;
        forumEvent.EndDate = dto.EndDate ?? forumEvent.EndDate;
        forumEvent.Location = dto.Location ?? forumEvent.Location;
        forumEvent.BannerUrl = dto.BannerUrl ?? forumEvent.BannerUrl;
        forumEvent.Organizers = dto.Organizers ?? forumEvent.Organizers;
        forumEvent.TargetAudience = dto.TargetAudience ?? forumEvent.TargetAudience;
        forumEvent.Capacity = dto.Capacity ?? forumEvent.Capacity;
        forumEvent.RegisteredCount = dto.RegisteredCount ?? forumEvent.RegisteredCount;
        forumEvent.RequiresRegistration = dto.RequiresRegistration ?? forumEvent.RequiresRegistration;
        forumEvent.VirtualLink = dto.VirtualLink ?? forumEvent.VirtualLink;
        forumEvent.ProgramFileUrl = dto.ProgramFileUrl ?? forumEvent.ProgramFileUrl;
        forumEvent.RegistrationUrl = dto.RegistrationUrl ?? forumEvent.RegistrationUrl;
        forumEvent.MaxParticipants = dto.MaxParticipants ?? forumEvent.MaxParticipants;
        forumEvent.CurrentParticipants = dto.CurrentParticipants ?? forumEvent.CurrentParticipants;
        forumEvent.IsPublic = dto.IsPublic;
        forumEvent.UpdatedAt = DateTime.UtcNow;

        await _repository.UpdateForumEventAsync(forumEvent);
    }

    public async Task DeleteForumEvent(Guid id)
    {
        await _repository.DeleteForumEventAsync(id);
    }

    private ForumEventResponseDto MapToResponseDto(ForumEvents forumEvent)
    {
        return new ForumEventResponseDto
        {
            Id = forumEvent.Id,
            Title = forumEvent.Title,
            Description = forumEvent.Description,
            StartDate = forumEvent.StartDate,
            EndDate = forumEvent.EndDate,
            Location = forumEvent.Location,
            BannerUrl = forumEvent.BannerUrl,
            Organizers = forumEvent.Organizers,
            TargetAudience = forumEvent.TargetAudience,
            Capacity = forumEvent.Capacity,
            RegisteredCount = forumEvent.RegisteredCount,
            RequiresRegistration = forumEvent.RequiresRegistration,
            VirtualLink = forumEvent.VirtualLink,
            ProgramFileUrl = forumEvent.ProgramFileUrl,
            RegistrationUrl = forumEvent.RegistrationUrl,
            MaxParticipants = forumEvent.MaxParticipants,
            CurrentParticipants = forumEvent.CurrentParticipants,
            IsPublic = forumEvent.IsPublic,
            CreatedAt = forumEvent.CreatedAt,
            UpdatedAt = forumEvent.UpdatedAt
        };
    }
}
