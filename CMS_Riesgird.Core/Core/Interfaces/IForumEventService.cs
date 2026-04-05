using CMS_Riesgird.Core.Core.DTOs;

namespace CMS_Riesgird.Core.Core.Interfaces;

public interface IForumEventService
{
    Task<IEnumerable<ForumEventResponseDto>> GetAllForumEvents();
    Task<ForumEventResponseDto?> GetForumEventById(Guid id);
    Task<IEnumerable<ForumEventResponseDto>> GetUpcomingForumEvents();
    Task<IEnumerable<ForumEventResponseDto>> GetPublicForumEvents();
    Task<IEnumerable<ForumEventResponseDto>> GetForumEventsByMonth(int month, int year);
    Task<Guid> CreateForumEvent(CreateForumEventDto dto);
    Task UpdateForumEvent(Guid id, UpdateForumEventDto dto);
    Task DeleteForumEvent(Guid id);
}
