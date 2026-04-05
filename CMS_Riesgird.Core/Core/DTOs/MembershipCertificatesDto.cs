namespace CMS_Riesgird.Core.Core.DTOs;

public class CreateMembershipCertificateDto
{
    public Guid UniversityId { get; set; }
    public string UniversityName { get; set; } = null!;
    public string CertificateNumber { get; set; } = null!;
    public string? CertificateType { get; set; }
    public DateOnly IssueDate { get; set; }
    public DateOnly ValidFrom { get; set; }
    public DateOnly? ValidTo { get; set; }
    public string? CertificateUrl { get; set; }
    public bool IsValid { get; set; }
    public Guid? CreatedBy { get; set; }
}

public class UpdateMembershipCertificateDto
{
    public Guid Id { get; set; }
    public Guid UniversityId { get; set; }
    public string UniversityName { get; set; } = null!;
    public string CertificateNumber { get; set; } = null!;
    public string? CertificateType { get; set; }
    public DateOnly IssueDate { get; set; }
    public DateOnly ValidFrom { get; set; }
    public DateOnly? ValidTo { get; set; }
    public string? CertificateUrl { get; set; }
    public bool IsValid { get; set; }
    public Guid? UpdatedBy { get; set; }
}

public class MembershipCertificateResponseDto
{
    public Guid Id { get; set; }
    public Guid UniversityId { get; set; }
    public string UniversityName { get; set; } = null!;
    public string CertificateNumber { get; set; } = null!;
    public string? CertificateType { get; set; }
    public DateOnly IssueDate { get; set; }
    public DateOnly ValidFrom { get; set; }
    public DateOnly? ValidTo { get; set; }
    public string? CertificateUrl { get; set; }
    public bool IsValid { get; set; }
}
