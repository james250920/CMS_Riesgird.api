using System;
using System.Collections.Generic;

namespace CMS_Riesgird.Domain.Models;

/// <summary>
/// Autoridades de cada universidad miembro
/// </summary>
public partial class Authorities
{
    public Guid Id { get; set; }

    public Guid UniversityId { get; set; }

    public string Role { get; set; } = null!;

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

    public virtual Universities University { get; set; } = null!;
}
