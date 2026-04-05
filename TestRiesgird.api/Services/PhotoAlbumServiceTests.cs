using Xunit;
using Moq;
using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Core.Core.Services;
using CMS_Riesgird.Domain.Models;

namespace TestRiesgird.api.Services;

public class PhotoAlbumServiceTests
{
    private readonly Mock<IPhotoAlbumRepository> _mockRepository;
    private readonly PhotoAlbumService _service;

    public PhotoAlbumServiceTests()
    {
        _mockRepository = new Mock<IPhotoAlbumRepository>();
        _service = new PhotoAlbumService(_mockRepository.Object);
    }

    [Fact]
    public async Task GetAllAlbums_ShouldReturnAllAlbums()
    {
        // Arrange
        var albums = new List<PhotoAlbums>
        {
            new PhotoAlbums
            {
                Id = Guid.NewGuid(),
                Title = "Congress Photos",
                Description = "Photos from congress",
                Date = DateOnly.FromDateTime(DateTime.Now),
                IsPublic = true,
                IsFeatured = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            }
        };

        _mockRepository.Setup(r => r.GetAllAlbumsAsync()).ReturnsAsync(albums);

        // Act
        var result = await _service.GetAllAlbums();

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
    }

    [Fact]
    public async Task GetAlbumById_WithValidId_ShouldReturnAlbum()
    {
        // Arrange
        var albumId = Guid.NewGuid();
        var album = new PhotoAlbums
        {
            Id = albumId,
            Title = "Test Album",
            Description = "Test",
            Date = DateOnly.FromDateTime(DateTime.Now),
            IsPublic = true,
            IsFeatured = false,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _mockRepository.Setup(r => r.GetAlbumByIdAsync(albumId)).ReturnsAsync(album);

        // Act
        var result = await _service.GetAlbumById(albumId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(albumId, result.Id);
        Assert.Equal("Test Album", result.Title);
    }

    [Fact]
    public async Task CreateAlbum_WithValidData_ShouldReturnAlbumId()
    {
        // Arrange
        var dto = new CreatePhotoAlbumDto
        {
            Title = "New Album",
            Description = "New Album Description",
            Date = DateOnly.FromDateTime(DateTime.Now),
            IsPublic = true,
            IsFeatured = false
        };

        _mockRepository.Setup(r => r.AddAlbumAsync(It.IsAny<PhotoAlbums>())).Returns(Task.CompletedTask);

        // Act
        var result = await _service.CreateAlbum(dto);

        // Assert
        Assert.NotEqual(Guid.Empty, result);
        _mockRepository.Verify(r => r.AddAlbumAsync(It.IsAny<PhotoAlbums>()), Times.Once);
    }

    [Fact]
    public async Task GetPublicAlbums_ShouldReturnOnlyPublicAlbums()
    {
        // Arrange
        var albums = new List<PhotoAlbums>
        {
            new PhotoAlbums { Id = Guid.NewGuid(), Title = "Public", Date = DateOnly.FromDateTime(DateTime.Now), IsPublic = true, IsFeatured = false, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new PhotoAlbums { Id = Guid.NewGuid(), Title = "Private", Date = DateOnly.FromDateTime(DateTime.Now), IsPublic = false, IsFeatured = false, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
        };

        _mockRepository.Setup(r => r.GetPublicAlbumsAsync()).ReturnsAsync(albums.Where(a => a.IsPublic).ToList());

        // Act
        var result = await _service.GetPublicAlbums();

        // Assert
        Assert.NotNull(result);
        Assert.All(result, a => Assert.True(a.IsPublic));
    }

    [Fact]
    public async Task GetFeaturedAlbums_ShouldReturnOnlyFeaturedAlbums()
    {
        // Arrange
        var albums = new List<PhotoAlbums>
        {
            new PhotoAlbums { Id = Guid.NewGuid(), Title = "Featured", Date = DateOnly.FromDateTime(DateTime.Now), IsPublic = true, IsFeatured = true, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
        };

        _mockRepository.Setup(r => r.GetFeaturedAlbumsAsync()).ReturnsAsync(albums.Where(a => a.IsFeatured).ToList());

        // Act
        var result = await _service.GetFeaturedAlbums();

        // Assert
        Assert.NotNull(result);
        Assert.All(result, a => Assert.True(a.IsFeatured));
    }

    [Fact]
    public async Task UpdateAlbum_WithValidData_ShouldUpdateSuccessfully()
    {
        // Arrange
        var albumId = Guid.NewGuid();
        var existing = new PhotoAlbums
        {
            Id = albumId,
            Title = "Old Title",
            Description = "Old",
            Date = DateOnly.FromDateTime(DateTime.Now),
            IsPublic = true,
            IsFeatured = false,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        var updateDto = new UpdatePhotoAlbumDto
        {
            Id = albumId,
            Title = "New Title",
            Description = "New",
            Date = DateOnly.FromDateTime(DateTime.Now),
            IsPublic = true,
            IsFeatured = true
        };

        _mockRepository.Setup(r => r.GetAlbumByIdAsync(albumId)).ReturnsAsync(existing);
        _mockRepository.Setup(r => r.UpdateAlbumAsync(It.IsAny<PhotoAlbums>())).Returns(Task.CompletedTask);

        // Act
        await _service.UpdateAlbum(albumId, updateDto);

        // Assert
        _mockRepository.Verify(r => r.UpdateAlbumAsync(It.IsAny<PhotoAlbums>()), Times.Once);
    }
}
