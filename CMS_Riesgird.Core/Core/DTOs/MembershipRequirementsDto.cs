namespace CMS_Riesgird.Core.Core.DTOs;

public class CreateMembershipRequirementDto
{
    public int SortOrder { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string? DocumentFormat { get; set; }
    public string? MaxFileSize { get; set; }
    public bool IsRequired { get; set; }
    public bool IsActive { get; set; }
    public Guid? CreatedBy { get; set; }
}

public class UpdateMembershipRequirementDto
{
    public Guid Id { get; set; }
    public int SortOrder { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string? DocumentFormat { get; set; }
    public string? MaxFileSize { get; set; }
    public bool IsRequired { get; set; }
    public bool IsActive { get; set; }
    public Guid? UpdatedBy { get; set; }
}

public class MembershipRequirementResponseDto
{
    public Guid Id { get; set; }
    public int SortOrder { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string? DocumentFormat { get; set; }
    public string? MaxFileSize { get; set; }
    public bool IsRequired { get; set; }
    public bool IsActive { get; set; }
}
