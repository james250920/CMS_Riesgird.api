namespace CMS_Riesgird.Core.Core.DTOs;

public class CreateMembershipApplicationDto
{
    public Guid? UniversityId { get; set; }
    public string UniversityName { get; set; } = null!;
    public string ApplicantName { get; set; } = null!;
    public string ApplicantEmail { get; set; } = null!;
    public string? ApplicantPhone { get; set; }
    public DateOnly ApplicationDate { get; set; }
    public string? ContactName { get; set; }
    public string? ContactPosition { get; set; }
    public string? ContactEmail { get; set; }
    public string? ContactPhone { get; set; }
    public Guid? AssignedTo { get; set; }
    public string? Notes { get; set; }
    public Guid? CreatedBy { get; set; }
}

public class UpdateMembershipApplicationDto
{
    public Guid Id { get; set; }
    public Guid? UniversityId { get; set; }
    public string UniversityName { get; set; } = null!;
    public string ApplicantName { get; set; } = null!;
    public string ApplicantEmail { get; set; } = null!;
    public string? ApplicantPhone { get; set; }
    public string? ContactName { get; set; }
    public string? ContactPosition { get; set; }
    public string? ContactEmail { get; set; }
    public string? ContactPhone { get; set; }
    public Guid? AssignedTo { get; set; }
    public string? Notes { get; set; }
    public string? Status { get; set; }
    public Guid? UpdatedBy { get; set; }
}

public class MembershipApplicationResponseDto
{
    public Guid Id { get; set; }
    public string? ApplicationNumber { get; set; }
    public Guid? UniversityId { get; set; }
    public string UniversityName { get; set; } = null!;
    public string ApplicantName { get; set; } = null!;
    public string ApplicantEmail { get; set; } = null!;
    public string? ApplicantPhone { get; set; }
    public DateOnly ApplicationDate { get; set; }
    public string? ContactName { get; set; }
    public string? ContactPosition { get; set; }
    public string? ContactEmail { get; set; }
    public string? ContactPhone { get; set; }
    public Guid? AssignedTo { get; set; }
    public string? Notes { get; set; }
    public string? Status { get; set; }
    public DateTime CreatedAt { get; set; }
}
