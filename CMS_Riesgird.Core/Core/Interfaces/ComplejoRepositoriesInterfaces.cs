using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Core.Interfaces;

public interface IUserSessionRepository
{
    Task<IEnumerable<UserSessions>> GetAllSessionsAsync();
    Task<UserSessions?> GetSessionByIdAsync(Guid id);
    Task<IEnumerable<UserSessions>> GetActiveSessionsByUserIdAsync(Guid userId);
    Task<UserSessions?> GetSessionByTokenAsync(string tokenHash);
    Task<IEnumerable<UserSessions>> GetExpiredSessionsAsync();
    Task AddSessionAsync(UserSessions session);
    Task UpdateSessionAsync(UserSessions session);
    Task DeleteSessionAsync(Guid id);
    Task InvalidateUserSessionsAsync(Guid userId);
}

public interface IRolePermissionRepository
{
    Task<IEnumerable<RolePermissions>> GetAllPermissionsAsync();
    Task<RolePermissions?> GetPermissionByIdAsync(Guid id);
    Task<IEnumerable<RolePermissions>> GetPermissionsByRoleIdAsync(Guid roleId);
    Task AddPermissionAsync(RolePermissions permission);
    Task UpdatePermissionAsync(RolePermissions permission);
    Task DeletePermissionAsync(Guid id);
}

public interface IUserPermissionRepository
{
    Task<IEnumerable<UserPermissions>> GetAllPermissionsAsync();
    Task<UserPermissions?> GetPermissionByIdAsync(Guid id);
    Task<IEnumerable<UserPermissions>> GetPermissionsByUserIdAsync(Guid userId);
    Task AddPermissionAsync(UserPermissions permission);
    Task UpdatePermissionAsync(UserPermissions permission);
    Task DeletePermissionAsync(Guid id);
}

public interface IUniversityReportRepository
{
    Task<IEnumerable<UniversityReports>> GetAllReportsAsync();
    Task<UniversityReports?> GetReportByIdAsync(Guid id);
    Task<IEnumerable<UniversityReports>> GetReportsByUniversityIdAsync(Guid universityId);
    Task<IEnumerable<UniversityReports>> GetReportsByYearAsync(int year);
    Task AddReportAsync(UniversityReports report);
    Task UpdateReportAsync(UniversityReports report);
    Task DeleteReportAsync(Guid id);
}

public interface IAuditLogRepository
{
    Task<IEnumerable<AuditLogs>> GetAllLogsAsync();
    Task<AuditLogs?> GetLogByIdAsync(Guid id);
    Task<IEnumerable<AuditLogs>> GetLogsByUserIdAsync(Guid userId);
    Task<IEnumerable<AuditLogs>> GetLogsByEntityTypeAsync(string entityType);
    Task<IEnumerable<AuditLogs>> GetLogsByDateRangeAsync(DateTime startDate, DateTime endDate);
    Task AddLogAsync(AuditLogs log);
}

public interface IAuditLogChangeRepository
{
    Task<IEnumerable<AuditLogChanges>> GetAllChangesAsync();
    Task<AuditLogChanges?> GetChangeByIdAsync(Guid id);
    Task<IEnumerable<AuditLogChanges>> GetChangesByAuditLogIdAsync(Guid auditLogId);
    Task AddChangeAsync(AuditLogChanges change);
    Task UpdateChangeAsync(AuditLogChanges change);
    Task DeleteChangeAsync(Guid id);
}

public interface IMembershipApplicationRepository
{
    Task<IEnumerable<MembershipApplications>> GetAllApplicationsAsync();
    Task<MembershipApplications?> GetApplicationByIdAsync(Guid id);
    Task<IEnumerable<MembershipApplications>> GetApplicationsByUniversityIdAsync(Guid universityId);
    Task<IEnumerable<MembershipApplications>> GetApplicationsAssignedToAsync(Guid userId);
    Task<IEnumerable<MembershipApplications>> GetPendingApplicationsAsync();
    Task AddApplicationAsync(MembershipApplications application);
    Task UpdateApplicationAsync(MembershipApplications application);
    Task DeleteApplicationAsync(Guid id);
    Task<string> GenerateApplicationNumberAsync();
}
