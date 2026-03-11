using System;
using System.Collections.Generic;

namespace CMS_Riesgird.Domain.Models;

/// <summary>
/// Acuerdos tomados en cada asamblea
/// </summary>
public partial class Agreements
{
    public Guid Id { get; set; }

    public Guid AssemblyId { get; set; }

    public string Number { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string? Responsible { get; set; }

    public DateOnly? DueDate { get; set; }

    public bool IsPublic { get; set; }

    public virtual Assemblies Assembly { get; set; } = null!;
}
