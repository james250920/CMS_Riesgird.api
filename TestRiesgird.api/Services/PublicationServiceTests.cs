using Xunit;
using Moq;
using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Core.Core.Services;
using CMS_Riesgird.Domain.Models;

namespace TestRiesgird.api.Services;

public class PublicationServiceTests
{
    private readonly Mock<IPublicationRepository> _mockRepository;
    private readonly PublicationService _service;

    public PublicationServiceTests()
    {
        _mockRepository = new Mock<IPublicationRepository>();
        _service = new PublicationService(_mockRepository.Object);
    }

    [Fact]
    public async Task GetAllPublications_ShouldReturnAllPublications()
    {
        // Arrange
        var publications = new List<Publications>
        {
            new Publications
            {
                Id = Guid.NewGuid(),
                ResearcherId = Guid.NewGuid(),
                Title = "AI Research Paper",
                Authors = new List<string> { "Author 1" },
                Year = 2024,
                Keywords = new List<string> { "AI" },
                IsPublic = true,
                CreatedAt = DateTime.UtcNow
            }
        };

        _mockRepository.Setup(r => r.GetAllPublicationsAsync()).ReturnsAsync(publications);

        // Act
        var result = await _service.GetAllPublications();

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
    }

    [Fact]
    public async Task GetPublicationById_WithValidId_ShouldReturnPublication()
    {
        // Arrange
        var publicationId = Guid.NewGuid();
        var publication = new Publications
        {
            Id = publicationId,
            ResearcherId = Guid.NewGuid(),
            Title = "ML Paper",
            Authors = new List<string> { "Author 1" },
            Year = 2024,
            Keywords = new List<string> { "ML" },
            IsPublic = true,
            CreatedAt = DateTime.UtcNow
        };

        _mockRepository.Setup(r => r.GetPublicationByIdAsync(publicationId)).ReturnsAsync(publication);

        // Act
        var result = await _service.GetPublicationById(publicationId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(publicationId, result.Id);
        Assert.Equal("ML Paper", result.Title);
    }

    [Fact]
    public async Task CreatePublication_WithValidData_ShouldReturnPublicationId()
    {
        // Arrange
        var dto = new CreatePublicationDto
        {
            ResearcherId = Guid.NewGuid(),
            Title = "New Paper",
            Authors = new List<string> { "Author 1", "Author 2" },
            Year = 2024,
            Keywords = new List<string> { "Research", "Science" },
            IsPublic = true
        };

        _mockRepository.Setup(r => r.AddPublicationAsync(It.IsAny<Publications>())).Returns(Task.CompletedTask);

        // Act
        var result = await _service.CreatePublication(dto);

        // Assert
        Assert.NotEqual(Guid.Empty, result);
        _mockRepository.Verify(r => r.AddPublicationAsync(It.IsAny<Publications>()), Times.Once);
    }

    [Fact]
    public async Task GetPublicationsByYear_ShouldReturnPublicationsForSpecificYear()
    {
        // Arrange
        var year = 2024;
        var publications = new List<Publications>
        {
            new Publications
            {
                Id = Guid.NewGuid(),
                ResearcherId = Guid.NewGuid(),
                Title = "2024 Paper",
                Authors = new List<string> { "Author" },
                Year = 2024,
                Keywords = new List<string> { "2024" },
                IsPublic = true,
                CreatedAt = DateTime.UtcNow
            }
        };

        _mockRepository.Setup(r => r.GetPublicationsByYearAsync(year)).ReturnsAsync(publications);

        // Act
        var result = await _service.GetPublicationsByYear(year);

        // Assert
        Assert.NotNull(result);
        Assert.All(result, p => Assert.Equal(2024, p.Year));
    }

    [Fact]
    public async Task UpdatePublication_WithValidData_ShouldUpdateSuccessfully()
    {
        // Arrange
        var publicationId = Guid.NewGuid();
        var existing = new Publications
        {
            Id = publicationId,
            ResearcherId = Guid.NewGuid(),
            Title = "Old Title",
            Authors = new List<string> { "Author" },
            Year = 2023,
            Keywords = new List<string> { "Old" },
            IsPublic = true,
            CreatedAt = DateTime.UtcNow
        };

        var updateDto = new UpdatePublicationDto
        {
            Id = publicationId,
            ResearcherId = Guid.NewGuid(),
            Title = "New Title",
            Authors = new List<string> { "Author" },
            Year = 2024,
            Keywords = new List<string> { "New" },
            IsPublic = true
        };

        _mockRepository.Setup(r => r.GetPublicationByIdAsync(publicationId)).ReturnsAsync(existing);
        _mockRepository.Setup(r => r.UpdatePublicationAsync(It.IsAny<Publications>())).Returns(Task.CompletedTask);

        // Act
        await _service.UpdatePublication(publicationId, updateDto);

        // Assert
        _mockRepository.Verify(r => r.UpdatePublicationAsync(It.IsAny<Publications>()), Times.Once);
    }
}
