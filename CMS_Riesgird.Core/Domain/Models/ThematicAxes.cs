using System;
using System.Collections.Generic;

namespace CMS_Riesgird.Domain.Models;

/// <summary>
/// Ejes temáticos de cada congreso
/// </summary>
public partial class ThematicAxes
{
    public Guid Id { get; set; }

    public Guid CongressId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string? Coordinator { get; set; }

    public int SortOrder { get; set; }

    public virtual Congresses Congress { get; set; } = null!;
}
