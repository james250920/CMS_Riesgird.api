using System;
using System.Collections.Generic;

namespace CMS_Riesgird.Domain.Models;

/// <summary>
/// Usuarios del sistema con autenticación y perfiles
/// </summary>
public partial class Users
{
    public Guid Id { get; set; }

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string? PhotoUrl { get; set; }

    public string? Phone { get; set; }

    public Guid RoleId { get; set; }

    public Guid? UniversityId { get; set; }

    public string? Position { get; set; }

    public bool IsActive { get; set; }

    public DateTime? LastLogin { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<ApplicationDocuments> ApplicationDocuments { get; set; } = new List<ApplicationDocuments>();

    public virtual ICollection<ApplicationStatusHistory> ApplicationStatusHistory { get; set; } = new List<ApplicationStatusHistory>();

    public virtual ICollection<Assemblies> Assemblies { get; set; } = new List<Assemblies>();

    public virtual ICollection<AuditLogs> AuditLogs { get; set; } = new List<AuditLogs>();

    public virtual ICollection<CalendarEvents> CalendarEvents { get; set; } = new List<CalendarEvents>();

    public virtual ICollection<Congresses> Congresses { get; set; } = new List<Congresses>();

    public virtual ICollection<DownloadableTemplates> DownloadableTemplates { get; set; } = new List<DownloadableTemplates>();

    public virtual ICollection<EventPhotos> EventPhotos { get; set; } = new List<EventPhotos>();

    public virtual ICollection<ForumEvents> ForumEvents { get; set; } = new List<ForumEvents>();

    public virtual ICollection<InstitutionalContents> InstitutionalContents { get; set; } = new List<InstitutionalContents>();

    public virtual ICollection<ManagementMemories> ManagementMemories { get; set; } = new List<ManagementMemories>();

    public virtual ICollection<MembershipApplications> MembershipApplicationsAssignedToNavigation { get; set; } = new List<MembershipApplications>();

    public virtual ICollection<MembershipApplications> MembershipApplicationsReviewedByNavigation { get; set; } = new List<MembershipApplications>();

    public virtual ICollection<MembershipCertificates> MembershipCertificates { get; set; } = new List<MembershipCertificates>();

    public virtual ICollection<NormativeDocuments> NormativeDocuments { get; set; } = new List<NormativeDocuments>();

    public virtual ICollection<PhotoAlbums> PhotoAlbums { get; set; } = new List<PhotoAlbums>();

    public virtual Roles Role { get; set; } = null!;

    public virtual ICollection<SystemConfig> SystemConfig { get; set; } = new List<SystemConfig>();

    public virtual ICollection<Universities> UniversitiesCreatedByNavigation { get; set; } = new List<Universities>();

    public virtual ICollection<Universities> UniversitiesUpdatedByNavigation { get; set; } = new List<Universities>();

    public virtual Universities? University { get; set; }

    public virtual ICollection<UniversityReports> UniversityReportsSubmittedByNavigation { get; set; } = new List<UniversityReports>();

    public virtual ICollection<UniversityReports> UniversityReportsUploadedByNavigation { get; set; } = new List<UniversityReports>();

    public virtual ICollection<UserPermissions> UserPermissions { get; set; } = new List<UserPermissions>();

    public virtual ICollection<UserSessions> UserSessions { get; set; } = new List<UserSessions>();
}
