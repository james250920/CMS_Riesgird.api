namespace CMS_Riesgird.Core.Core.DTOs;

public class CreateSpecializationProgramDto
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public List<string>? Objectives { get; set; }
    public string Duration { get; set; } = null!;
    public int? Credits { get; set; }
    public string? TargetAudience { get; set; }
    public string? Requirements { get; set; }
    public decimal? Price { get; set; }
    public DateOnly? StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
    public DateOnly? RegistrationDeadline { get; set; }
    public bool? EnrollmentOpen { get; set; }
    public int? GraduatesCount { get; set; }
    public List<string>? OrganizingUniversities { get; set; }
    public string? Coordinator { get; set; }
    public string? ImageUrl { get; set; }
    public string? SyllabusFileUrl { get; set; }
    public string? BrochureFileUrl { get; set; }
    public string? RegistrationUrl { get; set; }
    public bool IsPublic { get; set; }
    public Guid? CreatedBy { get; set; }
}

public class UpdateSpecializationProgramDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public List<string>? Objectives { get; set; }
    public string Duration { get; set; } = null!;
    public int? Credits { get; set; }
    public string? TargetAudience { get; set; }
    public string? Requirements { get; set; }
    public decimal? Price { get; set; }
    public DateOnly? StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
    public DateOnly? RegistrationDeadline { get; set; }
    public bool? EnrollmentOpen { get; set; }
    public int? GraduatesCount { get; set; }
    public List<string>? OrganizingUniversities { get; set; }
    public string? Coordinator { get; set; }
    public string? ImageUrl { get; set; }
    public string? SyllabusFileUrl { get; set; }
    public string? BrochureFileUrl { get; set; }
    public string? RegistrationUrl { get; set; }
    public bool IsPublic { get; set; }
    public Guid? UpdatedBy { get; set; }
}

public class SpecializationProgramResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public List<string>? Objectives { get; set; }
    public string Duration { get; set; } = null!;
    public int? Credits { get; set; }
    public string? TargetAudience { get; set; }
    public string? Requirements { get; set; }
    public decimal? Price { get; set; }
    public DateOnly? StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
    public DateOnly? RegistrationDeadline { get; set; }
    public bool? EnrollmentOpen { get; set; }
    public int? GraduatesCount { get; set; }
    public List<string>? OrganizingUniversities { get; set; }
    public string? Coordinator { get; set; }
    public string? ImageUrl { get; set; }
    public string? SyllabusFileUrl { get; set; }
    public string? BrochureFileUrl { get; set; }
    public string? RegistrationUrl { get; set; }
    public bool IsPublic { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
