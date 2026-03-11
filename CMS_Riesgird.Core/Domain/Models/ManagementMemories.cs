using System;
using System.Collections.Generic;

namespace CMS_Riesgird.Domain.Models;

/// <summary>
/// Memorias de gestión anuales, semestrales y especiales
/// </summary>
public partial class ManagementMemories
{
    public Guid Id { get; set; }

    public int Year { get; set; }

    public string? Period { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string? President { get; set; }

    public string? Introduction { get; set; }

    public string? Summary { get; set; }

    public int? PageCount { get; set; }

    public List<string>? Highlights { get; set; }

    public string? DocumentUrl { get; set; }

    public string? DigitalBookUrl { get; set; }

    public string? CoverImageUrl { get; set; }

    public string? CustomStats { get; set; }

    public bool IsPublic { get; set; }

    public DateOnly? PublishedDate { get; set; }

    public DateTime? PublishedAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public Guid? CreatedBy { get; set; }

    public virtual ICollection<Achievements> Achievements { get; set; } = new List<Achievements>();

    public virtual ICollection<Activities> Activities { get; set; } = new List<Activities>();

    public virtual Users? CreatedByNavigation { get; set; }
}
