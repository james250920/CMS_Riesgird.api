using System;
using System.Collections.Generic;
using System.Net;

namespace CMS_Riesgird.Domain.Models;

/// <summary>
/// Registro de auditoría de todas las acciones del sistema
/// </summary>
public partial class AuditLogs
{
    public Guid Id { get; set; }

    public Guid? UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string Action { get; set; } = null!;

    public string EntityType { get; set; } = null!;

    public string EntityId { get; set; } = null!;

    public IPAddress? IpAddress { get; set; }

    public string? UserAgent { get; set; }

    public DateTime Timestamp { get; set; }

    public virtual ICollection<AuditLogChanges> AuditLogChanges { get; set; } = new List<AuditLogChanges>();

    public virtual Users? User { get; set; }
}
