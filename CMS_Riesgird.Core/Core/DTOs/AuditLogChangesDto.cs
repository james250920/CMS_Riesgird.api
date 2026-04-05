namespace CMS_Riesgird.Core.Core.DTOs;

public class CreateAuditLogChangeDto
{
    public Guid AuditLogId { get; set; }
    public string Field { get; set; } = null!;
    public string? OldValue { get; set; }
    public string? NewValue { get; set; }
}

public class AuditLogChangeResponseDto
{
    public Guid Id { get; set; }
    public Guid AuditLogId { get; set; }
    public string Field { get; set; } = null!;
    public string? OldValue { get; set; }
    public string? NewValue { get; set; }
}
