using System;
using System.Collections.Generic;

namespace CMS_Riesgird.Domain.Models;

/// <summary>
/// Asambleas ordinarias y extraordinarias de la red
/// </summary>
public partial class Assemblies
{
    public Guid Id { get; set; }

    public int Year { get; set; }

    public int Number { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public DateOnly Date { get; set; }

    public string Location { get; set; } = null!;

    public string? VirtualLink { get; set; }

    public string? AgendaFileUrl { get; set; }

    public string? AgendaFileName { get; set; }

    public string? AgreementsFileUrl { get; set; }

    public string? AgreementsFileName { get; set; }

    public string? ConvocationUrl { get; set; }

    public string? MinutesUrl { get; set; }

    public string? MinutesFileUrl { get; set; }

    public string? MinutesFileName { get; set; }

    public int? AttendeesCount { get; set; }

    public bool IsPublic { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public Guid? CreatedBy { get; set; }

    public virtual ICollection<AgendaItems> AgendaItems { get; set; } = new List<AgendaItems>();

    public virtual ICollection<Agreements> Agreements { get; set; } = new List<Agreements>();

    public virtual Users? CreatedByNavigation { get; set; }
}
