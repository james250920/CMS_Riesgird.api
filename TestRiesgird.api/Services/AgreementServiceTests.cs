using Xunit;
using Moq;
using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Core.Core.Services;
using CMS_Riesgird.Domain.Models;

namespace TestRiesgird.api.Services;

public class AgreementServiceTests
{
    private readonly Mock<IAgreementRepository> _mockRepository;
    private readonly AgreementService _service;

    public AgreementServiceTests()
    {
        _mockRepository = new Mock<IAgreementRepository>();
        _service = new AgreementService(_mockRepository.Object);
    }

    [Fact]
    public async Task GetAllAgreements_ShouldReturnAllAgreements()
    {
        // Arrange
        var agreements = new List<Agreements>
        {
            new Agreements
            {
                Id = Guid.NewGuid(),
                AssemblyId = Guid.NewGuid(),
                Number = "001-2024",
                Title = "Budget Approval",
                Description = "Approved budget",
                IsPublic = true
            }
        };

        _mockRepository.Setup(r => r.GetAllAgreementsAsync()).ReturnsAsync(agreements);

        // Act
        var result = await _service.GetAllAgreements();

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
    }

    [Fact]
    public async Task GetAgreementById_WithValidId_ShouldReturnAgreement()
    {
        // Arrange
        var agreementId = Guid.NewGuid();
        var agreement = new Agreements
        {
            Id = agreementId,
            AssemblyId = Guid.NewGuid(),
            Number = "001-2024",
            Title = "Test Agreement",
            Description = "Test",
            IsPublic = true
        };

        _mockRepository.Setup(r => r.GetAgreementByIdAsync(agreementId)).ReturnsAsync(agreement);

        // Act
        var result = await _service.GetAgreementById(agreementId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(agreementId, result.Id);
        Assert.Equal("Test Agreement", result.Title);
    }

    [Fact]
    public async Task CreateAgreement_WithValidData_ShouldReturnAgreementId()
    {
        // Arrange
        var dto = new CreateAgreementDto
        {
            AssemblyId = Guid.NewGuid(),
            Number = "002-2024",
            Title = "New Agreement",
            Description = "New Agreement Description",
            IsPublic = true
        };

        _mockRepository.Setup(r => r.AddAgreementAsync(It.IsAny<Agreements>())).Returns(Task.CompletedTask);

        // Act
        var result = await _service.CreateAgreement(dto);

        // Assert
        Assert.NotEqual(Guid.Empty, result);
        _mockRepository.Verify(r => r.AddAgreementAsync(It.IsAny<Agreements>()), Times.Once);
    }

    [Fact]
    public async Task GetPublicAgreements_ShouldReturnOnlyPublicAgreements()
    {
        // Arrange
        var agreements = new List<Agreements>
        {
            new Agreements { Id = Guid.NewGuid(), AssemblyId = Guid.NewGuid(), Number = "001", Title = "Public", Description = "Desc", IsPublic = true },
            new Agreements { Id = Guid.NewGuid(), AssemblyId = Guid.NewGuid(), Number = "002", Title = "Private", Description = "Desc", IsPublic = false }
        };

        _mockRepository.Setup(r => r.GetPublicAgreementsAsync()).ReturnsAsync(agreements.Where(a => a.IsPublic).ToList());

        // Act
        var result = await _service.GetPublicAgreements();

        // Assert
        Assert.NotNull(result);
        Assert.All(result, a => Assert.True(a.IsPublic));
    }

    [Fact]
    public async Task GetAgreementsByAssemblyId_ShouldReturnAgreementsForAssembly()
    {
        // Arrange
        var assemblyId = Guid.NewGuid();
        var agreements = new List<Agreements>
        {
            new Agreements { Id = Guid.NewGuid(), AssemblyId = assemblyId, Number = "001", Title = "Agreement", Description = "Desc", IsPublic = true }
        };

        _mockRepository.Setup(r => r.GetAgreementsByAssemblyIdAsync(assemblyId)).ReturnsAsync(agreements);

        // Act
        var result = await _service.GetAgreementsByAssemblyId(assemblyId);

        // Assert
        Assert.NotNull(result);
        Assert.All(result, a => Assert.Equal(assemblyId, a.AssemblyId));
    }

    [Fact]
    public async Task UpdateAgreement_WithValidData_ShouldUpdateSuccessfully()
    {
        // Arrange
        var agreementId = Guid.NewGuid();
        var existing = new Agreements
        {
            Id = agreementId,
            AssemblyId = Guid.NewGuid(),
            Number = "001",
            Title = "Old Title",
            Description = "Old",
            IsPublic = true
        };

        var updateDto = new UpdateAgreementDto
        {
            Id = agreementId,
            AssemblyId = Guid.NewGuid(),
            Number = "001",
            Title = "New Title",
            Description = "New",
            IsPublic = true
        };

        _mockRepository.Setup(r => r.GetAgreementByIdAsync(agreementId)).ReturnsAsync(existing);
        _mockRepository.Setup(r => r.UpdateAgreementAsync(It.IsAny<Agreements>())).Returns(Task.CompletedTask);

        // Act
        await _service.UpdateAgreement(agreementId, updateDto);

        // Assert
        _mockRepository.Verify(r => r.UpdateAgreementAsync(It.IsAny<Agreements>()), Times.Once);
    }
}
