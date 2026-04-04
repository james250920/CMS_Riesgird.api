namespace CMS_Riesgird.Core.Core.DTOs;

/// <summary>
/// DTOs para el CRUD de Autoridades
/// </summary>
public class CreateAuthorityDto
{
    public Guid UniversityId { get; set; }
    public string FullName { get; set; } = null!;
    public string? AcademicDegree { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Dni { get; set; }
    public string? PhotoUrl { get; set; }
    public string? Position { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
    public bool IsCurrent { get; set; }
    public bool IsActive { get; set; }
    public bool IsPublic { get; set; }
    public Guid? CreatedBy { get; set; }
}

public class UpdateAuthorityDto
{
    public Guid Id { get; set; }
    public Guid UniversityId { get; set; }
    public string FullName { get; set; } = null!;
    public string? AcademicDegree { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Dni { get; set; }
    public string? PhotoUrl { get; set; }
    public string? Position { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
    public bool IsCurrent { get; set; }
    public bool IsActive { get; set; }
    public bool IsPublic { get; set; }
    public Guid? UpdatedBy { get; set; }
}

public class AuthorityResponseDto
{
    public Guid Id { get; set; }
    public Guid UniversityId { get; set; }
    public string FullName { get; set; } = null!;
    public string? AcademicDegree { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Dni { get; set; }
    public string? PhotoUrl { get; set; }
    public string? Position { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
    public bool IsCurrent { get; set; }
    public bool IsActive { get; set; }
    public bool IsPublic { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
