using Xunit;
using Moq;
using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Core.Core.Services;
using CMS_Riesgird.Domain.Models;

namespace TestRiesgird.api.Services;

public class ForumEventServiceTests
{
    private readonly Mock<IForumEventRepository> _mockRepository;
    private readonly ForumEventService _service;

    public ForumEventServiceTests()
    {
        _mockRepository = new Mock<IForumEventRepository>();
        _service = new ForumEventService(_mockRepository.Object);
    }

    [Fact]
    public async Task GetAllForumEvents_ShouldReturnAllEvents()
    {
        // Arrange
        var events = new List<ForumEvents>
        {
            new ForumEvents
            {
                Id = Guid.NewGuid(),
                Title = "Forum Event 1",
                Description = "Event description",
                StartDate = DateTime.Now.AddDays(1),
                Location = "Lima",
                IsPublic = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            }
        };

        _mockRepository.Setup(r => r.GetAllForumEventsAsync()).ReturnsAsync(events);

        // Act
        var result = await _service.GetAllForumEvents();

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
    }

    [Fact]
    public async Task GetForumEventById_WithValidId_ShouldReturnEvent()
    {
        // Arrange
        var eventId = Guid.NewGuid();
        var forumEvent = new ForumEvents
        {
            Id = eventId,
            Title = "Test Event",
            Description = "Test",
            StartDate = DateTime.Now.AddDays(1),
            Location = "Lima",
            IsPublic = true,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _mockRepository.Setup(r => r.GetForumEventByIdAsync(eventId)).ReturnsAsync(forumEvent);

        // Act
        var result = await _service.GetForumEventById(eventId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(eventId, result.Id);
        Assert.Equal("Test Event", result.Title);
    }

    [Fact]
    public async Task CreateForumEvent_WithValidData_ShouldReturnEventId()
    {
        // Arrange
        var dto = new CreateForumEventDto
        {
            Title = "New Event",
            Description = "New Event Description",
            StartDate = DateTime.Now.AddDays(1),
            Location = "Lima",
            IsPublic = true
        };

        _mockRepository.Setup(r => r.AddForumEventAsync(It.IsAny<ForumEvents>())).Returns(Task.CompletedTask);

        // Act
        var result = await _service.CreateForumEvent(dto);

        // Assert
        Assert.NotEqual(Guid.Empty, result);
        _mockRepository.Verify(r => r.AddForumEventAsync(It.IsAny<ForumEvents>()), Times.Once);
    }

    [Fact]
    public async Task GetPublicForumEvents_ShouldReturnOnlyPublicEvents()
    {
        // Arrange
        var events = new List<ForumEvents>
        {
            new ForumEvents { Id = Guid.NewGuid(), Title = "Public", Description = "Desc", StartDate = DateTime.Now, Location = "Lima", IsPublic = true, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new ForumEvents { Id = Guid.NewGuid(), Title = "Private", Description = "Desc", StartDate = DateTime.Now, Location = "Lima", IsPublic = false, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
        };

        _mockRepository.Setup(r => r.GetPublicForumEventsAsync()).ReturnsAsync(events.Where(e => e.IsPublic).ToList());

        // Act
        var result = await _service.GetPublicForumEvents();

        // Assert
        Assert.NotNull(result);
        Assert.All(result, e => Assert.True(e.IsPublic));
    }

    [Fact]
    public async Task GetUpcomingForumEvents_ShouldReturnFutureEvents()
    {
        // Arrange
        var futureDate = DateTime.Now.AddDays(5);
        var events = new List<ForumEvents>
        {
            new ForumEvents { Id = Guid.NewGuid(), Title = "Upcoming", Description = "Desc", StartDate = futureDate, Location = "Lima", IsPublic = true, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
        };

        _mockRepository.Setup(r => r.GetUpcomingForumEventsAsync()).ReturnsAsync(events);

        // Act
        var result = await _service.GetUpcomingForumEvents();

        // Assert
        Assert.NotNull(result);
        Assert.All(result, e => Assert.True(e.StartDate > DateTime.Now));
    }

    [Fact]
    public async Task UpdateForumEvent_WithValidData_ShouldUpdateSuccessfully()
    {
        // Arrange
        var eventId = Guid.NewGuid();
        var existing = new ForumEvents
        {
            Id = eventId,
            Title = "Old Title",
            Description = "Old",
            StartDate = DateTime.Now,
            Location = "Lima",
            IsPublic = true,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        var updateDto = new UpdateForumEventDto
        {
            Id = eventId,
            Title = "New Title",
            Description = "New",
            StartDate = DateTime.Now.AddDays(1),
            Location = "Lima",
            IsPublic = true
        };

        _mockRepository.Setup(r => r.GetForumEventByIdAsync(eventId)).ReturnsAsync(existing);
        _mockRepository.Setup(r => r.UpdateForumEventAsync(It.IsAny<ForumEvents>())).Returns(Task.CompletedTask);

        // Act
        await _service.UpdateForumEvent(eventId, updateDto);

        // Assert
        _mockRepository.Verify(r => r.UpdateForumEventAsync(It.IsAny<ForumEvents>()), Times.Once);
    }
}
