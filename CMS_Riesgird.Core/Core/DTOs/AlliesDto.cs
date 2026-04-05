namespace CMS_Riesgird.Core.Core.DTOs;

public class CreateAllyDto
{
    public string Name { get; set; } = null!;
    public string LogoUrl { get; set; } = null!;
    public string? WebsiteUrl { get; set; }
    public string? ContactEmail { get; set; }
    public string? ContactPhone { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }
    public bool IsPublic { get; set; }
    public int SortOrder { get; set; }
    public Guid? CreatedBy { get; set; }
}

public class UpdateAllyDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string LogoUrl { get; set; } = null!;
    public string? WebsiteUrl { get; set; }
    public string? ContactEmail { get; set; }
    public string? ContactPhone { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }
    public bool IsPublic { get; set; }
    public int SortOrder { get; set; }
    public Guid? UpdatedBy { get; set; }
}

public class AllyResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string LogoUrl { get; set; } = null!;
    public string? WebsiteUrl { get; set; }
    public string? ContactEmail { get; set; }
    public string? ContactPhone { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }
    public bool IsPublic { get; set; }
    public int SortOrder { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
