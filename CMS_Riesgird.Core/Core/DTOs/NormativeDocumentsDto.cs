namespace CMS_Riesgird.Core.Core.DTOs;

public class CreateNormativeDocumentDto
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string FileUrl { get; set; } = null!;
    public string FileName { get; set; } = null!;
    public long FileSize { get; set; }
    public DateOnly ValidFrom { get; set; }
    public DateOnly? ValidUntil { get; set; }
    public bool IsActive { get; set; }
    public bool IsPublic { get; set; }
    public Guid? CreatedBy { get; set; }
}

public class UpdateNormativeDocumentDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string FileUrl { get; set; } = null!;
    public string FileName { get; set; } = null!;
    public long FileSize { get; set; }
    public DateOnly ValidFrom { get; set; }
    public DateOnly? ValidUntil { get; set; }
    public bool IsActive { get; set; }
    public bool IsPublic { get; set; }
    public Guid? UpdatedBy { get; set; }
}

public class NormativeDocumentResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string FileUrl { get; set; } = null!;
    public string FileName { get; set; } = null!;
    public long FileSize { get; set; }
    public DateTime UploadDate { get; set; }
    public DateOnly ValidFrom { get; set; }
    public DateOnly? ValidUntil { get; set; }
    public bool IsActive { get; set; }
    public bool IsPublic { get; set; }
}
