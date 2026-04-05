namespace CMS_Riesgird.Core.Core.DTOs;

public class CreateUserSessionDto
{
    public Guid UserId { get; set; }
    public string TokenHash { get; set; } = null!;
    public string? RefreshToken { get; set; }
    public string? IpAddress { get; set; }
    public string? UserAgent { get; set; }
    public bool RememberMe { get; set; }
    public int ExpirationMinutes { get; set; } = 60;
}

public class UpdateUserSessionDto
{
    public Guid Id { get; set; }
    public string? RefreshToken { get; set; }
    public bool IsActive { get; set; }
}

public class UserSessionResponseDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string? IpAddress { get; set; }
    public string? UserAgent { get; set; }
    public bool RememberMe { get; set; }
    public bool IsActive { get; set; }
    public DateTime ExpiresAt { get; set; }
    public DateTime LastActivity { get; set; }
}
