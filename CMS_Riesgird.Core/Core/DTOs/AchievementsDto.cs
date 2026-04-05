namespace CMS_Riesgird.Core.Core.DTOs;

public class CreateAchievementDto
{
    public Guid MemoryId { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Category { get; set; } = null!;
    public DateOnly? Date { get; set; }
    public string? EvidenceUrl { get; set; }
    public int SortOrder { get; set; }
    public Guid? CreatedBy { get; set; }
}

public class UpdateAchievementDto
{
    public Guid Id { get; set; }
    public Guid MemoryId { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Category { get; set; } = null!;
    public DateOnly? Date { get; set; }
    public string? EvidenceUrl { get; set; }
    public int SortOrder { get; set; }
    public Guid? UpdatedBy { get; set; }
}

public class AchievementResponseDto
{
    public Guid Id { get; set; }
    public Guid MemoryId { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Category { get; set; } = null!;
    public DateOnly? Date { get; set; }
    public string? EvidenceUrl { get; set; }
    public int SortOrder { get; set; }
}
