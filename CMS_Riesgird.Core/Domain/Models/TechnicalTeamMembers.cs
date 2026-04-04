using System;
using System.Collections.Generic;

namespace CMS_Riesgird.Domain.Models;

/// <summary>
/// Miembros de equipos técnicos por universidad
/// </summary>
public partial class TechnicalTeamMembers
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

    public virtual Universities University { get; set; } = null!;
}
