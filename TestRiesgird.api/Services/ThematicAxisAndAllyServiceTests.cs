using Xunit;
using Moq;
using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Core.Core.Services;
using CMS_Riesgird.Domain.Models;

namespace TestRiesgird.api.Services;

public class ThematicAxisServiceTests
{
    private readonly Mock<IThematicAxisRepository> _mockRepository;
    private readonly ThematicAxisService _service;

    public ThematicAxisServiceTests()
    {
        _mockRepository = new Mock<IThematicAxisRepository>();
        _service = new ThematicAxisService(_mockRepository.Object);
    }

    [Fact]
    public async Task GetAllAxes_ShouldReturnAllAxes()
    {
        // Arrange
        var axes = new List<ThematicAxes>
        {
            new ThematicAxes
            {
                Id = Guid.NewGuid(),
                CongressId = Guid.NewGuid(),
                Name = "Risk Management",
                Description = "Risk management axis",
                SortOrder = 1
            }
        };

        _mockRepository.Setup(r => r.GetAllAxesAsync()).ReturnsAsync(axes);

        // Act
        var result = await _service.GetAllAxes();

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
    }

    [Fact]
    public async Task GetAxisById_WithValidId_ShouldReturnAxis()
    {
        // Arrange
        var axisId = Guid.NewGuid();
        var axis = new ThematicAxes
        {
            Id = axisId,
            CongressId = Guid.NewGuid(),
            Name = "Test Axis",
            Description = "Test",
            SortOrder = 1
        };

        _mockRepository.Setup(r => r.GetAxisByIdAsync(axisId)).ReturnsAsync(axis);

        // Act
        var result = await _service.GetAxisById(axisId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(axisId, result.Id);
        Assert.Equal("Test Axis", result.Name);
    }

    [Fact]
    public async Task CreateAxis_WithValidData_ShouldReturnAxisId()
    {
        // Arrange
        var dto = new CreateThematicAxisDto
        {
            CongressId = Guid.NewGuid(),
            Name = "New Axis",
            Description = "New Axis Description",
            SortOrder = 2
        };

        _mockRepository.Setup(r => r.AddAxisAsync(It.IsAny<ThematicAxes>())).Returns(Task.CompletedTask);

        // Act
        var result = await _service.CreateAxis(dto);

        // Assert
        Assert.NotEqual(Guid.Empty, result);
        _mockRepository.Verify(r => r.AddAxisAsync(It.IsAny<ThematicAxes>()), Times.Once);
    }

    [Fact]
    public async Task GetAxesByCongressId_ShouldReturnAxesForCongress()
    {
        // Arrange
        var congressId = Guid.NewGuid();
        var axes = new List<ThematicAxes>
        {
            new ThematicAxes { Id = Guid.NewGuid(), CongressId = congressId, Name = "Axis", Description = "Desc", SortOrder = 1 }
        };

        _mockRepository.Setup(r => r.GetAxesByCongressIdAsync(congressId)).ReturnsAsync(axes);

        // Act
        var result = await _service.GetAxesByCongressId(congressId);

        // Assert
        Assert.NotNull(result);
        Assert.All(result, a => Assert.Equal(congressId, a.CongressId));
    }

    [Fact]
    public async Task UpdateAxis_WithValidData_ShouldUpdateSuccessfully()
    {
        // Arrange
        var axisId = Guid.NewGuid();
        var existing = new ThematicAxes
        {
            Id = axisId,
            CongressId = Guid.NewGuid(),
            Name = "Old Name",
            Description = "Old",
            SortOrder = 1
        };

        var updateDto = new UpdateThematicAxisDto
        {
            Id = axisId,
            CongressId = Guid.NewGuid(),
            Name = "New Name",
            Description = "New",
            SortOrder = 2
        };

        _mockRepository.Setup(r => r.GetAxisByIdAsync(axisId)).ReturnsAsync(existing);
        _mockRepository.Setup(r => r.UpdateAxisAsync(It.IsAny<ThematicAxes>())).Returns(Task.CompletedTask);

        // Act
        await _service.UpdateAxis(axisId, updateDto);

        // Assert
        _mockRepository.Verify(r => r.UpdateAxisAsync(It.IsAny<ThematicAxes>()), Times.Once);
    }
}

public class AllyServiceTests
{
    private readonly Mock<IAllyRepository> _mockRepository;
    private readonly AllyService _service;

