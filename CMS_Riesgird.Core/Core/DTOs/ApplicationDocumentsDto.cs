namespace CMS_Riesgird.Core.Core.DTOs;

public class CreateApplicationDocumentDto
{
    public Guid ApplicationId { get; set; }
    public string Name { get; set; } = null!;
    public string FileUrl { get; set; } = null!;
    public string FileName { get; set; } = null!;
    public bool IsValid { get; set; }
    public string? ValidationNotes { get; set; }
    public Guid? CreatedBy { get; set; }
}

public class UpdateApplicationDocumentDto
{
    public Guid Id { get; set; }
    public Guid ApplicationId { get; set; }
    public string Name { get; set; } = null!;
    public string FileUrl { get; set; } = null!;
    public string FileName { get; set; } = null!;
    public bool IsValid { get; set; }
    public string? ValidationNotes { get; set; }
    public Guid? UpdatedBy { get; set; }
}

public class ApplicationDocumentResponseDto
{
    public Guid Id { get; set; }
    public Guid ApplicationId { get; set; }
    public string Name { get; set; } = null!;
    public string FileUrl { get; set; } = null!;
    public string FileName { get; set; } = null!;
    public DateTime UploadDate { get; set; }
    public bool IsValid { get; set; }
    public string? ValidationNotes { get; set; }
}
