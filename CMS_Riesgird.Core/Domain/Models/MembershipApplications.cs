using System;
using System.Collections.Generic;

namespace CMS_Riesgird.Domain.Models;

/// <summary>
/// Solicitudes de membresía y adscripción de universidades
/// </summary>
public partial class MembershipApplications
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

    public DateTime? SubmittedAt { get; set; }

    public DateTime? ReviewStartedAt { get; set; }

    public DateTime? ReviewCompletedAt { get; set; }

    public string? RejectionReason { get; set; }

    public bool CertificateAssigned { get; set; }

    public string? CertificateNumber { get; set; }

    public DateOnly? CertificateDate { get; set; }

    public string? CertificateFileUrl { get; set; }

    public string? Notes { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public Guid? ReviewedBy { get; set; }

    public virtual ICollection<ApplicationDocuments> ApplicationDocuments { get; set; } = new List<ApplicationDocuments>();

    public virtual ICollection<ApplicationStatusHistory> ApplicationStatusHistory { get; set; } = new List<ApplicationStatusHistory>();

    public virtual Users? AssignedToNavigation { get; set; }

    public virtual Users? ReviewedByNavigation { get; set; }

    public virtual Universities? University { get; set; }
}
