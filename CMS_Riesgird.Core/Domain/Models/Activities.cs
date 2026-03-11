using System;
using System.Collections.Generic;

namespace CMS_Riesgird.Domain.Models;

/// <summary>
/// Actividades realizadas asociadas a cada memoria de gestión
/// </summary>
public partial class Activities
{
    public Guid Id { get; set; }

    public Guid MemoryId { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateOnly Date { get; set; }

    public string? Location { get; set; }

    public int? Participants { get; set; }

    public List<string>? Photos { get; set; }

    public List<string>? DocumentsUrls { get; set; }

    public int SortOrder { get; set; }

    public virtual ManagementMemories Memory { get; set; } = null!;
}
