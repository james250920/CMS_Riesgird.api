using System;
using System.Collections.Generic;

namespace CMS_Riesgird.Domain.Models;

/// <summary>
/// Requisitos para el proceso de membresía / adscripción
/// </summary>
public partial class MembershipRequirements
{
    public Guid Id { get; set; }

    public int SortOrder { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string? DocumentFormat { get; set; }

    public string? MaxFileSize { get; set; }

    public bool IsRequired { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
