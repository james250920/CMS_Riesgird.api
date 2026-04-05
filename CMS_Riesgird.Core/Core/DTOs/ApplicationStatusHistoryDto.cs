namespace CMS_Riesgird.Core.Core.DTOs;

public class CreateApplicationStatusHistoryDto
{
    public Guid ApplicationId { get; set; }
    public string Status { get; set; } = null!;
    public Guid? ChangedBy { get; set; }
    public string? Notes { get; set; }
}

public class UpdateApplicationStatusHistoryDto
{
    public Guid Id { get; set; }
    public Guid ApplicationId { get; set; }
    public string Status { get; set; } = null!;
    public Guid? ChangedBy { get; set; }
    public string? Notes { get; set; }
}

public class ApplicationStatusHistoryResponseDto
{
    public Guid Id { get; set; }
    public Guid ApplicationId { get; set; }
    public string Status { get; set; } = null!;
    public DateTime ChangedAt { get; set; }
    public Guid? ChangedBy { get; set; }
    public string? Notes { get; set; }
}
