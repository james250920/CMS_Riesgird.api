using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Core.Services;

public class UserSessionService : IUserSessionService
{
    private readonly IUserSessionRepository _repository;
    public UserSessionService(IUserSessionRepository repository) => _repository = repository;
    public async Task<IEnumerable<UserSessionResponseDto>> GetAllSessions() => (await _repository.GetAllSessionsAsync()).Select(MapToResponseDto);
    public async Task<UserSessionResponseDto?> GetSessionById(Guid id) { var s = await _repository.GetSessionByIdAsync(id); return s == null ? null : MapToResponseDto(s); }
    public async Task<IEnumerable<UserSessionResponseDto>> GetActiveSessionsByUserId(Guid userId) => (await _repository.GetActiveSessionsByUserIdAsync(userId)).Select(MapToResponseDto);
    public async Task<Guid> CreateSession(CreateUserSessionDto dto)
    {
        var session = new UserSessions { Id = Guid.NewGuid(), UserId = dto.UserId, TokenHash = dto.TokenHash, RefreshToken = dto.RefreshToken, UserAgent = dto.UserAgent, RememberMe = dto.RememberMe, IsActive = true, ExpiresAt = DateTime.UtcNow.AddMinutes(dto.ExpirationMinutes), LastActivity = DateTime.UtcNow };
        await _repository.AddSessionAsync(session);
        return session.Id;
    }
    public async Task UpdateSession(Guid id, UpdateUserSessionDto dto) { var s = await _repository.GetSessionByIdAsync(id) ?? throw new Exception("Sesión no encontrada"); s.RefreshToken = dto.RefreshToken ?? s.RefreshToken; s.IsActive = dto.IsActive; s.LastActivity = DateTime.UtcNow; await _repository.UpdateSessionAsync(s); }
    public async Task DeleteSession(Guid id) => await _repository.DeleteSessionAsync(id);
    public async Task InvalidateUserSessions(Guid userId) => await _repository.InvalidateUserSessionsAsync(userId);
    private UserSessionResponseDto MapToResponseDto(UserSessions s) => new() { Id = s.Id, UserId = s.UserId, IpAddress = s.IpAddress?.ToString(), UserAgent = s.UserAgent, RememberMe = s.RememberMe, IsActive = s.IsActive, ExpiresAt = s.ExpiresAt, LastActivity = s.LastActivity };
}

public class RolePermissionService : IRolePermissionService
{
    private readonly IRolePermissionRepository _repository;
    public RolePermissionService(IRolePermissionRepository repository) => _repository = repository;
    public async Task<IEnumerable<RolePermissionResponseDto>> GetAllPermissions() => (await _repository.GetAllPermissionsAsync()).Select(MapToResponseDto);
    public async Task<RolePermissionResponseDto?> GetPermissionById(Guid id) { var p = await _repository.GetPermissionByIdAsync(id); return p == null ? null : MapToResponseDto(p); }
    public async Task<IEnumerable<RolePermissionResponseDto>> GetPermissionsByRoleId(Guid roleId) => (await _repository.GetPermissionsByRoleIdAsync(roleId)).Select(MapToResponseDto);
    public async Task<Guid> CreatePermission(CreateRolePermissionDto dto) { var p = new RolePermissions { Id = Guid.NewGuid(), RoleId = dto.RoleId, IsAllowed = dto.IsAllowed, CreatedAt = DateTime.UtcNow }; await _repository.AddPermissionAsync(p); return p.Id; }
    public async Task UpdatePermission(Guid id, UpdateRolePermissionDto dto) { var p = await _repository.GetPermissionByIdAsync(id) ?? throw new Exception("Permiso no encontrado"); p.IsAllowed = dto.IsAllowed; await _repository.UpdatePermissionAsync(p); }
    public async Task DeletePermission(Guid id) => await _repository.DeletePermissionAsync(id);
    private RolePermissionResponseDto MapToResponseDto(RolePermissions p) => new() { Id = p.Id, RoleId = p.RoleId, IsAllowed = p.IsAllowed, CreatedAt = p.CreatedAt };
}

public class UserPermissionService : IUserPermissionService
{
    private readonly IUserPermissionRepository _repository;
    public UserPermissionService(IUserPermissionRepository repository) => _repository = repository;
    public async Task<IEnumerable<UserPermissionResponseDto>> GetAllPermissions() => (await _repository.GetAllPermissionsAsync()).Select(MapToResponseDto);
    public async Task<UserPermissionResponseDto?> GetPermissionById(Guid id) { var p = await _repository.GetPermissionByIdAsync(id); return p == null ? null : MapToResponseDto(p); }
    public async Task<IEnumerable<UserPermissionResponseDto>> GetPermissionsByUserId(Guid userId) => (await _repository.GetPermissionsByUserIdAsync(userId)).Select(MapToResponseDto);
    public async Task<Guid> CreatePermission(CreateUserPermissionDto dto) { var p = new UserPermissions { Id = Guid.NewGuid(), UserId = dto.UserId, IsAllowed = dto.IsAllowed, CreatedAt = DateTime.UtcNow }; await _repository.AddPermissionAsync(p); return p.Id; }
    public async Task UpdatePermission(Guid id, UpdateUserPermissionDto dto) { var p = await _repository.GetPermissionByIdAsync(id) ?? throw new Exception("Permiso no encontrado"); p.IsAllowed = dto.IsAllowed; await _repository.UpdatePermissionAsync(p); }
    public async Task DeletePermission(Guid id) => await _repository.DeletePermissionAsync(id);
    private UserPermissionResponseDto MapToResponseDto(UserPermissions p) => new() { Id = p.Id, UserId = p.UserId, IsAllowed = p.IsAllowed, CreatedAt = p.CreatedAt };
}

