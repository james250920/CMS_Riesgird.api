using Xunit;
using Moq;
using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Core.Core.Services;
using CMS_Riesgird.Domain.Models;

namespace TestRiesgird.api.Services;

public class SpeakerServiceTests
{
    private readonly Mock<ISpeakerRepository> _mockRepository;
    private readonly SpeakerService _service;

    public SpeakerServiceTests()
    {
        _mockRepository = new Mock<ISpeakerRepository>();
        _service = new SpeakerService(_mockRepository.Object);
    }

    [Fact]
    public async Task GetAllSpeakers_ShouldReturnAllSpeakers()
    {
        // Arrange
        var speakers = new List<Speakers>
        {
            new Speakers
            {
                Id = Guid.NewGuid(),
                CongressId = Guid.NewGuid(),
                FullName = "Dr. Speaker 1",
                Title = "Dr.",
                Institution = "University",
                Country = "Peru"
            }
        };

        _mockRepository.Setup(r => r.GetAllSpeakersAsync()).ReturnsAsync(speakers);

        // Act
        var result = await _service.GetAllSpeakers();

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
    }

    [Fact]
    public async Task GetSpeakerById_WithValidId_ShouldReturnSpeaker()
    {
        // Arrange
        var speakerId = Guid.NewGuid();
        var speaker = new Speakers
        {
            Id = speakerId,
            CongressId = Guid.NewGuid(),
            FullName = "Dr. Test",
            Title = "Dr.",
            Institution = "University",
            Country = "Peru"
        };

        _mockRepository.Setup(r => r.GetSpeakerByIdAsync(speakerId)).ReturnsAsync(speaker);

        // Act
        var result = await _service.GetSpeakerById(speakerId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(speakerId, result.Id);
        Assert.Equal("Dr. Test", result.FullName);
    }

    [Fact]
    public async Task CreateSpeaker_WithValidData_ShouldReturnSpeakerId()
    {
        // Arrange
        var dto = new CreateSpeakerDto
        {
            CongressId = Guid.NewGuid(),
            FullName = "New Speaker",
            Title = "Dr.",
            Institution = "University",
            Country = "Peru"
        };

        _mockRepository.Setup(r => r.AddSpeakerAsync(It.IsAny<Speakers>())).Returns(Task.CompletedTask);

        // Act
        var result = await _service.CreateSpeaker(dto);

        // Assert
        Assert.NotEqual(Guid.Empty, result);
        _mockRepository.Verify(r => r.AddSpeakerAsync(It.IsAny<Speakers>()), Times.Once);
    }

    [Fact]
    public async Task GetSpeakersByCongressId_ShouldReturnSpeakersForCongress()
    {
        // Arrange
        var congressId = Guid.NewGuid();
        var speakers = new List<Speakers>
        {
            new Speakers { Id = Guid.NewGuid(), CongressId = congressId, FullName = "Speaker", Title = "Dr.", Institution = "Uni", Country = "Peru" }
        };

        _mockRepository.Setup(r => r.GetSpeakersByCongressIdAsync(congressId)).ReturnsAsync(speakers);

        // Act
        var result = await _service.GetSpeakersByCongressId(congressId);

        // Assert
        Assert.NotNull(result);
        Assert.All(result, s => Assert.Equal(congressId, s.CongressId));
    }

    [Fact]
    public async Task GetSpeakersByCountry_ShouldReturnSpeakersFromCountry()
    {
        // Arrange
        var country = "Peru";
        var speakers = new List<Speakers>
        {
            new Speakers { Id = Guid.NewGuid(), CongressId = Guid.NewGuid(), FullName = "Peru Speaker", Title = "Dr.", Institution = "Uni", Country = "Peru" }
        };

        _mockRepository.Setup(r => r.GetSpeakersByCountryAsync(country)).ReturnsAsync(speakers);

        // Act
        var result = await _service.GetSpeakersByCountry(country);

        // Assert
        Assert.NotNull(result);
        Assert.All(result, s => Assert.Equal("Peru", s.Country));
    }

    [Fact]
    public async Task UpdateSpeaker_WithValidData_ShouldUpdateSuccessfully()
    {
        // Arrange
        var speakerId = Guid.NewGuid();
        var existing = new Speakers
        {
            Id = speakerId,
            CongressId = Guid.NewGuid(),
            FullName = "Old Name",
            Title = "Dr.",
            Institution = "Uni",
            Country = "Peru"
        };

        var updateDto = new UpdateSpeakerDto
        {
            Id = speakerId,
            CongressId = Guid.NewGuid(),
            FullName = "New Name",
            Title = "Prof.",
            Institution = "Uni",
            Country = "Peru"
        };

        _mockRepository.Setup(r => r.GetSpeakerByIdAsync(speakerId)).ReturnsAsync(existing);
        _mockRepository.Setup(r => r.UpdateSpeakerAsync(It.IsAny<Speakers>())).Returns(Task.CompletedTask);

        // Act
        await _service.UpdateSpeaker(speakerId, updateDto);

        // Assert
        _mockRepository.Verify(r => r.UpdateSpeakerAsync(It.IsAny<Speakers>()), Times.Once);
    }
}
