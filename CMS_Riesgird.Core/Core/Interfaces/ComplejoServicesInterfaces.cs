using CMS_Riesgird.Core.Core.DTOs;

namespace CMS_Riesgird.Core.Core.Interfaces;

public interface IUserSessionService
{
    Task<IEnumerable<UserSessionResponseDto>> GetAllSessions();
    Task<UserSessionResponseDto?> GetSessionById(Guid id);
    Task<IEnumerable<UserSessionResponseDto>> GetActiveSessionsByUserId(Guid userId);
    Task<Guid> CreateSession(CreateUserSessionDto dto);
    Task UpdateSession(Guid id, UpdateUserSessionDto dto);
    Task DeleteSession(Guid id);
    Task InvalidateUserSessions(Guid userId);
}

public interface IRolePermissionService
{
    Task<IEnumerable<RolePermissionResponseDto>> GetAllPermissions();
    Task<RolePermissionResponseDto?> GetPermissionById(Guid id);
    Task<IEnumerable<RolePermissionResponseDto>> GetPermissionsByRoleId(Guid roleId);
    Task<Guid> CreatePermission(CreateRolePermissionDto dto);
    Task UpdatePermission(Guid id, UpdateRolePermissionDto dto);
    Task DeletePermission(Guid id);
}

public interface IUserPermissionService
{
    Task<IEnumerable<UserPermissionResponseDto>> GetAllPermissions();
    Task<UserPermissionResponseDto?> GetPermissionById(Guid id);
    Task<IEnumerable<UserPermissionResponseDto>> GetPermissionsByUserId(Guid userId);
    Task<Guid> CreatePermission(CreateUserPermissionDto dto);
    Task UpdatePermission(Guid id, UpdateUserPermissionDto dto);
    Task DeletePermission(Guid id);
}

public interface IUniversityReportService
{
    Task<IEnumerable<UniversityReportResponseDto>> GetAllReports();
    Task<UniversityReportResponseDto?> GetReportById(Guid id);
    Task<IEnumerable<UniversityReportResponseDto>> GetReportsByUniversityId(Guid universityId);
    Task<IEnumerable<UniversityReportResponseDto>> GetReportsByYear(int year);
    Task<Guid> CreateReport(CreateUniversityReportDto dto);
    Task UpdateReport(Guid id, UpdateUniversityReportDto dto);
    Task DeleteReport(Guid id);
}

public interface IAuditLogService
{
    Task<IEnumerable<AuditLogResponseDto>> GetAllLogs();
    Task<AuditLogResponseDto?> GetLogById(Guid id);
    Task<IEnumerable<AuditLogResponseDto>> GetLogsByUserId(Guid userId);
    Task<IEnumerable<AuditLogResponseDto>> GetLogsByEntityType(string entityType);
    Task<IEnumerable<AuditLogResponseDto>> GetLogsByDateRange(DateTime startDate, DateTime endDate);
    Task<Guid> LogActionAsync(CreateAuditLogDto dto);
    Task LogChangeAsync(Guid auditLogId, string field, string? oldValue, string? newValue);
}

public interface IAuditLogChangeService
{
    Task<IEnumerable<AuditLogChangeResponseDto>> GetAllChanges();
    Task<AuditLogChangeResponseDto?> GetChangeById(Guid id);
    Task<IEnumerable<AuditLogChangeResponseDto>> GetChangesByAuditLogId(Guid auditLogId);
    Task<Guid> CreateChange(CreateAuditLogChangeDto dto);
    Task DeleteChange(Guid id);
}

public interface IMembershipApplicationService
{
    Task<IEnumerable<MembershipApplicationResponseDto>> GetAllApplications();
    Task<MembershipApplicationResponseDto?> GetApplicationById(Guid id);
    Task<IEnumerable<MembershipApplicationResponseDto>> GetApplicationsByUniversityId(Guid universityId);
    Task<IEnumerable<MembershipApplicationResponseDto>> GetPendingApplications();
    Task<Guid> CreateApplication(CreateMembershipApplicationDto dto);
    Task UpdateApplication(Guid id, UpdateMembershipApplicationDto dto);
    Task DeleteApplication(Guid id);
    Task<string> GenerateApplicationNumberAsync();
}
