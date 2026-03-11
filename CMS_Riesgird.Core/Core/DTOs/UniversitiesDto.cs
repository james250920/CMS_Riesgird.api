namespace CMS_Riesgird.Core.Core.DTOs;

/// <summary>
/// DTOs para el CRUD de Universidades
/// </summary>
public class CreateUniversityDto
{
    public string Name { get; set; } = null!;
    public string ShortName { get; set; } = null!;
    public string? LogoUrl { get; set; }
    public string? WebsiteUrl { get; set; }
    public string? Address { get; set; }
    public string City { get; set; } = null!;
    public string Region { get; set; } = null!;
    public int? FoundedYear { get; set; }
    public DateOnly? MembershipDate { get; set; }
    public string? CertificateNumber { get; set; }
    public string? CertificateFileUrl { get; set; }
    public bool IsActive { get; set; }
    public bool IsPublic { get; set; }
    public Guid? CreatedBy { get; set; }
}

public class UpdateUniversityDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string ShortName { get; set; } = null!;
    public string? LogoUrl { get; set; }
    public string? WebsiteUrl { get; set; }
    public string? Address { get; set; }
    public string City { get; set; } = null!;
    public string Region { get; set; } = null!;
    public int? FoundedYear { get; set; }
    public DateOnly? MembershipDate { get; set; }
    public string? CertificateNumber { get; set; }
    public string? CertificateFileUrl { get; set; }
    public bool IsActive { get; set; }
    public bool IsPublic { get; set; }
    public Guid? UpdatedBy { get; set; }
}

public class UniversityResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string ShortName { get; set; } = null!;
    public string? LogoUrl { get; set; }
    public string? WebsiteUrl { get; set; }
    public string? Address { get; set; }
    public string City { get; set; } = null!;
    public string Region { get; set; } = null!;
    public int? FoundedYear { get; set; }
    public DateOnly? MembershipDate { get; set; }
    public string? CertificateNumber { get; set; }
    public string? CertificateFileUrl { get; set; }
    public bool IsActive { get; set; }
    public bool IsPublic { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
