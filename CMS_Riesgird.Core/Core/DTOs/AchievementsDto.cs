namespace CMS_Riesgird.Core.Core.DTOs;

public class CreateAchievementDto
{
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string? BadgeUrl { get; set; }
    public string? CertificateUrl { get; set; }
    public DateTime? DateAwarded { get; set; }
    public string? Category { get; set; }
    public List<string>? Recipients { get; set; }
    public string? IssuingOrganization { get; set; }
    public bool IsPublic { get; set; }
    public Guid? CreatedBy { get; set; }
}

public class UpdateAchievementDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string? BadgeUrl { get; set; }
    public string? CertificateUrl { get; set; }
    public DateTime? DateAwarded { get; set; }
    public string? Category { get; set; }
    public List<string>? Recipients { get; set; }
    public string? IssuingOrganization { get; set; }
    public bool IsPublic { get; set; }
    public Guid? UpdatedBy { get; set; }
}

public class AchievementResponseDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string? BadgeUrl { get; set; }
    public string? CertificateUrl { get; set; }
    public DateTime? DateAwarded { get; set; }
    public string? Category { get; set; }
    public List<string>? Recipients { get; set; }
    public string? IssuingOrganization { get; set; }
    public bool IsPublic { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
