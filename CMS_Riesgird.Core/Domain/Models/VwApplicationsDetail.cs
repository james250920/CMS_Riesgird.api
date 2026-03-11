using System;
using System.Collections.Generic;

namespace CMS_Riesgird.Domain.Models;

public partial class VwApplicationsDetail
{
    public Guid? Id { get; set; }

    public string? ApplicationNumber { get; set; }

    public string? UniversityName { get; set; }

    public string? ApplicantName { get; set; }

    public string? ApplicantEmail { get; set; }

    public DateOnly? ApplicationDate { get; set; }

    public bool? CertificateAssigned { get; set; }

    public string? CertificateNumber { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? AssignedToName { get; set; }

    public string? ReviewedByName { get; set; }

    public long? DocumentsCount { get; set; }

    public long? ValidDocumentsCount { get; set; }
}
