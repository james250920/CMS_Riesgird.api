using System;
using System.Collections.Generic;

namespace CMS_Riesgird.Domain.Models;

/// <summary>
/// Ponentes y conferencistas de cada congreso
/// </summary>
public partial class Speakers
{
    public Guid Id { get; set; }

    public Guid CongressId { get; set; }

    public string FullName { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Institution { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string? PhotoUrl { get; set; }

    public string? Biography { get; set; }

    public string? PresentationTitle { get; set; }

    public virtual Congresses Congress { get; set; } = null!;
}
