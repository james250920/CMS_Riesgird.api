using Xunit;
using Moq;
using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Core.Core.Services;
using CMS_Riesgird.Domain.Models;

namespace TestRiesgird.api.Services;

public class ExpertServiceTests
{
    private readonly Mock<IExpertRepository> _mockRepository;
    private readonly ExpertService _service;

    public ExpertServiceTests()
    {
        _mockRepository = new Mock<IExpertRepository>();
        _service = new ExpertService(_mockRepository.Object);
    }

    [Fact]
    public async Task GetAllExperts_ShouldReturnAllExperts()
    {
        // Arrange
        var experts = new List<Experts>
        {
            new Experts
            {
                Id = Guid.NewGuid(),
                FullName = "Dr. Expert 1",
                Email = "expert1@example.com",
                Country = "Peru",
                ExpertiseAreas = new List<string> { "Risk Management" },
                IsActive = true,
                IsPublic = true,
                CreatedAt = DateTime.UtcNow
            }
        };

        _mockRepository.Setup(r => r.GetAllExpertsAsync()).ReturnsAsync(experts);

        // Act
        var result = await _service.GetAllExperts();

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
    }

    [Fact]
    public async Task GetExpertById_WithValidId_ShouldReturnExpert()
    {
        // Arrange
        var expertId = Guid.NewGuid();
        var expert = new Experts
        {
            Id = expertId,
            FullName = "Dr. Test Expert",
            Email = "test@example.com",
            Country = "Peru",
            ExpertiseAreas = new List<string> { "Risk" },
            IsActive = true,
            IsPublic = true,
            CreatedAt = DateTime.UtcNow
        };

        _mockRepository.Setup(r => r.GetExpertByIdAsync(expertId)).ReturnsAsync(expert);

        // Act
        var result = await _service.GetExpertById(expertId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expertId, result.Id);
        Assert.Equal("Dr. Test Expert", result.FullName);
    }

    [Fact]
    public async Task CreateExpert_WithValidData_ShouldReturnExpertId()
    {
        // Arrange
        var dto = new CreateExpertDto
        {
            FullName = "New Expert",
            Email = "new@example.com",
            Country = "Peru",
            ExpertiseAreas = new List<string> { "Risk Management" },
            IsActive = true,
            IsPublic = true
        };

        _mockRepository.Setup(r => r.AddExpertAsync(It.IsAny<Experts>())).Returns(Task.CompletedTask);

        // Act
        var result = await _service.CreateExpert(dto);

        // Assert
        Assert.NotEqual(Guid.Empty, result);
        _mockRepository.Verify(r => r.AddExpertAsync(It.IsAny<Experts>()), Times.Once);
    }

    [Fact]
    public async Task GetPublicExperts_ShouldReturnOnlyPublicExperts()
    {
        // Arrange
        var experts = new List<Experts>
        {
            new Experts { Id = Guid.NewGuid(), FullName = "Public Expert", Email = "pub@example.com", Country = "Peru", ExpertiseAreas = new List<string>(), IsPublic = true, IsActive = true, CreatedAt = DateTime.UtcNow },
            new Experts { Id = Guid.NewGuid(), FullName = "Private Expert", Email = "priv@example.com", Country = "Peru", ExpertiseAreas = new List<string>(), IsPublic = false, IsActive = true, CreatedAt = DateTime.UtcNow }
        };

        _mockRepository.Setup(r => r.GetPublicExpertsAsync()).ReturnsAsync(experts.Where(e => e.IsPublic).ToList());

        // Act
        var result = await _service.GetPublicExperts();

        // Assert
        Assert.NotNull(result);
        Assert.All(result, e => Assert.True(e.IsPublic));
    }

    [Fact]
    public async Task GetExpertsByExpertiseArea_ShouldReturnExpertsInSpecificArea()
    {
        // Arrange
        var expertise = "Risk Management";
        var experts = new List<Experts>
        {
            new Experts { Id = Guid.NewGuid(), FullName = "Risk Expert", Email = "risk@example.com", Country = "Peru", ExpertiseAreas = new List<string> { "Risk Management" }, IsPublic = true, IsActive = true, CreatedAt = DateTime.UtcNow }
        };

        _mockRepository.Setup(r => r.GetExpertsByExpertiseAreaAsync(expertise)).ReturnsAsync(experts);

        // Act
        var result = await _service.GetExpertsByExpertiseArea(expertise);

        // Assert
        Assert.NotNull(result);
        Assert.All(result, e => Assert.Contains("Risk Management", e.ExpertiseAreas));
    }

    [Fact]
    public async Task UpdateExpert_WithValidData_ShouldUpdateSuccessfully()
    {
        // Arrange
        var expertId = Guid.NewGuid();
        var existing = new Experts
        {
            Id = expertId,
            FullName = "Old Name",
            Email = "old@example.com",
            Country = "Peru",
            ExpertiseAreas = new List<string> { "Old" },
            IsActive = true,
            IsPublic = true,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        var updateDto = new UpdateExpertDto
        {
            Id = expertId,
            FullName = "New Name",
            Email = "new@example.com",
            Country = "Peru",
            ExpertiseAreas = new List<string> { "New" },
            IsActive = true,
            IsPublic = true
        };

        _mockRepository.Setup(r => r.GetExpertByIdAsync(expertId)).ReturnsAsync(existing);
        _mockRepository.Setup(r => r.UpdateExpertAsync(It.IsAny<Experts>())).Returns(Task.CompletedTask);

        // Act
        await _service.UpdateExpert(expertId, updateDto);

        // Assert
        _mockRepository.Verify(r => r.UpdateExpertAsync(It.IsAny<Experts>()), Times.Once);
    }
}
