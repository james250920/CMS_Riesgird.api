using System;
using System.Collections.Generic;

namespace CMS_Riesgird.Domain.Models;

/// <summary>
/// Roles del sistema con niveles jerárquicos
/// </summary>
public partial class Roles
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public int Level { get; set; }

    public string? Color { get; set; }

    public string? Description { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<RolePermissions> RolePermissions { get; set; } = new List<RolePermissions>();

    public virtual ICollection<Users> Users { get; set; } = new List<Users>();
}
