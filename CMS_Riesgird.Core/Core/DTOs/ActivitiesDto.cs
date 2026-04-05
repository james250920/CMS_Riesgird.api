namespace CMS_Riesgird.Core.Core.DTOs;

public class CreateActivityDto
{
    public Guid MemoryId { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateOnly Date { get; set; }
    public string? Location { get; set; }
    public int? Participants { get; set; }
    public List<string>? Photos { get; set; }
    public List<string>? DocumentsUrls { get; set; }
    public int SortOrder { get; set; }
    public Guid? CreatedBy { get; set; }
}

public class UpdateActivityDto
{
    public Guid Id { get; set; }
    public Guid MemoryId { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateOnly Date { get; set; }
    public string? Location { get; set; }
    public int? Participants { get; set; }
    public List<string>? Photos { get; set; }
    public List<string>? DocumentsUrls { get; set; }
    public int SortOrder { get; set; }
    public Guid? UpdatedBy { get; set; }
}

public class ActivityResponseDto
{
    public Guid Id { get; set; }
    public Guid MemoryId { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateOnly Date { get; set; }
    public string? Location { get; set; }
    public int? Participants { get; set; }
    public List<string>? Photos { get; set; }
    public List<string>? DocumentsUrls { get; set; }
    public int SortOrder { get; set; }
}