public class UniversityReportService : IUniversityReportService
{
    private readonly IUniversityReportRepository _repository;
    public UniversityReportService(IUniversityReportRepository repository) => _repository = repository;
    public async Task<IEnumerable<UniversityReportResponseDto>> GetAllReports() => (await _repository.GetAllReportsAsync()).Select(MapToResponseDto);
    public async Task<UniversityReportResponseDto?> GetReportById(Guid id) { var r = await _repository.GetReportByIdAsync(id); return r == null ? null : MapToResponseDto(r); }
    public async Task<IEnumerable<UniversityReportResponseDto>> GetReportsByUniversityId(Guid universityId) => (await _repository.GetReportsByUniversityIdAsync(universityId)).Select(MapToResponseDto);
    public async Task<IEnumerable<UniversityReportResponseDto>> GetReportsByYear(int year) => (await _repository.GetReportsByYearAsync(year)).Select(MapToResponseDto);
    public async Task<Guid> CreateReport(CreateUniversityReportDto dto) { var r = new UniversityReports { Id = Guid.NewGuid(), UniversityId = dto.UniversityId, Year = dto.Year, Title = dto.Title, Description = dto.Description, PeriodStart = dto.PeriodStart, PeriodEnd = dto.PeriodEnd, DocumentUrl = dto.DocumentUrl, CreatedAt = DateTime.UtcNow }; await _repository.AddReportAsync(r); return r.Id; }
    public async Task UpdateReport(Guid id, UpdateUniversityReportDto dto) { var r = await _repository.GetReportByIdAsync(id) ?? throw new Exception("Reporte no encontrado"); r.Title = dto.Title ?? r.Title; r.Description = dto.Description ?? r.Description; r.DocumentUrl = dto.DocumentUrl ?? r.DocumentUrl; r.UpdatedAt = DateTime.UtcNow; await _repository.UpdateReportAsync(r); }
    public async Task DeleteReport(Guid id) => await _repository.DeleteReportAsync(id);
    private UniversityReportResponseDto MapToResponseDto(UniversityReports r) => new() { Id = r.Id, UniversityId = r.UniversityId, Year = r.Year, Title = r.Title, Description = r.Description, PeriodStart = r.PeriodStart, PeriodEnd = r.PeriodEnd, DocumentUrl = r.DocumentUrl, IsPublic = r.IsPublic, CreatedAt = r.CreatedAt };
}

public class AuditLogService : IAuditLogService
{
    private readonly IAuditLogRepository _repository;
    private readonly IAuditLogChangeRepository _changeRepository;
    public AuditLogService(IAuditLogRepository repository, IAuditLogChangeRepository changeRepository) { _repository = repository; _changeRepository = changeRepository; }
    public async Task<IEnumerable<AuditLogResponseDto>> GetAllLogs() => (await _repository.GetAllLogsAsync()).Select(MapToResponseDto);
    public async Task<AuditLogResponseDto?> GetLogById(Guid id) { var l = await _repository.GetLogByIdAsync(id); return l == null ? null : MapToResponseDto(l); }
    public async Task<IEnumerable<AuditLogResponseDto>> GetLogsByUserId(Guid userId) => (await _repository.GetLogsByUserIdAsync(userId)).Select(MapToResponseDto);
    public async Task<IEnumerable<AuditLogResponseDto>> GetLogsByEntityType(string entityType) => (await _repository.GetLogsByEntityTypeAsync(entityType)).Select(MapToResponseDto);
    public async Task<IEnumerable<AuditLogResponseDto>> GetLogsByDateRange(DateTime startDate, DateTime endDate) => (await _repository.GetLogsByDateRangeAsync(startDate, endDate)).Select(MapToResponseDto);
    public async Task<Guid> LogActionAsync(CreateAuditLogDto dto) { var l = new AuditLogs { Id = Guid.NewGuid(), UserId = dto.UserId, UserName = dto.UserName, Action = dto.Action, EntityType = dto.EntityType, EntityId = dto.EntityId, Timestamp = DateTime.UtcNow }; await _repository.AddLogAsync(l); return l.Id; }
    public async Task LogChangeAsync(Guid auditLogId, string field, string? oldValue, string? newValue) { var c = new AuditLogChanges { Id = Guid.NewGuid(), AuditLogId = auditLogId, Field = field, OldValue = oldValue, NewValue = newValue }; await _changeRepository.AddChangeAsync(c); }
    private AuditLogResponseDto MapToResponseDto(AuditLogs l) => new() { Id = l.Id, UserId = l.UserId, UserName = l.UserName, Action = l.Action, EntityType = l.EntityType, EntityId = l.EntityId, IpAddress = l.IpAddress?.ToString(), Timestamp = l.Timestamp };
}

