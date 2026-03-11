using System;
using System.Collections.Generic;

namespace CMS_Riesgird.Domain.Models;

/// <summary>
/// Documentos adjuntos a cada solicitud de membresía
/// </summary>
public partial class ApplicationDocuments
{
    public Guid Id { get; set; }

    public Guid ApplicationId { get; set; }

    public string Name { get; set; } = null!;

    public string FileUrl { get; set; } = null!;

    public string FileName { get; set; } = null!;

    public DateTime UploadDate { get; set; }

    public bool IsValid { get; set; }

    public string? ValidationNotes { get; set; }

    public Guid? ValidatedBy { get; set; }

    public DateTime? ValidatedAt { get; set; }

    public virtual MembershipApplications Application { get; set; } = null!;

    public virtual Users? ValidatedByNavigation { get; set; }
}
