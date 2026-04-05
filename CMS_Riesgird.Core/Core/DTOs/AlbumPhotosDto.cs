namespace CMS_Riesgird.Core.Core.DTOs;

public class CreateAlbumPhotoDto
{
    public Guid AlbumId { get; set; }
    public string Url { get; set; } = null!;
    public string? ThumbnailUrl { get; set; }
    public string? Caption { get; set; }
    public string? Photographer { get; set; }
    public DateTime? TakenAt { get; set; }
    public int SortOrder { get; set; }
    public bool IsCover { get; set; }
    public bool IsPublic { get; set; }
    public Guid? CreatedBy { get; set; }
}

public class UpdateAlbumPhotoDto
{
    public Guid Id { get; set; }
    public Guid AlbumId { get; set; }
    public string Url { get; set; } = null!;
    public string? ThumbnailUrl { get; set; }
    public string? Caption { get; set; }
    public string? Photographer { get; set; }
    public DateTime? TakenAt { get; set; }
    public int SortOrder { get; set; }
    public bool IsCover { get; set; }
    public bool IsPublic { get; set; }
    public Guid? UpdatedBy { get; set; }
}

public class AlbumPhotoResponseDto
{
    public Guid Id { get; set; }
    public Guid AlbumId { get; set; }
    public string Url { get; set; } = null!;
    public string? ThumbnailUrl { get; set; }
    public string? Caption { get; set; }
    public string? Photographer { get; set; }
    public DateTime? TakenAt { get; set; }
    public int SortOrder { get; set; }
    public bool IsCover { get; set; }
    public bool IsPublic { get; set; }
}
