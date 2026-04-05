using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Core.Interfaces;

public interface IForumEventRepository
{
    Task<IEnumerable<ForumEvents>> GetAllForumEventsAsync();
    Task<ForumEvents?> GetForumEventByIdAsync(Guid id);
    Task<IEnumerable<ForumEvents>> GetUpcomingForumEventsAsync();
    Task<IEnumerable<ForumEvents>> GetPublicForumEventsAsync();
    Task<IEnumerable<ForumEvents>> GetForumEventsByMonthAsync(int month, int year);
    Task AddForumEventAsync(ForumEvents forumEvent);
    Task UpdateForumEventAsync(ForumEvents forumEvent);
    Task DeleteForumEventAsync(Guid id);
}
