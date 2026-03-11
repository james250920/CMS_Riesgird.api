using System;
using System.Collections.Generic;

namespace CMS_Riesgird.Domain.Models;

/// <summary>
/// Documentos normativos: estatutos, planes de trabajo, reglamentos
/// </summary>
public partial class NormativeDocuments
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string FileUrl { get; set; } = null!;

    public string FileName { get; set; } = null!;

    public long FileSize { get; set; }

    public DateTime UploadDate { get; set; }

    public DateOnly ValidFrom { get; set; }

    public DateOnly? ValidTo { get; set; }

    public bool IsActive { get; set; }

    public bool IsPublic { get; set; }

    public Guid? UploadedBy { get; set; }

    public virtual Users? UploadedByNavigation { get; set; }
}
