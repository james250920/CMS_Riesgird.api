using Xunit;
using Moq;
using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Core.Core.Services;
using CMS_Riesgird.Domain.Models;

namespace TestRiesgird.api.Services;

public class CongressServiceTests
{
    private readonly Mock<ICongressRepository> _mockRepository;
    private readonly CongressService _service;

    public CongressServiceTests()
    {
        _mockRepository = new Mock<ICongressRepository>();
        _service = new CongressService(_mockRepository.Object);
    }

    [Fact]
    public async Task GetAllCongresses_ShouldReturnAllCongresses()
    {
        // Arrange
        var congresses = new List<Congresses>
        {
            new Congresses
            {
                Id = Guid.NewGuid(),
                Name = "Congress 1",
                Edition = 1,
                Year = 2024,
                StartDate = DateOnly.FromDateTime(DateTime.Now),
                EndDate = DateOnly.FromDateTime(DateTime.Now.AddDays(3)),
                Location = "Lima",
                Description = "Test Congress",
                IsPublic = true,
                CreatedAt = DateTime.UtcNow
            }
        };

        _mockRepository.Setup(r => r.GetAllCongressesAsync()).ReturnsAsync(congresses);

        // Act
        var result = await _service.GetAllCongresses();

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
    }

    [Fact]
    public async Task GetCongressById_WithValidId_ShouldReturnCongress()
    {
        // Arrange
        var congressId = Guid.NewGuid();
        var congress = new Congresses
        {
            Id = congressId,
            Name = "Test Congress",
            Edition = 1,
            Year = 2024,
            StartDate = DateOnly.FromDateTime(DateTime.Now),
            EndDate = DateOnly.FromDateTime(DateTime.Now.AddDays(3)),
            Location = "Lima",
            Description = "Description",
            IsPublic = true,
            CreatedAt = DateTime.UtcNow
        };

        _mockRepository.Setup(r => r.GetCongressByIdAsync(congressId)).ReturnsAsync(congress);

        // Act
        var result = await _service.GetCongressById(congressId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(congressId, result.Id);
        Assert.Equal("Test Congress", result.Name);
    }

    [Fact]
    public async Task CreateCongress_WithValidData_ShouldReturnCongressId()
    {
        // Arrange
        var dto = new CreateCongressDto
        {
            Name = "New Congress",
            Edition = 1,
            Year = 2024,
            StartDate = DateOnly.FromDateTime(DateTime.Now),
            EndDate = DateOnly.FromDateTime(DateTime.Now.AddDays(3)),
            Location = "Lima",
            Description = "New Congress Description",
            IsPublic = true
        };

        _mockRepository.Setup(r => r.AddCongressAsync(It.IsAny<Congresses>())).Returns(Task.CompletedTask);

        // Act
        var result = await _service.CreateCongress(dto);

        // Assert
        Assert.NotEqual(Guid.Empty, result);
        _mockRepository.Verify(r => r.AddCongressAsync(It.IsAny<Congresses>()), Times.Once);
    }

    [Fact]
    public async Task GetPublicCongresses_ShouldReturnOnlyPublicCongresses()
    {
        // Arrange
        var congresses = new List<Congresses>
        {
            new Congresses { Id = Guid.NewGuid(), Name = "Public", IsPublic = true, Edition = 1, Year = 2024, Location = "Lima", Description = "Desc", StartDate = DateOnly.FromDateTime(DateTime.Now), EndDate = DateOnly.FromDateTime(DateTime.Now), CreatedAt = DateTime.UtcNow },
            new Congresses { Id = Guid.NewGuid(), Name = "Private", IsPublic = false, Edition = 2, Year = 2024, Location = "Lima", Description = "Desc", StartDate = DateOnly.FromDateTime(DateTime.Now), EndDate = DateOnly.FromDateTime(DateTime.Now), CreatedAt = DateTime.UtcNow }
        };

        _mockRepository.Setup(r => r.GetPublicCongressesAsync()).ReturnsAsync(congresses.Where(c => c.IsPublic).ToList());

        // Act
        var result = await _service.GetPublicCongresses();

        // Assert
        Assert.NotNull(result);
        Assert.All(result, c => Assert.True(c.IsPublic));
    }

    [Fact]
    public async Task GetCongressesByYear_ShouldReturnCongressesForSpecificYear()
    {
        // Arrange
        var year = 2024;
        var congresses = new List<Congresses>
        {
            new Congresses { Id = Guid.NewGuid(), Name = "2024 Congress", Year = 2024, Edition = 1, Location = "Lima", Description = "Desc", StartDate = DateOnly.FromDateTime(DateTime.Now), EndDate = DateOnly.FromDateTime(DateTime.Now), IsPublic = true, CreatedAt = DateTime.UtcNow }
        };

        _mockRepository.Setup(r => r.GetCongressesByYearAsync(year)).ReturnsAsync(congresses);

        // Act
        var result = await _service.GetCongressesByYear(year);

        // Assert
        Assert.NotNull(result);
        Assert.All(result, c => Assert.Equal(2024, c.Year));
    }

    [Fact]
    public async Task UpdateCongress_WithValidData_ShouldUpdateSuccessfully()
    {
        // Arrange
        var congressId = Guid.NewGuid();
        var existing = new Congresses
        {
            Id = congressId,
            Name = "Old Name",
            Edition = 1,
            Year = 2024,
            Location = "Lima",
            Description = "Desc",
            StartDate = DateOnly.FromDateTime(DateTime.Now),
            EndDate = DateOnly.FromDateTime(DateTime.Now),
            IsPublic = true,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        var updateDto = new UpdateCongressDto
        {
            Id = congressId,
            Name = "New Name",
            Edition = 1,
            Year = 2024,
            Location = "Lima",
            Description = "Desc",
            StartDate = DateOnly.FromDateTime(DateTime.Now),
            EndDate = DateOnly.FromDateTime(DateTime.Now),
            IsPublic = true
        };

        _mockRepository.Setup(r => r.GetCongressByIdAsync(congressId)).ReturnsAsync(existing);
        _mockRepository.Setup(r => r.UpdateCongressAsync(It.IsAny<Congresses>())).Returns(Task.CompletedTask);

        // Act
        await _service.UpdateCongress(congressId, updateDto);

        // Assert
        _mockRepository.Verify(r => r.UpdateCongressAsync(It.IsAny<Congresses>()), Times.Once);
    }
}
