using System;
using System.Collections.Generic;

namespace CMS_Riesgird.Domain.Models;

/// <summary>
/// Logros destacados asociados a cada memoria de gestión
/// </summary>
public partial class Achievements
{
    public Guid Id { get; set; }

    public Guid MemoryId { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Category { get; set; } = null!;

    public DateOnly? Date { get; set; }

    public string? EvidenceUrl { get; set; }

    public int SortOrder { get; set; }

    public virtual ManagementMemories Memory { get; set; } = null!;
}
