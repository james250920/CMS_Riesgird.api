using System;
using System.Collections.Generic;

namespace CMS_Riesgird.Domain.Models;

/// <summary>
/// Trazabilidad de cambios de estado en solicitudes de membresía
/// </summary>
public partial class ApplicationStatusHistory
{
    public Guid Id { get; set; }

    public Guid ApplicationId { get; set; }

    public string Status { get; set; } = null!;

    public DateTime ChangedAt { get; set; }

    public Guid? ChangedBy { get; set; }

    public string? Notes { get; set; }

    public virtual MembershipApplications Application { get; set; } = null!;

    public virtual Users? ChangedByNavigation { get; set; }
}
