namespace CMS_Riesgird.Core.Core.DTOs;

public class CreateResearcherDto
{
    public Guid UniversityId { get; set; }
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Phone { get; set; }
    public string? Dni { get; set; }
    public string? PhotoUrl { get; set; }
    public string? Specialty { get; set; }
    public List<string> ResearchAreas { get; set; } = null!;
    public string? OrcidId { get; set; }
    public string? ScopusId { get; set; }
    public string? GoogleScholarUrl { get; set; }
    public string? Faculty { get; set; }
    public string? Department { get; set; }
    public string? Position { get; set; }
    public string? Bio { get; set; }
    public int PublicationsCount { get; set; }
    public bool IsActive { get; set; }
    public bool IsPublic { get; set; }
    public Guid? CreatedBy { get; set; }
}

public class UpdateResearcherDto
{
    public Guid Id { get; set; }
    public Guid UniversityId { get; set; }
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Phone { get; set; }
    public string? Dni { get; set; }
    public string? PhotoUrl { get; set; }
    public string? Specialty { get; set; }
    public List<string> ResearchAreas { get; set; } = null!;
    public string? OrcidId { get; set; }
    public string? ScopusId { get; set; }
    public string? GoogleScholarUrl { get; set; }
    public string? Faculty { get; set; }
    public string? Department { get; set; }
    public string? Position { get; set; }
    public string? Bio { get; set; }
    public int PublicationsCount { get; set; }
    public bool IsActive { get; set; }
    public bool IsPublic { get; set; }
    public Guid? UpdatedBy { get; set; }
}

public class ResearcherResponseDto
{
    public Guid Id { get; set; }
    public Guid UniversityId { get; set; }
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Phone { get; set; }
    public string? Dni { get; set; }
    public string? PhotoUrl { get; set; }
    public string? Specialty { get; set; }
    public List<string> ResearchAreas { get; set; } = null!;
    public string? OrcidId { get; set; }
    public string? ScopusId { get; set; }
    public string? GoogleScholarUrl { get; set; }
    public string? Faculty { get; set; }
    public string? Department { get; set; }
    public string? Position { get; set; }
    public string? Bio { get; set; }
    public int PublicationsCount { get; set; }
    public bool IsActive { get; set; }
    public bool IsPublic { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
