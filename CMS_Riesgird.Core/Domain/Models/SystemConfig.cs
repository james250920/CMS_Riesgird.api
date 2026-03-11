using System;
using System.Collections.Generic;

namespace CMS_Riesgird.Domain.Models;

/// <summary>
/// Parámetros de configuración global del sistema
/// </summary>
public partial class SystemConfig
{
    public Guid Id { get; set; }

    public string Key { get; set; } = null!;

    public string Value { get; set; } = null!;

    public string? Description { get; set; }

    public bool IsEditable { get; set; }

    public DateTime UpdatedAt { get; set; }

    public Guid? UpdatedBy { get; set; }

    public virtual Users? UpdatedByNavigation { get; set; }
}
