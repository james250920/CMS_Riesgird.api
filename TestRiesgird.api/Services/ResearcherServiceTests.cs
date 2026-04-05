using Xunit;
using Moq;
using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Core.Core.Services;
using CMS_Riesgird.Domain.Models;

namespace TestRiesgird.api.Services;

public class ResearcherServiceTests
{
    private readonly Mock<IResearcherRepository> _mockRepository;
    private readonly ResearcherService _service;

    public ResearcherServiceTests()
    {
        _mockRepository = new Mock<IResearcherRepository>();
        _service = new ResearcherService(_mockRepository.Object);
    }

    [Fact]
    public async Task GetAllResearchers_ShouldReturnListOfResearchers()
    {
        // Arrange
        var researchers = new List<Researchers>
        {
            new Researchers 
            { 
                Id = Guid.NewGuid(), 
                FullName = "Dr. John Doe",
                Email = "john@example.com",
                UniversityId = Guid.NewGuid(),
                ResearchAreas = new List<string> { "AI", "ML" },
                IsActive = true,
                IsPublic = true,
                CreatedAt = DateTime.UtcNow
            },
            new Researchers 
            { 
                Id = Guid.NewGuid(), 
                FullName = "Dr. Jane Smith",
                Email = "jane@example.com",
                UniversityId = Guid.NewGuid(),
                ResearchAreas = new List<string> { "Data Science" },
                IsActive = true,
                IsPublic = true,
                CreatedAt = DateTime.UtcNow
            }
        };

        _mockRepository.Setup(r => r.GetAllResearchersAsync()).ReturnsAsync(researchers);

        // Act
        var result = await _service.GetAllResearchers();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
        _mockRepository.Verify(r => r.GetAllResearchersAsync(), Times.Once);
    }

    [Fact]
    public async Task GetResearcherById_WithValidId_ShouldReturnResearcher()
    {
        // Arrange
        var researcherId = Guid.NewGuid();
        var researcher = new Researchers
        {
            Id = researcherId,
            FullName = "Dr. John Doe",
            Email = "john@example.com",
            UniversityId = Guid.NewGuid(),
            ResearchAreas = new List<string> { "AI" },
            IsActive = true,
            IsPublic = true,
            CreatedAt = DateTime.UtcNow
        };

        _mockRepository.Setup(r => r.GetResearcherByIdAsync(researcherId)).ReturnsAsync(researcher);

        // Act
        var result = await _service.GetResearcherById(researcherId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(researcherId, result.Id);
        Assert.Equal("Dr. John Doe", result.FullName);
    }

    [Fact]
    public async Task GetResearcherById_WithInvalidId_ShouldReturnNull()
    {
        // Arrange
        var researcherId = Guid.NewGuid();
        _mockRepository.Setup(r => r.GetResearcherByIdAsync(researcherId)).ReturnsAsync((Researchers)null);

        // Act
        var result = await _service.GetResearcherById(researcherId);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task CreateResearcher_WithValidData_ShouldReturnResearcherId()
    {
        // Arrange
        var dto = new CreateResearcherDto
        {
            FullName = "Dr. New Researcher",
            Email = "new@example.com",
            UniversityId = Guid.NewGuid(),
            ResearchAreas = new List<string> { "Research" },
            IsActive = true,
            IsPublic = true
        };

        _mockRepository.Setup(r => r.AddResearcherAsync(It.IsAny<Researchers>())).Returns(Task.CompletedTask);

        // Act
        var result = await _service.CreateResearcher(dto);

        // Assert
        Assert.NotEqual(Guid.Empty, result);
        _mockRepository.Verify(r => r.AddResearcherAsync(It.IsAny<Researchers>()), Times.Once);
    }

    [Fact]
    public async Task UpdateResearcher_WithValidData_ShouldUpdateSuccessfully()
    {
        // Arrange
        var researcherId = Guid.NewGuid();
        var existingResearcher = new Researchers
        {
            Id = researcherId,
            FullName = "Dr. Old Name",
            Email = "old@example.com",
            UniversityId = Guid.NewGuid(),
            ResearchAreas = new List<string> { "Old Area" },
            IsActive = true,
            IsPublic = true,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        var updateDto = new UpdateResearcherDto
        {
            Id = researcherId,
            FullName = "Dr. New Name",
            Email = "new@example.com",
            UniversityId = Guid.NewGuid(),
            ResearchAreas = new List<string> { "New Area" },
            IsActive = true,
            IsPublic = true
        };

        _mockRepository.Setup(r => r.GetResearcherByIdAsync(researcherId)).ReturnsAsync(existingResearcher);
        _mockRepository.Setup(r => r.UpdateResearcherAsync(It.IsAny<Researchers>())).Returns(Task.CompletedTask);

        // Act
        await _service.UpdateResearcher(researcherId, updateDto);

        // Assert
        _mockRepository.Verify(r => r.UpdateResearcherAsync(It.IsAny<Researchers>()), Times.Once);
    }

    [Fact]
    public async Task DeleteResearcher_WithValidId_ShouldDeleteSuccessfully()
    {
        // Arrange
        var researcherId = Guid.NewGuid();
        _mockRepository.Setup(r => r.DeleteResearcherAsync(researcherId)).Returns(Task.CompletedTask);

        // Act
        await _service.DeleteResearcher(researcherId);

        // Assert
        _mockRepository.Verify(r => r.DeleteResearcherAsync(researcherId), Times.Once);
    }

    [Fact]
    public async Task GetPublicResearchers_ShouldReturnOnlyPublicResearchers()
    {
        // Arrange
        var researchers = new List<Researchers>
        {
            new Researchers { Id = Guid.NewGuid(), FullName = "Public Researcher", IsPublic = true, ResearchAreas = new List<string>() },
            new Researchers { Id = Guid.NewGuid(), FullName = "Private Researcher", IsPublic = false, ResearchAreas = new List<string>() }
        };

        _mockRepository.Setup(r => r.GetPublicResearchersAsync()).ReturnsAsync(researchers.Where(r => r.IsPublic).ToList());

        // Act
        var result = await _service.GetPublicResearchers();

        // Assert
        Assert.NotNull(result);
        Assert.All(result, r => Assert.True(r.IsPublic));
    }
}
