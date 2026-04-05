using Xunit;
using Moq;
using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Core.Core.Services;
using CMS_Riesgird.Domain.Models;

namespace TestRiesgird.api.Services;

public class SpecializationProgramServiceTests
{
    private readonly Mock<ISpecializationProgramRepository> _mockRepository;
    private readonly SpecializationProgramService _service;

    public SpecializationProgramServiceTests()
    {
        _mockRepository = new Mock<ISpecializationProgramRepository>();
        _service = new SpecializationProgramService(_mockRepository.Object);
    }

    [Fact]
    public async Task GetAllPrograms_ShouldReturnAllPrograms()
    {
        // Arrange
        var programs = new List<SpecializationPrograms>
        {
            new SpecializationPrograms
            {
                Id = Guid.NewGuid(),
                Name = "Diplomado en Riesgos",
                Description = "Program description",
                Duration = "6 meses",
                StartDate = DateOnly.FromDateTime(DateTime.Now.AddMonths(1)),
                IsPublic = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            }
        };

        _mockRepository.Setup(r => r.GetAllProgramsAsync()).ReturnsAsync(programs);

        // Act
        var result = await _service.GetAllPrograms();

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
    }

    [Fact]
    public async Task GetProgramById_WithValidId_ShouldReturnProgram()
    {
        // Arrange
        var programId = Guid.NewGuid();
        var program = new SpecializationPrograms
        {
            Id = programId,
            Name = "Test Program",
            Description = "Test",
            Duration = "3 meses",
            StartDate = DateOnly.FromDateTime(DateTime.Now.AddMonths(1)),
            IsPublic = true,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _mockRepository.Setup(r => r.GetProgramByIdAsync(programId)).ReturnsAsync(program);

        // Act
        var result = await _service.GetProgramById(programId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(programId, result.Id);
        Assert.Equal("Test Program", result.Name);
    }

    [Fact]
    public async Task CreateProgram_WithValidData_ShouldReturnProgramId()
    {
        // Arrange
        var dto = new CreateSpecializationProgramDto
        {
            Name = "New Program",
            Description = "New Program Description",
            Duration = "6 meses",
            StartDate = DateOnly.FromDateTime(DateTime.Now.AddMonths(1)),
            IsPublic = true
        };

        _mockRepository.Setup(r => r.AddProgramAsync(It.IsAny<SpecializationPrograms>())).Returns(Task.CompletedTask);

        // Act
        var result = await _service.CreateProgram(dto);

        // Assert
        Assert.NotEqual(Guid.Empty, result);
        _mockRepository.Verify(r => r.AddProgramAsync(It.IsAny<SpecializationPrograms>()), Times.Once);
    }

    [Fact]
    public async Task GetPublicPrograms_ShouldReturnOnlyPublicPrograms()
    {
        // Arrange
        var programs = new List<SpecializationPrograms>
        {
            new SpecializationPrograms { Id = Guid.NewGuid(), Name = "Public", Description = "Desc", Duration = "3m", StartDate = DateOnly.FromDateTime(DateTime.Now), IsPublic = true, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new SpecializationPrograms { Id = Guid.NewGuid(), Name = "Private", Description = "Desc", Duration = "3m", StartDate = DateOnly.FromDateTime(DateTime.Now), IsPublic = false, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
        };

        _mockRepository.Setup(r => r.GetPublicProgramsAsync()).ReturnsAsync(programs.Where(p => p.IsPublic).ToList());

        // Act
        var result = await _service.GetPublicPrograms();

        // Assert
        Assert.NotNull(result);
        Assert.All(result, p => Assert.True(p.IsPublic));
    }

    [Fact]
    public async Task GetOpenEnrollmentPrograms_ShouldReturnProgramsWithOpenEnrollment()
    {
        // Arrange
        var programs = new List<SpecializationPrograms>
        {
            new SpecializationPrograms { Id = Guid.NewGuid(), Name = "Open", Description = "Desc", Duration = "3m", StartDate = DateOnly.FromDateTime(DateTime.Now), EnrollmentOpen = true, IsPublic = true, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
        };

        _mockRepository.Setup(r => r.GetOpenEnrollmentProgramsAsync()).ReturnsAsync(programs.Where(p => p.EnrollmentOpen == true).ToList());

        // Act
        var result = await _service.GetOpenEnrollmentPrograms();

        // Assert
        Assert.NotNull(result);
        Assert.All(result, p => Assert.True(p.EnrollmentOpen));
    }

    [Fact]
    public async Task UpdateProgram_WithValidData_ShouldUpdateSuccessfully()
    {
        // Arrange
        var programId = Guid.NewGuid();
        var existing = new SpecializationPrograms
        {
            Id = programId,
            Name = "Old Name",
            Description = "Old",
            Duration = "3m",
            StartDate = DateOnly.FromDateTime(DateTime.Now),
            IsPublic = true,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        var updateDto = new UpdateSpecializationProgramDto
        {
            Id = programId,
            Name = "New Name",
            Description = "New",
            Duration = "6m",
            StartDate = DateOnly.FromDateTime(DateTime.Now.AddMonths(1)),
            IsPublic = true
        };

        _mockRepository.Setup(r => r.GetProgramByIdAsync(programId)).ReturnsAsync(existing);
        _mockRepository.Setup(r => r.UpdateProgramAsync(It.IsAny<SpecializationPrograms>())).Returns(Task.CompletedTask);

        // Act
        await _service.UpdateProgram(programId, updateDto);

        // Assert
        _mockRepository.Verify(r => r.UpdateProgramAsync(It.IsAny<SpecializationPrograms>()), Times.Once);
    }
}
