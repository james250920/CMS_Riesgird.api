namespace CMS_Riesgird.Core.Core.DTOs;

public class CreateDownloadableTemplateDto
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string? FileUrl { get; set; }
    public string? FileName { get; set; }
    public string? FileSize { get; set; }
    public string? Version { get; set; }
    public bool IsActive { get; set; }
    public Guid? CreatedBy { get; set; }
}

public class UpdateDownloadableTemplateDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string? FileUrl { get; set; }
    public string? FileName { get; set; }
    public string? FileSize { get; set; }
    public string? Version { get; set; }
    public bool IsActive { get; set; }
    public Guid? UpdatedBy { get; set; }
}

public class DownloadableTemplateResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string? FileUrl { get; set; }
    public string? FileName { get; set; }
    public string? FileSize { get; set; }
    public string? Version { get; set; }
    public int DownloadCount { get; set; }
    public DateTime? UploadDate { get; set; }
    public bool IsActive { get; set; }
}
