using Xunit;
using Moq;
using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Core.Core.Services;
using CMS_Riesgird.Domain.Models;

namespace TestRiesgird.api.Services;

public class AlbumPhotoServiceTests
{
    private readonly Mock<IAlbumPhotoRepository> _mockRepository;
    private readonly AlbumPhotoService _service;

    public AlbumPhotoServiceTests()
    {
        _mockRepository = new Mock<IAlbumPhotoRepository>();
        _service = new AlbumPhotoService(_mockRepository.Object);
    }

    [Fact]
    public async Task GetAllPhotos_ShouldReturnAllPhotos()
    {
        // Arrange
        var photos = new List<AlbumPhotos>
        {
            new AlbumPhotos
            {
                Id = Guid.NewGuid(),
                AlbumId = Guid.NewGuid(),
                Url = "http://photo1.jpg",
                SortOrder = 1,
                IsCover = false,
                IsPublic = true
            }
        };

        _mockRepository.Setup(r => r.GetAllPhotosAsync()).ReturnsAsync(photos);

        // Act
        var result = await _service.GetAllPhotos();

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
    }

    [Fact]
    public async Task GetPhotoById_WithValidId_ShouldReturnPhoto()
    {
        // Arrange
        var photoId = Guid.NewGuid();
        var photo = new AlbumPhotos
        {
            Id = photoId,
            AlbumId = Guid.NewGuid(),
            Url = "http://photo.jpg",
            SortOrder = 1,
            IsCover = false,
            IsPublic = true
        };

        _mockRepository.Setup(r => r.GetPhotoByIdAsync(photoId)).ReturnsAsync(photo);

        // Act
        var result = await _service.GetPhotoById(photoId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(photoId, result.Id);
    }

    [Fact]
    public async Task CreatePhoto_WithValidData_ShouldReturnPhotoId()
    {
        // Arrange
        var dto = new CreateAlbumPhotoDto
        {
            AlbumId = Guid.NewGuid(),
            Url = "http://new.jpg",
            SortOrder = 1,
            IsCover = false,
            IsPublic = true
        };

        _mockRepository.Setup(r => r.AddPhotoAsync(It.IsAny<AlbumPhotos>())).Returns(Task.CompletedTask);

        // Act
        var result = await _service.CreatePhoto(dto);

        // Assert
        Assert.NotEqual(Guid.Empty, result);
        _mockRepository.Verify(r => r.AddPhotoAsync(It.IsAny<AlbumPhotos>()), Times.Once);
    }

    [Fact]
    public async Task GetPhotosByAlbumId_ShouldReturnPhotosForAlbum()
    {
        // Arrange
        var albumId = Guid.NewGuid();
        var photos = new List<AlbumPhotos>
        {
            new AlbumPhotos { Id = Guid.NewGuid(), AlbumId = albumId, Url = "http://photo.jpg", SortOrder = 1, IsCover = false, IsPublic = true }
        };

        _mockRepository.Setup(r => r.GetPhotosByAlbumIdAsync(albumId)).ReturnsAsync(photos);

        // Act
        var result = await _service.GetPhotosByAlbumId(albumId);

        // Assert
        Assert.NotNull(result);
        Assert.All(result, p => Assert.Equal(albumId, p.AlbumId));
    }

    [Fact]
    public async Task GetCoverPhotoByAlbumId_ShouldReturnCoverPhoto()
    {
        // Arrange
        var albumId = Guid.NewGuid();
        var photo = new AlbumPhotos
        {
            Id = Guid.NewGuid(),
            AlbumId = albumId,
            Url = "http://cover.jpg",
            SortOrder = 1,
            IsCover = true,
            IsPublic = true
        };

        _mockRepository.Setup(r => r.GetCoverPhotoByAlbumIdAsync(albumId)).ReturnsAsync(photo);

        // Act
        var result = await _service.GetCoverPhotoByAlbumId(albumId);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.IsCover);
    }
}

public class VideoItemServiceTests
{
    private readonly Mock<IVideoItemRepository> _mockRepository;
    private readonly VideoItemService _service;

    public VideoItemServiceTests()
    {
        _mockRepository = new Mock<IVideoItemRepository>();
        _service = new VideoItemService(_mockRepository.Object);
    }

    [Fact]
    public async Task GetAllVideos_ShouldReturnAllVideos()
    {
        // Arrange
        var videos = new List<VideoItems>
        {
            new VideoItems
            {
                Id = Guid.NewGuid(),
                Title = "Video 1",
                Url = "http://video1.mp4",
                SortOrder = 1
            }
        };

        _mockRepository.Setup(r => r.GetAllVideosAsync()).ReturnsAsync(videos);

        // Act
        var result = await _service.GetAllVideos();

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
    }

    [Fact]
    public async Task GetVideoById_WithValidId_ShouldReturnVideo()
    {
        // Arrange
        var videoId = Guid.NewGuid();
        var video = new VideoItems
        {
            Id = videoId,
            Title = "Test Video",
            Url = "http://test.mp4",
            SortOrder = 1
        };

        _mockRepository.Setup(r => r.GetVideoByIdAsync(videoId)).ReturnsAsync(video);

        // Act
        var result = await _service.GetVideoById(videoId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(videoId, result.Id);
        Assert.Equal("Test Video", result.Title);
    }

    [Fact]
    public async Task CreateVideo_WithValidData_ShouldReturnVideoId()
    {
        // Arrange
        var dto = new CreateVideoItemDto
        {
            Title = "New Video",
            Url = "http://new.mp4",
            SortOrder = 1
        };

        _mockRepository.Setup(r => r.AddVideoAsync(It.IsAny<VideoItems>())).Returns(Task.CompletedTask);

        // Act
        var result = await _service.CreateVideo(dto);

        // Assert
        Assert.NotEqual(Guid.Empty, result);
        _mockRepository.Verify(r => r.AddVideoAsync(It.IsAny<VideoItems>()), Times.Once);
    }

    [Fact]
    public async Task GetVideosByCongressId_ShouldReturnVideosForCongress()
    {
        // Arrange
        var congressId = Guid.NewGuid();
        var videos = new List<VideoItems>
        {
            new VideoItems { Id = Guid.NewGuid(), CongressId = congressId, Title = "Video", Url = "http://video.mp4", SortOrder = 1 }
        };

        _mockRepository.Setup(r => r.GetVideosByCongressIdAsync(congressId)).ReturnsAsync(videos);

        // Act
        var result = await _service.GetVideosByCongressId(congressId);

        // Assert
        Assert.NotNull(result);
        Assert.All(result, v => Assert.Equal(congressId, v.CongressId));
    }

    [Fact]
    public async Task GetVideosByAlbumId_ShouldReturnVideosForAlbum()
    {
        // Arrange
        var albumId = Guid.NewGuid();
        var videos = new List<VideoItems>
        {
            new VideoItems { Id = Guid.NewGuid(), AlbumId = albumId, Title = "Video", Url = "http://video.mp4", SortOrder = 1 }
        };

        _mockRepository.Setup(r => r.GetVideosByAlbumIdAsync(albumId)).ReturnsAsync(videos);

        // Act
        var result = await _service.GetVideosByAlbumId(albumId);

        // Assert
        Assert.NotNull(result);
        Assert.All(result, v => Assert.Equal(albumId, v.AlbumId));
    }
}
