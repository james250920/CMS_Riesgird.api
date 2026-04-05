using Xunit;
using Moq;
using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Core.Core.Services;
using CMS_Riesgird.Domain.Models;

namespace TestRiesgird.api.Services;

public class UniversityServiceTests
{
    private readonly Mock<IUniversityRepository> _mockRepository;
    private readonly UniversityService _service;

    public UniversityServiceTests()
    {
        _mockRepository = new Mock<IUniversityRepository>();
        _service = new UniversityService(_mockRepository.Object);
    }

    [Fact]
    public async Task GetAllUniversities_ShouldReturnAllUniversities()
    {
        // Arrange
        var universities = new List<Universities>
        {
            new Universities { Id = Guid.NewGuid(), Name = "University 1", IsActive = true, CreatedAt = DateTime.UtcNow },
            new Universities { Id = Guid.NewGuid(), Name = "University 2", IsActive = true, CreatedAt = DateTime.UtcNow }
        };

        _mockRepository.Setup(r => r.GetAllUniversitiesAsync()).ReturnsAsync(universities);

        // Act
        var result = await _service.GetAllUniversities();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
    }

    [Fact]
    public async Task GetUniversityById_WithValidId_ShouldReturnUniversity()
    {
        // Arrange
        var universityId = Guid.NewGuid();
        var university = new Universities
        {
            Id = universityId,
            Name = "Test University",
            IsActive = true,
            CreatedAt = DateTime.UtcNow
        };

        _mockRepository.Setup(r => r.GetUniversityByIdAsync(universityId)).ReturnsAsync(university);

        // Act
        var result = await _service.GetUniversityById(universityId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(universityId, result.Id);
        Assert.Equal("Test University", result.Name);
    }

    [Fact]
    public async Task CreateUniversity_WithValidData_ShouldReturnUniversityId()
    {
        // Arrange
        var dto = new CreateUniversityDto
        {
            Name = "New University",
            IsActive = true
        };

        _mockRepository.Setup(r => r.AddUniversityAsync(It.IsAny<Universities>())).Returns(Task.CompletedTask);

        // Act
        var result = await _service.CreateUniversity(dto);

        // Assert
        Assert.NotEqual(Guid.Empty, result);
        _mockRepository.Verify(r => r.AddUniversityAsync(It.IsAny<Universities>()), Times.Once);
    }

    [Fact]
    public async Task GetActiveUniversities_ShouldReturnOnlyActiveUniversities()
    {
        // Arrange
        var universities = new List<Universities>
        {
            new Universities { Id = Guid.NewGuid(), Name = "Active Uni", IsActive = true, CreatedAt = DateTime.UtcNow },
            new Universities { Id = Guid.NewGuid(), Name = "Inactive Uni", IsActive = false, CreatedAt = DateTime.UtcNow }
        };

        _mockRepository.Setup(r => r.GetActiveUniversitiesAsync()).ReturnsAsync(universities.Where(u => u.IsActive).ToList());

        // Act
        var result = await _service.GetActiveUniversities();

        // Assert
        Assert.NotNull(result);
        Assert.All(result, u => Assert.True(u.IsActive));
    }

    [Fact]
    public async Task UpdateUniversity_WithValidData_ShouldUpdateSuccessfully()
    {
        // Arrange
        var universityId = Guid.NewGuid();
        var existing = new Universities { Id = universityId, Name = "Old Name", IsActive = true, CreatedAt = DateTime.UtcNow };
        var updateDto = new UpdateUniversityDto { Id = universityId, Name = "New Name", IsActive = true };

        _mockRepository.Setup(r => r.GetUniversityByIdAsync(universityId)).ReturnsAsync(existing);
        _mockRepository.Setup(r => r.UpdateUniversityAsync(It.IsAny<Universities>())).Returns(Task.CompletedTask);

        // Act
        await _service.UpdateUniversity(universityId, updateDto);

        // Assert
        _mockRepository.Verify(r => r.UpdateUniversityAsync(It.IsAny<Universities>()), Times.Once);
    }

    [Fact]
    public async Task DeleteUniversity_WithValidId_ShouldDeleteSuccessfully()
    {
        // Arrange
        var universityId = Guid.NewGuid();
        _mockRepository.Setup(r => r.DeleteUniversityAsync(universityId)).Returns(Task.CompletedTask);

        // Act
        await _service.DeleteUniversity(universityId);

        // Assert
        _mockRepository.Verify(r => r.DeleteUniversityAsync(universityId), Times.Once);
    }
}
