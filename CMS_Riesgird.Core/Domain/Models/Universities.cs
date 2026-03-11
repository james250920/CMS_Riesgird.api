using System;
using System.Collections.Generic;

namespace CMS_Riesgird.Domain.Models;

/// <summary>
/// Universidades miembros de la red
/// </summary>
public partial class Universities
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string ShortName { get; set; } = null!;

    public string? LogoUrl { get; set; }

    public string? WebsiteUrl { get; set; }

    public string? Address { get; set; }

    public string City { get; set; } = null!;

    public string Region { get; set; } = null!;

    public int? FoundedYear { get; set; }

    public DateOnly? MembershipDate { get; set; }

    public string? CertificateNumber { get; set; }

    public string? CertificateFileUrl { get; set; }

    public bool IsActive { get; set; }

    public bool IsPublic { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? UpdatedBy { get; set; }

    public virtual ICollection<Authorities> Authorities { get; set; } = new List<Authorities>();

    public virtual Users? CreatedByNavigation { get; set; }

    public virtual ICollection<MembershipApplications> MembershipApplications { get; set; } = new List<MembershipApplications>();

    public virtual ICollection<MembershipCertificates> MembershipCertificates { get; set; } = new List<MembershipCertificates>();

    public virtual ICollection<Researchers> Researchers { get; set; } = new List<Researchers>();

    public virtual ICollection<TechnicalTeamMembers> TechnicalTeamMembers { get; set; } = new List<TechnicalTeamMembers>();

    public virtual ICollection<UniversityBrigades> UniversityBrigades { get; set; } = new List<UniversityBrigades>();

    public virtual ICollection<UniversityReports> UniversityReports { get; set; } = new List<UniversityReports>();

    public virtual Users? UpdatedByNavigation { get; set; }

    public virtual ICollection<Users> Users { get; set; } = new List<Users>();
}
