using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Domain.Models;
using CMS_Riesgird.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CMS_Riesgird.Core.Infrastructure.Repositories;

public class UserSessionRepository : IUserSessionRepository
{
    private readonly RiesgirdDbContext _context;
    public UserSessionRepository(RiesgirdDbContext context) => _context = context;
    public async Task<IEnumerable<UserSessions>> GetAllSessionsAsync() => await _context.UserSessions.OrderByDescending(s => s.LastActivity).ToListAsync();
    public async Task<UserSessions?> GetSessionByIdAsync(Guid id) => await _context.UserSessions.FirstOrDefaultAsync(s => s.Id == id);
    public async Task<IEnumerable<UserSessions>> GetActiveSessionsByUserIdAsync(Guid userId) => await _context.UserSessions.Where(s => s.UserId == userId && s.IsActive).ToListAsync();
    public async Task<UserSessions?> GetSessionByTokenAsync(string tokenHash) => await _context.UserSessions.FirstOrDefaultAsync(s => s.TokenHash == tokenHash);
    public async Task<IEnumerable<UserSessions>> GetExpiredSessionsAsync() { var now = DateTime.UtcNow; return await _context.UserSessions.Where(s => s.ExpiresAt < now).ToListAsync(); }
    public async Task AddSessionAsync(UserSessions session) { _context.UserSessions.Add(session); await _context.SaveChangesAsync(); }
    public async Task UpdateSessionAsync(UserSessions session) { _context.UserSessions.Update(session); await _context.SaveChangesAsync(); }
    public async Task DeleteSessionAsync(Guid id) { var s = await _context.UserSessions.FindAsync(id); if (s != null) { _context.UserSessions.Remove(s); await _context.SaveChangesAsync(); } }
    public async Task InvalidateUserSessionsAsync(Guid userId) { var sessions = await _context.UserSessions.Where(s => s.UserId == userId && s.IsActive).ToListAsync(); foreach (var session in sessions) session.IsActive = false; _context.UserSessions.UpdateRange(sessions); await _context.SaveChangesAsync(); }
}

public class RolePermissionRepository : IRolePermissionRepository
{
    private readonly RiesgirdDbContext _context;
    public RolePermissionRepository(RiesgirdDbContext context) => _context = context;
    public async Task<IEnumerable<RolePermissions>> GetAllPermissionsAsync() => await _context.RolePermissions.Include(p => p.Role).ToListAsync();
    public async Task<RolePermissions?> GetPermissionByIdAsync(Guid id) => await _context.RolePermissions.Include(p => p.Role).FirstOrDefaultAsync(p => p.Id == id);
    public async Task<IEnumerable<RolePermissions>> GetPermissionsByRoleIdAsync(Guid roleId) => await _context.RolePermissions.Where(p => p.RoleId == roleId).ToListAsync();
    public async Task AddPermissionAsync(RolePermissions permission) { _context.RolePermissions.Add(permission); await _context.SaveChangesAsync(); }
    public async Task UpdatePermissionAsync(RolePermissions permission) { _context.RolePermissions.Update(permission); await _context.SaveChangesAsync(); }
    public async Task DeletePermissionAsync(Guid id) { var p = await _context.RolePermissions.FindAsync(id); if (p != null) { _context.RolePermissions.Remove(p); await _context.SaveChangesAsync(); } }
}

public class UserPermissionRepository : IUserPermissionRepository
{
    private readonly RiesgirdDbContext _context;
    public UserPermissionRepository(RiesgirdDbContext context) => _context = context;
    public async Task<IEnumerable<UserPermissions>> GetAllPermissionsAsync() => await _context.UserPermissions.Include(p => p.User).ToListAsync();
    public async Task<UserPermissions?> GetPermissionByIdAsync(Guid id) => await _context.UserPermissions.Include(p => p.User).FirstOrDefaultAsync(p => p.Id == id);
    public async Task<IEnumerable<UserPermissions>> GetPermissionsByUserIdAsync(Guid userId) => await _context.UserPermissions.Where(p => p.UserId == userId).ToListAsync();
    public async Task AddPermissionAsync(UserPermissions permission) { _context.UserPermissions.Add(permission); await _context.SaveChangesAsync(); }
    public async Task UpdatePermissionAsync(UserPermissions permission) { _context.UserPermissions.Update(permission); await _context.SaveChangesAsync(); }
    public async Task DeletePermissionAsync(Guid id) { var p = await _context.UserPermissions.FindAsync(id); if (p != null) { _context.UserPermissions.Remove(p); await _context.SaveChangesAsync(); } }
}

public class UniversityReportRepository : IUniversityReportRepository
{
    private readonly RiesgirdDbContext _context;
    public UniversityReportRepository(RiesgirdDbContext context) => _context = context;
    public async Task<IEnumerable<UniversityReports>> GetAllReportsAsync() => await _context.UniversityReports.OrderByDescending(r => r.Year).ToListAsync();
    public async Task<UniversityReports?> GetReportByIdAsync(Guid id) => await _context.UniversityReports.FirstOrDefaultAsync(r => r.Id == id);
    public async Task<IEnumerable<UniversityReports>> GetReportsByUniversityIdAsync(Guid universityId) => await _context.UniversityReports.Where(r => r.UniversityId == universityId).OrderByDescending(r => r.Year).ToListAsync();
    public async Task<IEnumerable<UniversityReports>> GetReportsByYearAsync(int year) => await _context.UniversityReports.Where(r => r.Year == year).ToListAsync();
    public async Task AddReportAsync(UniversityReports report) { _context.UniversityReports.Add(report); await _context.SaveChangesAsync(); }
    public async Task UpdateReportAsync(UniversityReports report) { _context.UniversityReports.Update(report); await _context.SaveChangesAsync(); }
    public async Task DeleteReportAsync(Guid id) { var r = await _context.UniversityReports.FindAsync(id); if (r != null) { _context.UniversityReports.Remove(r); await _context.SaveChangesAsync(); } }
}

