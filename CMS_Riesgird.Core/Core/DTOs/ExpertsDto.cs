namespace CMS_Riesgird.Core.Core.DTOs;

public class CreateExpertDto
{
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Phone { get; set; }
    public string? PhotoUrl { get; set; }
    public string? Title { get; set; }
    public string? Organization { get; set; }
    public List<string> ExpertiseAreas { get; set; } = null!;
    public List<string>? Specialties { get; set; }
    public string? SpecialtyInRiskGovernance { get; set; }
    public int? YearsOfExperience { get; set; }
    public string? Institution { get; set; }
    public string? Position { get; set; }
    public string Country { get; set; } = null!;
    public string? City { get; set; }
    public string? Bio { get; set; }
    public string? LinkedinUrl { get; set; }
    public string? Website { get; set; }
    public string? CvFileUrl { get; set; }
    public bool? IsAvailable { get; set; }
    public bool? AvailableForConsulting { get; set; }
    public bool? AvailableForTraining { get; set; }
    public bool? AvailableForResearch { get; set; }
    public bool IsActive { get; set; }
    public bool IsPublic { get; set; }
    public Guid? CreatedBy { get; set; }
}

public class UpdateExpertDto
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Phone { get; set; }
    public string? PhotoUrl { get; set; }
    public string? Title { get; set; }
    public string? Organization { get; set; }
    public List<string> ExpertiseAreas { get; set; } = null!;
    public List<string>? Specialties { get; set; }
    public string? SpecialtyInRiskGovernance { get; set; }
    public int? YearsOfExperience { get; set; }
    public string? Institution { get; set; }
    public string? Position { get; set; }
    public string Country { get; set; } = null!;
    public string? City { get; set; }
    public string? Bio { get; set; }
    public string? LinkedinUrl { get; set; }
    public string? Website { get; set; }
    public string? CvFileUrl { get; set; }
    public bool? IsAvailable { get; set; }
    public bool? AvailableForConsulting { get; set; }
    public bool? AvailableForTraining { get; set; }
    public bool? AvailableForResearch { get; set; }
    public bool IsActive { get; set; }
    public bool IsPublic { get; set; }
    public Guid? UpdatedBy { get; set; }
}

public class ExpertResponseDto
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Phone { get; set; }
    public string? PhotoUrl { get; set; }
    public string? Title { get; set; }
    public string? Organization { get; set; }
    public List<string> ExpertiseAreas { get; set; } = null!;
    public List<string>? Specialties { get; set; }
    public string? SpecialtyInRiskGovernance { get; set; }
    public int? YearsOfExperience { get; set; }
    public string? Institution { get; set; }
    public string? Position { get; set; }
    public string Country { get; set; } = null!;
    public string? City { get; set; }
    public string? Bio { get; set; }
    public string? LinkedinUrl { get; set; }
    public string? Website { get; set; }
    public string? CvFileUrl { get; set; }
    public bool? IsAvailable { get; set; }
    public bool? AvailableForConsulting { get; set; }
    public bool? AvailableForTraining { get; set; }
    public bool? AvailableForResearch { get; set; }
    public bool IsActive { get; set; }
    public bool IsPublic { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
