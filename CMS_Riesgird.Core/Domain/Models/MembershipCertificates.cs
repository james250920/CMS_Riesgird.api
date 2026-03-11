using System;
using System.Collections.Generic;

namespace CMS_Riesgird.Domain.Models;

/// <summary>
/// Certificados de membresía emitidos a universidades
/// </summary>
public partial class MembershipCertificates
{
    public Guid Id { get; set; }

    public Guid UniversityId { get; set; }

    public string UniversityName { get; set; } = null!;

    public string CertificateNumber { get; set; } = null!;

    public string? CertificateType { get; set; }

    public DateOnly IssueDate { get; set; }

    public DateOnly ValidFrom { get; set; }

    public DateOnly? ValidTo { get; set; }

    public Guid? TemplateId { get; set; }

    public string? GeneratedFileUrl { get; set; }

    public string Status { get; set; } = null!;

    public bool IsActive { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Users? CreatedByNavigation { get; set; }

    public virtual DownloadableTemplates? Template { get; set; }

    public virtual Universities University { get; set; } = null!;
}
