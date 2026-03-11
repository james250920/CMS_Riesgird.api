using System;
using System.Collections.Generic;

namespace CMS_Riesgird.Domain.Models;

/// <summary>
/// Informes y reportes de cada universidad miembro
/// </summary>
public partial class UniversityReports
{
    public Guid Id { get; set; }

    public Guid UniversityId { get; set; }

    public int Year { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string? PeriodStart { get; set; }

    public string? PeriodEnd { get; set; }

    public string? DocumentUrl { get; set; }

    public string? FileUrl { get; set; }

    public string? FileName { get; set; }

    public long? FileSize { get; set; }

    public DateTime? UploadDate { get; set; }

    public DateTime? SubmittedAt { get; set; }

    public Guid? SubmittedBy { get; set; }

    public bool IsPublic { get; set; }

    public Guid? UploadedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Users? SubmittedByNavigation { get; set; }

    public virtual Universities University { get; set; } = null!;

    public virtual Users? UploadedByNavigation { get; set; }
}
