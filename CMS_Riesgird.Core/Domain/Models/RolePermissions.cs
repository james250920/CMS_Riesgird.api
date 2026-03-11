using System;
using System.Collections.Generic;

namespace CMS_Riesgird.Domain.Models;

/// <summary>
/// Matriz de permisos: qué acciones puede realizar cada rol en cada módulo
/// </summary>
public partial class RolePermissions
{
    public Guid Id { get; set; }

    public Guid RoleId { get; set; }

    public bool IsAllowed { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Roles Role { get; set; } = null!;
}