public class AuditLogChangeService : IAuditLogChangeService
{
    private readonly IAuditLogChangeRepository _repository;
    public AuditLogChangeService(IAuditLogChangeRepository repository) => _repository = repository;
    public async Task<IEnumerable<AuditLogChangeResponseDto>> GetAllChanges() => (await _repository.GetAllChangesAsync()).Select(MapToResponseDto);
    public async Task<AuditLogChangeResponseDto?> GetChangeById(Guid id) { var c = await _repository.GetChangeByIdAsync(id); return c == null ? null : MapToResponseDto(c); }
    public async Task<IEnumerable<AuditLogChangeResponseDto>> GetChangesByAuditLogId(Guid auditLogId) => (await _repository.GetChangesByAuditLogIdAsync(auditLogId)).Select(MapToResponseDto);
    public async Task<Guid> CreateChange(CreateAuditLogChangeDto dto) { var c = new AuditLogChanges { Id = Guid.NewGuid(), AuditLogId = dto.AuditLogId, Field = dto.Field, OldValue = dto.OldValue, NewValue = dto.NewValue }; await _repository.AddChangeAsync(c); return c.Id; }
    public async Task DeleteChange(Guid id) => await _repository.DeleteChangeAsync(id);
    private AuditLogChangeResponseDto MapToResponseDto(AuditLogChanges c) => new() { Id = c.Id, AuditLogId = c.AuditLogId, Field = c.Field, OldValue = c.OldValue, NewValue = c.NewValue };
}

public class MembershipApplicationService : IMembershipApplicationService
{
    private readonly IMembershipApplicationRepository _repository;
    public MembershipApplicationService(IMembershipApplicationRepository repository) => _repository = repository;
    public async Task<IEnumerable<MembershipApplicationResponseDto>> GetAllApplications() => (await _repository.GetAllApplicationsAsync()).Select(MapToResponseDto);
    public async Task<MembershipApplicationResponseDto?> GetApplicationById(Guid id) { var a = await _repository.GetApplicationByIdAsync(id); return a == null ? null : MapToResponseDto(a); }
    public async Task<IEnumerable<MembershipApplicationResponseDto>> GetApplicationsByUniversityId(Guid universityId) => (await _repository.GetApplicationsByUniversityIdAsync(universityId)).Select(MapToResponseDto);
    public async Task<IEnumerable<MembershipApplicationResponseDto>> GetPendingApplications() => (await _repository.GetPendingApplicationsAsync()).Select(MapToResponseDto);
    public async Task<Guid> CreateApplication(CreateMembershipApplicationDto dto) { var a = new MembershipApplications { Id = Guid.NewGuid(), ApplicationNumber = await _repository.GenerateApplicationNumberAsync(), UniversityId = dto.UniversityId, UniversityName = dto.UniversityName, ApplicantName = dto.ApplicantName, ApplicantEmail = dto.ApplicantEmail, ApplicantPhone = dto.ApplicantPhone, ApplicationDate = dto.ApplicationDate, ContactName = dto.ContactName, ContactPosition = dto.ContactPosition, ContactEmail = dto.ContactEmail, ContactPhone = dto.ContactPhone, AssignedTo = dto.AssignedTo, SubmittedAt = DateTime.UtcNow }; await _repository.AddApplicationAsync(a); return a.Id; }
    public async Task UpdateApplication(Guid id, UpdateMembershipApplicationDto dto) { var a = await _repository.GetApplicationByIdAsync(id) ?? throw new Exception("Solicitud no encontrada"); a.UniversityName = dto.UniversityName ?? a.UniversityName; a.ApplicantName = dto.ApplicantName ?? a.ApplicantName; a.AssignedTo = dto.AssignedTo ?? a.AssignedTo; a.ReviewStartedAt = DateTime.UtcNow; await _repository.UpdateApplicationAsync(a); }
    public async Task DeleteApplication(Guid id) => await _repository.DeleteApplicationAsync(id);
    public async Task<string> GenerateApplicationNumberAsync() => await _repository.GenerateApplicationNumberAsync();
    private MembershipApplicationResponseDto MapToResponseDto(MembershipApplications a) => new() { Id = a.Id, ApplicationNumber = a.ApplicationNumber, UniversityId = a.UniversityId, UniversityName = a.UniversityName, ApplicantName = a.ApplicantName, ApplicantEmail = a.ApplicantEmail, ApplicantPhone = a.ApplicantPhone, ApplicationDate = a.ApplicationDate, ContactName = a.ContactName, ContactPosition = a.ContactPosition, ContactEmail = a.ContactEmail, ContactPhone = a.ContactPhone, AssignedTo = a.AssignedTo };
}