public class AuditLogRepository : IAuditLogRepository
{
    private readonly RiesgirdDbContext _context;
    public AuditLogRepository(RiesgirdDbContext context) => _context = context;
    public async Task<IEnumerable<AuditLogs>> GetAllLogsAsync() => await _context.AuditLogs.OrderByDescending(l => l.Timestamp).ToListAsync();
    public async Task<AuditLogs?> GetLogByIdAsync(Guid id) => await _context.AuditLogs.FirstOrDefaultAsync(l => l.Id == id);
    public async Task<IEnumerable<AuditLogs>> GetLogsByUserIdAsync(Guid userId) => await _context.AuditLogs.Where(l => l.UserId == userId).OrderByDescending(l => l.Timestamp).ToListAsync();
    public async Task<IEnumerable<AuditLogs>> GetLogsByEntityTypeAsync(string entityType) => await _context.AuditLogs.Where(l => l.EntityType == entityType).OrderByDescending(l => l.Timestamp).ToListAsync();
    public async Task<IEnumerable<AuditLogs>> GetLogsByDateRangeAsync(DateTime startDate, DateTime endDate) => await _context.AuditLogs.Where(l => l.Timestamp >= startDate && l.Timestamp <= endDate).OrderByDescending(l => l.Timestamp).ToListAsync();
    public async Task AddLogAsync(AuditLogs log) { _context.AuditLogs.Add(log); await _context.SaveChangesAsync(); }
}

public class AuditLogChangeRepository : IAuditLogChangeRepository
{
    private readonly RiesgirdDbContext _context;
    public AuditLogChangeRepository(RiesgirdDbContext context) => _context = context;
    public async Task<IEnumerable<AuditLogChanges>> GetAllChangesAsync() => await _context.AuditLogChanges.ToListAsync();
    public async Task<AuditLogChanges?> GetChangeByIdAsync(Guid id) => await _context.AuditLogChanges.FirstOrDefaultAsync(c => c.Id == id);
    public async Task<IEnumerable<AuditLogChanges>> GetChangesByAuditLogIdAsync(Guid auditLogId) => await _context.AuditLogChanges.Where(c => c.AuditLogId == auditLogId).ToListAsync();
    public async Task AddChangeAsync(AuditLogChanges change) { _context.AuditLogChanges.Add(change); await _context.SaveChangesAsync(); }
    public async Task UpdateChangeAsync(AuditLogChanges change) { _context.AuditLogChanges.Update(change); await _context.SaveChangesAsync(); }
    public async Task DeleteChangeAsync(Guid id) { var c = await _context.AuditLogChanges.FindAsync(id); if (c != null) { _context.AuditLogChanges.Remove(c); await _context.SaveChangesAsync(); } }
}

public class MembershipApplicationRepository : IMembershipApplicationRepository
{
    private readonly RiesgirdDbContext _context;
    public MembershipApplicationRepository(RiesgirdDbContext context) => _context = context;
    public async Task<IEnumerable<MembershipApplications>> GetAllApplicationsAsync() => await _context.MembershipApplications.OrderByDescending(a => a.ApplicationDate).ToListAsync();
    public async Task<MembershipApplications?> GetApplicationByIdAsync(Guid id) => await _context.MembershipApplications.FirstOrDefaultAsync(a => a.Id == id);
    public async Task<IEnumerable<MembershipApplications>> GetApplicationsByUniversityIdAsync(Guid universityId) => await _context.MembershipApplications.Where(a => a.UniversityId == universityId).ToListAsync();
    public async Task<IEnumerable<MembershipApplications>> GetApplicationsAssignedToAsync(Guid userId) => await _context.MembershipApplications.Where(a => a.AssignedTo == userId).ToListAsync();
    public async Task<IEnumerable<MembershipApplications>> GetPendingApplicationsAsync() => await _context.MembershipApplications.Where(a => a.ReviewStartedAt == null).OrderByDescending(a => a.ApplicationDate).ToListAsync();
    public async Task AddApplicationAsync(MembershipApplications application) { _context.MembershipApplications.Add(application); await _context.SaveChangesAsync(); }
    public async Task UpdateApplicationAsync(MembershipApplications application) { _context.MembershipApplications.Update(application); await _context.SaveChangesAsync(); }
    public async Task DeleteApplicationAsync(Guid id) { var a = await _context.MembershipApplications.FindAsync(id); if (a != null) { _context.MembershipApplications.Remove(a); await _context.SaveChangesAsync(); } }
    public async Task<string> GenerateApplicationNumberAsync() { var count = await _context.MembershipApplications.CountAsync(); var year = DateTime.Now.Year; return $"APP-{year}-{(count + 1).ToString("D4")}"; }
}
