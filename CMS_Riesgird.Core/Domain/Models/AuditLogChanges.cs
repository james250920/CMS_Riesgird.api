using System;
using System.Collections.Generic;

namespace CMS_Riesgird.Domain.Models;

/// <summary>
/// Detalle campo por campo de los cambios registrados en auditoría
/// </summary>
public partial class AuditLogChanges
{
    public Guid Id { get; set; }

    public Guid AuditLogId { get; set; }

    public string Field { get; set; } = null!;

    public string? OldValue { get; set; }

    public string? NewValue { get; set; }

    public virtual AuditLogs AuditLog { get; set; } = null!;
}
