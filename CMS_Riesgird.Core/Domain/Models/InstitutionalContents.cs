using System;
using System.Collections.Generic;

namespace CMS_Riesgird.Domain.Models;

/// <summary>
/// Contenido institucional: misión, visión, objetivos, lineamientos
/// </summary>
public partial class InstitutionalContents
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public bool IsPublic { get; set; }

    public DateTime LastUpdated { get; set; }

    public Guid? UpdatedBy { get; set; }

    public virtual Users? UpdatedByNavigation { get; set; }
}
