using System;
using System.Collections.Generic;

namespace CMS_Riesgird.Domain.Models;

/// <summary>
/// Puntos de agenda de cada asamblea
/// </summary>
public partial class AgendaItems
{
    public Guid Id { get; set; }

    public Guid AssemblyId { get; set; }

    public int SortOrder { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string? Presenter { get; set; }

    public int? Duration { get; set; }

    public virtual Assemblies Assembly { get; set; } = null!;
}