    public AllyServiceTests()
    {
        _mockRepository = new Mock<IAllyRepository>();
        _service = new AllyService(_mockRepository.Object);
    }

    [Fact]
    public async Task GetAllAllies_ShouldReturnAllAllies()
    {
        // Arrange
        var allies = new List<Allies>
        {
            new Allies
            {
                Id = Guid.NewGuid(),
                Name = "Ally 1",
                LogoUrl = "http://logo1.png",
                IsActive = true,
                IsPublic = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            }
        };

        _mockRepository.Setup(r => r.GetAllAlliesAsync()).ReturnsAsync(allies);

        // Act
        var result = await _service.GetAllAllies();

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
    }

    [Fact]
    public async Task GetAllyById_WithValidId_ShouldReturnAlly()
    {
        // Arrange
        var allyId = Guid.NewGuid();
        var ally = new Allies
        {
            Id = allyId,
            Name = "Test Ally",
            LogoUrl = "http://test.png",
            IsActive = true,
            IsPublic = true,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _mockRepository.Setup(r => r.GetAllyByIdAsync(allyId)).ReturnsAsync(ally);

        // Act
        var result = await _service.GetAllyById(allyId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(allyId, result.Id);
        Assert.Equal("Test Ally", result.Name);
    }

    [Fact]
    public async Task CreateAlly_WithValidData_ShouldReturnAllyId()
    {
        // Arrange
        var dto = new CreateAllyDto
        {
            Name = "New Ally",
            LogoUrl = "http://new.png",
            IsActive = true,
            IsPublic = true,
            SortOrder = 1
        };

        _mockRepository.Setup(r => r.AddAllyAsync(It.IsAny<Allies>())).Returns(Task.CompletedTask);

        // Act
        var result = await _service.CreateAlly(dto);

        // Assert
        Assert.NotEqual(Guid.Empty, result);
        _mockRepository.Verify(r => r.AddAllyAsync(It.IsAny<Allies>()), Times.Once);
    }

    [Fact]
    public async Task GetPublicAllies_ShouldReturnOnlyPublicAllies()
    {
        // Arrange
        var allies = new List<Allies>
        {
            new Allies { Id = Guid.NewGuid(), Name = "Public", LogoUrl = "logo", IsPublic = true, IsActive = true, SortOrder = 1, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new Allies { Id = Guid.NewGuid(), Name = "Private", LogoUrl = "logo", IsPublic = false, IsActive = true, SortOrder = 2, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
        };

        _mockRepository.Setup(r => r.GetPublicAlliesAsync()).ReturnsAsync(allies.Where(a => a.IsPublic).ToList());

        // Act
        var result = await _service.GetPublicAllies();

        // Assert
        Assert.NotNull(result);
        Assert.All(result, a => Assert.True(a.IsPublic));
    }

    [Fact]
    public async Task GetActiveAllies_ShouldReturnOnlyActiveAllies()
    {
        // Arrange
        var allies = new List<Allies>
        {
            new Allies { Id = Guid.NewGuid(), Name = "Active", LogoUrl = "logo", IsPublic = true, IsActive = true, SortOrder = 1, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
        };

        _mockRepository.Setup(r => r.GetActiveAlliesAsync()).ReturnsAsync(allies.Where(a => a.IsActive).ToList());

        // Act
        var result = await _service.GetActiveAllies();

        // Assert
        Assert.NotNull(result);
        Assert.All(result, a => Assert.True(a.IsActive));
    }

    [Fact]
    public async Task UpdateAlly_WithValidData_ShouldUpdateSuccessfully()
    {
        // Arrange
        var allyId = Guid.NewGuid();
        var existing = new Allies
        {
            Id = allyId,
            Name = "Old Name",
            LogoUrl = "old.png",
            IsActive = true,
            IsPublic = true,
            SortOrder = 1,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        var updateDto = new UpdateAllyDto
        {
            Id = allyId,
            Name = "New Name",
            LogoUrl = "new.png",
            IsActive = true,
            IsPublic = true,
            SortOrder = 1
        };

        _mockRepository.Setup(r => r.GetAllyByIdAsync(allyId)).ReturnsAsync(existing);
        _mockRepository.Setup(r => r.UpdateAllyAsync(It.IsAny<Allies>())).Returns(Task.CompletedTask);

        // Act
        await _service.UpdateAlly(allyId, updateDto);

        // Assert
        _mockRepository.Verify(r => r.UpdateAllyAsync(It.IsAny<Allies>()), Times.Once);
    }
}
