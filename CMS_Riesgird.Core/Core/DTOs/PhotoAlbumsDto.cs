namespace CMS_Riesgird.Core.Core.DTOs;

public class CreatePhotoAlbumDto
{
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public Guid? EventId { get; set; }
    public string? EventName { get; set; }
    public DateOnly? EventDate { get; set; }
    public DateOnly Date { get; set; }
    public string? CoverPhotoUrl { get; set; }
    public string? CoverImageUrl { get; set; }
    public string? ExternalUrl { get; set; }
    public string? DownloadUrl { get; set; }
    public int? ItemsCount { get; set; }
    public List<string>? Tags { get; set; }
    public bool IsPublic { get; set; }
    public bool IsFeatured { get; set; }
    public Guid? CreatedBy { get; set; }
}

public class UpdatePhotoAlbumDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public Guid? EventId { get; set; }
    public string? EventName { get; set; }
    public DateOnly? EventDate { get; set; }
    public DateOnly Date { get; set; }
    public string? CoverPhotoUrl { get; set; }
    public string? CoverImageUrl { get; set; }
    public string? ExternalUrl { get; set; }
    public string? DownloadUrl { get; set; }
    public int? ItemsCount { get; set; }
    public List<string>? Tags { get; set; }
    public bool IsPublic { get; set; }
    public bool IsFeatured { get; set; }
    public Guid? UpdatedBy { get; set; }
}

public class PhotoAlbumResponseDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public Guid? EventId { get; set; }
    public string? EventName { get; set; }
    public DateOnly? EventDate { get; set; }
    public DateOnly Date { get; set; }
    public string? CoverPhotoUrl { get; set; }
    public string? CoverImageUrl { get; set; }
    public string? ExternalUrl { get; set; }
    public string? DownloadUrl { get; set; }
    public int? ItemsCount { get; set; }
    public List<string>? Tags { get; set; }
    public bool IsPublic { get; set; }
    public bool IsFeatured { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
