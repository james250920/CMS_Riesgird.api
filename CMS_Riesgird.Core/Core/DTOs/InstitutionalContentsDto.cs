namespace CMS_Riesgird.Core.Core.DTOs;

public class CreateInstitutionalContentDto
{
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public bool IsPublic { get; set; }
    public Guid? UpdatedBy { get; set; }
}

public class UpdateInstitutionalContentDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public bool IsPublic { get; set; }
    public Guid? UpdatedBy { get; set; }
}

public class InstitutionalContentResponseDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public bool IsPublic { get; set; }
    public DateTime LastUpdated { get; set; }
}
