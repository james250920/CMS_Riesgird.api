namespace CMS_Riesgird.Core.Core.DTOs;

public class CreateCommitteeMemberDto
{
    public Guid CongressId { get; set; }
    public string FullName { get; set; } = null!;
    public string Role { get; set; } = null!;
    public string Institution { get; set; } = null!;
    public string? Email { get; set; }
    public int SortOrder { get; set; }
    public Guid? CreatedBy { get; set; }
}

public class UpdateCommitteeMemberDto
{
    public Guid Id { get; set; }
    public Guid CongressId { get; set; }
    public string FullName { get; set; } = null!;
    public string Role { get; set; } = null!;
    public string Institution { get; set; } = null!;
    public string? Email { get; set; }
    public int SortOrder { get; set; }
    public Guid? UpdatedBy { get; set; }
}

public class CommitteeMemberResponseDto
{
    public Guid Id { get; set; }
    public Guid CongressId { get; set; }
    public string FullName { get; set; } = null!;
    public string Role { get; set; } = null!;
    public string Institution { get; set; } = null!;
    public string? Email { get; set; }
    public int SortOrder { get; set; }
}
