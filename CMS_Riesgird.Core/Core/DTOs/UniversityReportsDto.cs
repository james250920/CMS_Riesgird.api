namespace CMS_Riesgird.Core.Core.DTOs;

public class CreateUniversityReportDto
{
    public Guid UniversityId { get; set; }
    public int Year { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string? PeriodStart { get; set; }
    public string? PeriodEnd { get; set; }
    public string? DocumentUrl { get; set; }
    public List<string>? Metrics { get; set; }
    public bool IsPublic { get; set; }
    public Guid? CreatedBy { get; set; }
}

public class UpdateUniversityReportDto
{
    public Guid Id { get; set; }
    public Guid UniversityId { get; set; }
    public int Year { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string? PeriodStart { get; set; }
    public string? PeriodEnd { get; set; }
    public string? DocumentUrl { get; set; }
    public List<string>? Metrics { get; set; }
    public bool IsPublic { get; set; }
    public Guid? UpdatedBy { get; set; }
}

public class UniversityReportResponseDto
{
    public Guid Id { get; set; }
    public Guid UniversityId { get; set; }
    public int Year { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string? PeriodStart { get; set; }
    public string? PeriodEnd { get; set; }
    public string? DocumentUrl { get; set; }
    public List<string>? Metrics { get; set; }
    public bool IsPublic { get; set; }
    public DateTime CreatedAt { get; set; }
}
