using System;
using System.Collections.Generic;

namespace CMS_Riesgird.Domain.Models;

/// <summary>
/// Brigadas de gestión del riesgo por universidad
/// </summary>
public partial class UniversityBrigades
{
    public Guid Id { get; set; }

    public Guid UniversityId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? Coordinator { get; set; }

    public string? CoordinatorEmail { get; set; }

    public string? CoordinatorPhone { get; set; }

    public string? ContactEmail { get; set; }

    public int? MembersCount { get; set; }

    public DateOnly? FoundedDate { get; set; }

    public List<string>? Certifications { get; set; }

    public string? LogoUrl { get; set; }

    public bool IsActive { get; set; }

    public bool IsPublic { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Universities University { get; set; } = null!;
}
