using System;
using System.Collections.Generic;

namespace CMS_Riesgird.Domain.Models;

/// <summary>
/// Calendario general de actividades de la red
/// </summary>
public partial class CalendarEvents
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public bool AllDay { get; set; }

    public string? Location { get; set; }

    public string? Color { get; set; }

    public Guid? RelatedEntityId { get; set; }

    public string? RelatedEntityType { get; set; }

    public bool IsPublic { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Users? CreatedByNavigation { get; set; }
}
