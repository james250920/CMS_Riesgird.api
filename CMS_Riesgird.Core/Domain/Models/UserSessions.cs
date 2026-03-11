using System;
using System.Collections.Generic;
using System.Net;

namespace CMS_Riesgird.Domain.Models;

/// <summary>
/// Sesiones activas de usuarios con soporte para remember-me
/// </summary>
public partial class UserSessions
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string TokenHash { get; set; } = null!;

    public string? RefreshToken { get; set; }

    public IPAddress? IpAddress { get; set; }

    public string? UserAgent { get; set; }

    public bool RememberMe { get; set; }

    public bool IsActive { get; set; }

    public DateTime ExpiresAt { get; set; }

    public DateTime LastActivity { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Users User { get; set; } = null!;
}
