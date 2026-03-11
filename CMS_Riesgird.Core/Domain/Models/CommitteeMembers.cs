using System;
using System.Collections.Generic;

namespace CMS_Riesgird.Domain.Models;

/// <summary>
/// Miembros del comité organizador de cada congreso
/// </summary>
public partial class CommitteeMembers
{
    public Guid Id { get; set; }

    public Guid CongressId { get; set; }

    public string FullName { get; set; } = null!;

    public string Role { get; set; } = null!;

    public string Institution { get; set; } = null!;

    public string? Email { get; set; }

    public int SortOrder { get; set; }

    public virtual Congresses Congress { get; set; } = null!;
}
