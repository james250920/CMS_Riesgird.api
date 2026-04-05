namespace CMS_Riesgird.Core.Core.DTOs;

public class CreateManagementMemoryDto
{
    public int Year { get; set; }
    public string? Period { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string? President { get; set; }
    public string? Introduction { get; set; }
    public string? Summary { get; set; }
    public int? PageCount { get; set; }
    public List<string>? Highlights { get; set; }
    public string? DocumentUrl { get; set; }
    public string? DigitalBookUrl { get; set; }
    public string? CoverImageUrl { get; set; }
    public string? CustomStats { get; set; }
    public bool IsPublic { get; set; }
    public DateOnly? PublishedDate { get; set; }
    public Guid? CreatedBy { get; set; }
}

public class UpdateManagementMemoryDto
{
    public Guid Id { get; set; }
    public int Year { get; set; }
    public string? Period { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string? President { get; set; }
    public string? Introduction { get; set; }
    public string? Summary { get; set; }
    public int? PageCount { get; set; }
    public List<string>? Highlights { get; set; }
    public string? DocumentUrl { get; set; }
    public string? DigitalBookUrl { get; set; }
    public string? CoverImageUrl { get; set; }
    public string? CustomStats { get; set; }
    public bool IsPublic { get; set; }
    public DateOnly? PublishedDate { get; set; }
    public Guid? UpdatedBy { get; set; }
}

public class ManagementMemoryResponseDto
{
    public Guid Id { get; set; }
    public int Year { get; set; }
    public string? Period { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string? President { get; set; }
    public string? Introduction { get; set; }
    public string? Summary { get; set; }
    public int? PageCount { get; set; }
    public List<string>? Highlights { get; set; }
    public string? DocumentUrl { get; set; }
    public string? DigitalBookUrl { get; set; }
    public string? CoverImageUrl { get; set; }
    public string? CustomStats { get; set; }
    public bool IsPublic { get; set; }
    public DateOnly? PublishedDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
