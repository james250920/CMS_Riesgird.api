namespace CMS_Riesgird.Core.Core.DTOs;

public class CreateAuditLogDto
{
    public Guid? UserId { get; set; }
    public string UserName { get; set; } = null!;
    public string Action { get; set; } = null!;
    public string EntityType { get; set; } = null!;
    public string EntityId { get; set; } = null!;
    public string? IpAddress { get; set; }
    public string? Description { get; set; }
}

public class AuditLogResponseDto
{
    public Guid Id { get; set; }
    public Guid? UserId { get; set; }
    public string UserName { get; set; } = null!;
    public string Action { get; set; } = null!;
    public string EntityType { get; set; } = null!;
    public string EntityId { get; set; } = null!;
    public string? IpAddress { get; set; }
    public string? Description { get; set; }
    public DateTime Timestamp { get; set; }
}

public class AuditLogFilterDto
{
    public Guid? UserId { get; set; }
    public string? EntityType { get; set; }
    public string? Action { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}
