using System;
using System.Collections.Generic;

namespace CMS_Riesgird.Domain.Models;

/// <summary>
/// Directorio de aliados estratégicos de la red
/// </summary>
public partial class Allies
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string LogoUrl { get; set; } = null!;

    public string? WebsiteUrl { get; set; }

    public string? ContactEmail { get; set; }

    public string? ContactPhone { get; set; }

    public string? Description { get; set; }

    public bool IsActive { get; set; }

    public bool IsPublic { get; set; }

    public int SortOrder { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
