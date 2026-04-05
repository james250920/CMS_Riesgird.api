namespace CMS_Riesgird.Core.Core.DTOs;

public class CreateEventPhotoDto
{
    public Guid EventId { get; set; }
    public string Url { get; set; } = null!;
    public string? ThumbnailUrl { get; set; }
    public string? Caption { get; set; }
    public string? Photographer { get; set; }
    public DateTime? TakenAt { get; set; }
    public int SortOrder { get; set; }
    public bool IsPublic { get; set; }
    public bool IsFeatured { get; set; }
    public Guid? CreatedBy { get; set; }
}

public class UpdateEventPhotoDto
{
    public Guid Id { get; set; }
    public Guid EventId { get; set; }
    public string Url { get; set; } = null!;
    public string? ThumbnailUrl { get; set; }
    public string? Caption { get; set; }
    public string? Photographer { get; set; }
    public DateTime? TakenAt { get; set; }
    public int SortOrder { get; set; }
    public bool IsPublic { get; set; }
    public bool IsFeatured { get; set; }
    public Guid? UpdatedBy { get; set; }
}

public class EventPhotoResponseDto
{
    public Guid Id { get; set; }
    public Guid EventId { get; set; }
    public string Url { get; set; } = null!;
    public string? ThumbnailUrl { get; set; }
    public string? Caption { get; set; }
    public string? Photographer { get; set; }
    public DateTime? TakenAt { get; set; }
    public int SortOrder { get; set; }
    public bool IsPublic { get; set; }
    public bool IsFeatured { get; set; }
}
