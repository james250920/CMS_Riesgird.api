namespace CMS_Riesgird.Core.Core.DTOs;

public class CreateTechnicalTeamMemberDto
{
    public Guid UniversityId { get; set; }
    public string FullName { get; set; } = null!;
    public string? TeamType { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Dni { get; set; }
    public string? PhotoUrl { get; set; }
    public string? Position { get; set; }
    public string? Specialty { get; set; }
    public string? AreaRepresented { get; set; }
    public string? ResolutionNumber { get; set; }
    public DateOnly? ResolutionDate { get; set; }
    public string? ResolutionFileUrl { get; set; }
    public bool IsActive { get; set; }
    public bool IsPublic { get; set; }
    public Guid? CreatedBy { get; set; }
}

public class UpdateTechnicalTeamMemberDto
{
    public Guid Id { get; set; }
    public Guid UniversityId { get; set; }
    public string FullName { get; set; } = null!;
    public string? TeamType { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Dni { get; set; }
    public string? PhotoUrl { get; set; }
    public string? Position { get; set; }
    public string? Specialty { get; set; }
    public string? AreaRepresented { get; set; }
    public string? ResolutionNumber { get; set; }
    public DateOnly? ResolutionDate { get; set; }
    public string? ResolutionFileUrl { get; set; }
    public bool IsActive { get; set; }
    public bool IsPublic { get; set; }
    public Guid? UpdatedBy { get; set; }
}

public class TechnicalTeamMemberResponseDto
{
    public Guid Id { get; set; }
    public Guid UniversityId { get; set; }
    public string FullName { get; set; } = null!;
    public string? TeamType { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Dni { get; set; }
    public string? PhotoUrl { get; set; }
    public string? Position { get; set; }
    public string? Specialty { get; set; }
    public string? AreaRepresented { get; set; }
    public string? ResolutionNumber { get; set; }
    public DateOnly? ResolutionDate { get; set; }
    public string? ResolutionFileUrl { get; set; }
    public bool IsActive { get; set; }
    public bool IsPublic { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
