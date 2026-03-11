using System;
using System.Collections.Generic;

namespace CMS_Riesgird.Domain.Models;

/// <summary>
/// Permisos específicos por usuario que sobreescriben los del rol
/// </summary>
public partial class UserPermissions
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public bool IsAllowed { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Users User { get; set; } = null!;
}
