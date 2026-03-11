using System;
using System.Collections.Generic;

namespace CMS_Riesgird.Domain.Models;

/// <summary>
/// Galería fotográfica de eventos (asambleas, foros, congresos)
/// </summary>
public partial class EventPhotos
{
    public Guid Id { get; set; }

    public Guid EventId { get; set; }

    public string Url { get; set; } = null!;

    public string? ThumbnailUrl { get; set; }

    public string? Caption { get; set; }

    public string? Photographer { get; set; }

    public DateTime? TakenAt { get; set; }

    public int SortOrder { get; set; }

    public bool IsPublic { get; set; }

    public bool IsFeatured { get; set; }

    public DateTime UploadedAt { get; set; }

    public Guid? UploadedBy { get; set; }

    public virtual Users? UploadedByNavigation { get; set; }
}
