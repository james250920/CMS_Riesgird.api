using System;
using System.Collections.Generic;

namespace CMS_Riesgird.Domain.Models;

public partial class VwUsersDetail
{
    public Guid? Id { get; set; }

    public string? Email { get; set; }

    public string? FullName { get; set; }

    public string? PhotoUrl { get; set; }

    public string? Phone { get; set; }

    public string? Position { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? LastLogin { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? RoleName { get; set; }

    public int? RoleLevel { get; set; }

    public string? RoleColor { get; set; }

    public string? UniversityName { get; set; }

    public string? UniversityShortName { get; set; }
}
