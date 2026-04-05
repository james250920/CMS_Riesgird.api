namespace CMS_Riesgird.Core.Core.DTOs;

public class CreateVideoItemDto
{
    public Guid? CongressId { get; set; }
    public Guid? AlbumId { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string Url { get; set; } = null!;
    public string? ThumbnailUrl { get; set; }
    public int? Duration { get; set; }
    public int SortOrder { get; set; }
    public Guid? CreatedBy { get; set; }
}

public class UpdateVideoItemDto
{
    public Guid Id { get; set; }
    public Guid? CongressId { get; set; }
    public Guid? AlbumId { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string Url { get; set; } = null!;
    public string? ThumbnailUrl { get; set; }
    public int? Duration { get; set; }
    public int SortOrder { get; set; }
    public Guid? UpdatedBy { get; set; }
}

public class VideoItemResponseDto
{
    public Guid Id { get; set; }
    public Guid? CongressId { get; set; }
    public Guid? AlbumId { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string Url { get; set; } = null!;
    public string? ThumbnailUrl { get; set; }
    public int? Duration { get; set; }
    public int SortOrder { get; set; }
}
