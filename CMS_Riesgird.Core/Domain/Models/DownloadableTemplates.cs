using System;
using System.Collections.Generic;

namespace CMS_Riesgird.Domain.Models;

/// <summary>
/// Plantillas y documentos descargables para el proceso de membresía
/// </summary>
public partial class DownloadableTemplates
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

    public bool IsPublic { get; set; }

    public Guid? UploadedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<MembershipCertificates> MembershipCertificates { get; set; } = new List<MembershipCertificates>();

    public virtual Users? UploadedByNavigation { get; set; }
}
