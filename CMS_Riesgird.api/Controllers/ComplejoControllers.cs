using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CMS_Riesgird.api.Controllers;

[Route("api/v1/user-sessions"), ApiController]
public class UserSessionController : ControllerBase
{
    private readonly IUserSessionService _service;
    public UserSessionController(IUserSessionService service) => _service = service;
    [HttpGet] public async Task<IActionResult> GetAll() => Ok(new ApiResponse<IEnumerable<UserSessionResponseDto>>(await _service.GetAllSessions(), true, "Lista de sesiones."));
    [HttpGet("user/{userId}")] public async Task<IActionResult> GetByUserId(Guid userId) => Ok(new ApiResponse<IEnumerable<UserSessionResponseDto>>(await _service.GetActiveSessionsByUserId(userId), true, "Sesiones activas del usuario."));
    [HttpGet("{id}")] public async Task<IActionResult> GetById(Guid id) { var s = await _service.GetSessionById(id); return s == null ? NotFound(new ApiResponse<object>(false, "Sesión no encontrada.")) : Ok(new ApiResponse<UserSessionResponseDto>(s, true, "Sesión encontrada.")); }
    [HttpPost] public async Task<IActionResult> Create([FromBody] CreateUserSessionDto dto) { try { var id = await _service.CreateSession(dto); return Ok(new ApiResponse<object>(new { SessionId = id }, true, "Sesión creada.")); } catch (Exception ex) { return BadRequest(new ApiResponse<object>(false, ex.Message)); } }
    [HttpPatch("{id}")] public async Task<IActionResult> Update(Guid id, [FromBody] UpdateUserSessionDto dto) { try { await _service.UpdateSession(id, dto); return Ok(new ApiResponse<object>(true, "Sesión actualizada.")); } catch (Exception ex) { return BadRequest(new ApiResponse<object>(false, ex.Message)); } }
    [HttpDelete("{id}")] public async Task<IActionResult> Delete(Guid id) { try { await _service.DeleteSession(id); return Ok(new ApiResponse<object>(true, "Sesión eliminada.")); } catch (Exception ex) { return BadRequest(new ApiResponse<object>(false, ex.Message)); } }
    [HttpPost("{userId}/invalidate")] public async Task<IActionResult> InvalidateUserSessions(Guid userId) { try { await _service.InvalidateUserSessions(userId); return Ok(new ApiResponse<object>(true, "Sesiones invalidadas.")); } catch (Exception ex) { return BadRequest(new ApiResponse<object>(false, ex.Message)); } }
}

[Route("api/v1/role-permissions"), ApiController]
public class RolePermissionController : ControllerBase
{
    private readonly IRolePermissionService _service;
    public RolePermissionController(IRolePermissionService service) => _service = service;
    [HttpGet] public async Task<IActionResult> GetAll() => Ok(new ApiResponse<IEnumerable<RolePermissionResponseDto>>(await _service.GetAllPermissions(), true, "Lista de permisos."));
    [HttpGet("role/{roleId}")] public async Task<IActionResult> GetByRoleId(Guid roleId) => Ok(new ApiResponse<IEnumerable<RolePermissionResponseDto>>(await _service.GetPermissionsByRoleId(roleId), true, "Permisos del rol."));
    [HttpGet("{id}")] public async Task<IActionResult> GetById(Guid id) { var p = await _service.GetPermissionById(id); return p == null ? NotFound(new ApiResponse<object>(false, "Permiso no encontrado.")) : Ok(new ApiResponse<RolePermissionResponseDto>(p, true, "Permiso encontrado.")); }
    [HttpPost] public async Task<IActionResult> Create([FromBody] CreateRolePermissionDto dto) { try { var id = await _service.CreatePermission(dto); return Ok(new ApiResponse<object>(new { PermissionId = id }, true, "Permiso creado.")); } catch (Exception ex) { return BadRequest(new ApiResponse<object>(false, ex.Message)); } }
    [HttpPatch("{id}")] public async Task<IActionResult> Update(Guid id, [FromBody] UpdateRolePermissionDto dto) { try { await _service.UpdatePermission(id, dto); return Ok(new ApiResponse<object>(true, "Permiso actualizado.")); } catch (Exception ex) { return BadRequest(new ApiResponse<object>(false, ex.Message)); } }
    [HttpDelete("{id}")] public async Task<IActionResult> Delete(Guid id) { try { await _service.DeletePermission(id); return Ok(new ApiResponse<object>(true, "Permiso eliminado.")); } catch (Exception ex) { return BadRequest(new ApiResponse<object>(false, ex.Message)); } }
}

[Route("api/v1/user-permissions"), ApiController]
public class UserPermissionController : ControllerBase
{
    private readonly IUserPermissionService _service;
    public UserPermissionController(IUserPermissionService service) => _service = service;
    [HttpGet] public async Task<IActionResult> GetAll() => Ok(new ApiResponse<IEnumerable<UserPermissionResponseDto>>(await _service.GetAllPermissions(), true, "Lista de permisos."));
    [HttpGet("user/{userId}")] public async Task<IActionResult> GetByUserId(Guid userId) => Ok(new ApiResponse<IEnumerable<UserPermissionResponseDto>>(await _service.GetPermissionsByUserId(userId), true, "Permisos del usuario."));
    [HttpGet("{id}")] public async Task<IActionResult> GetById(Guid id) { var p = await _service.GetPermissionById(id); return p == null ? NotFound(new ApiResponse<object>(false, "Permiso no encontrado.")) : Ok(new ApiResponse<UserPermissionResponseDto>(p, true, "Permiso encontrado.")); }
    [HttpPost] public async Task<IActionResult> Create([FromBody] CreateUserPermissionDto dto) { try { var id = await _service.CreatePermission(dto); return Ok(new ApiResponse<object>(new { PermissionId = id }, true, "Permiso creado.")); } catch (Exception ex) { return BadRequest(new ApiResponse<object>(false, ex.Message)); } }
    [HttpPatch("{id}")] public async Task<IActionResult> Update(Guid id, [FromBody] UpdateUserPermissionDto dto) { try { await _service.UpdatePermission(id, dto); return Ok(new ApiResponse<object>(true, "Permiso actualizado.")); } catch (Exception ex) { return BadRequest(new ApiResponse<object>(false, ex.Message)); } }
    [HttpDelete("{id}")] public async Task<IActionResult> Delete(Guid id) { try { await _service.DeletePermission(id); return Ok(new ApiResponse<object>(true, "Permiso eliminado.")); } catch (Exception ex) { return BadRequest(new ApiResponse<object>(false, ex.Message)); } }
}

[Route("api/v1/university-reports"), ApiController]
public class UniversityReportController : ControllerBase
{
    private readonly IUniversityReportService _service;
    public UniversityReportController(IUniversityReportService service) => _service = service;
    [HttpGet] public async Task<IActionResult> GetAll() => Ok(new ApiResponse<IEnumerable<UniversityReportResponseDto>>(await _service.GetAllReports(), true, "Lista de reportes."));
    [HttpGet("university/{universityId}")] public async Task<IActionResult> GetByUniversityId(Guid universityId) => Ok(new ApiResponse<IEnumerable<UniversityReportResponseDto>>(await _service.GetReportsByUniversityId(universityId), true, "Reportes de la universidad."));
    [HttpGet("year/{year}")] public async Task<IActionResult> GetByYear(int year) => Ok(new ApiResponse<IEnumerable<UniversityReportResponseDto>>(await _service.GetReportsByYear(year), true, $"Reportes del año {year}."));
    [HttpGet("{id}")] public async Task<IActionResult> GetById(Guid id) { var r = await _service.GetReportById(id); return r == null ? NotFound(new ApiResponse<object>(false, "Reporte no encontrado.")) : Ok(new ApiResponse<UniversityReportResponseDto>(r, true, "Reporte encontrado.")); }
    [HttpPost] public async Task<IActionResult> Create([FromBody] CreateUniversityReportDto dto) { try { var id = await _service.CreateReport(dto); return Ok(new ApiResponse<object>(new { ReportId = id }, true, "Reporte creado.")); } catch (Exception ex) { return BadRequest(new ApiResponse<object>(false, ex.Message)); } }
    [HttpPatch("{id}")] public async Task<IActionResult> Update(Guid id, [FromBody] UpdateUniversityReportDto dto) { try { await _service.UpdateReport(id, dto); return Ok(new ApiResponse<object>(true, "Reporte actualizado.")); } catch (Exception ex) { return BadRequest(new ApiResponse<object>(false, ex.Message)); } }
    [HttpDelete("{id}")] public async Task<IActionResult> Delete(Guid id) { try { await _service.DeleteReport(id); return Ok(new ApiResponse<object>(true, "Reporte eliminado.")); } catch (Exception ex) { return BadRequest(new ApiResponse<object>(false, ex.Message)); } }
}

[Route("api/v1/audit-logs"), ApiController]
public class AuditLogController : ControllerBase
{
    private readonly IAuditLogService _service;
    public AuditLogController(IAuditLogService service) => _service = service;
    [HttpGet] public async Task<IActionResult> GetAll() => Ok(new ApiResponse<IEnumerable<AuditLogResponseDto>>(await _service.GetAllLogs(), true, "Lista de auditoría."));
    [HttpGet("user/{userId}")] public async Task<IActionResult> GetByUserId(Guid userId) => Ok(new ApiResponse<IEnumerable<AuditLogResponseDto>>(await _service.GetLogsByUserId(userId), true, "Auditoría del usuario."));
    [HttpGet("entity/{entityType}")] public async Task<IActionResult> GetByEntityType(string entityType) => Ok(new ApiResponse<IEnumerable<AuditLogResponseDto>>(await _service.GetLogsByEntityType(entityType), true, $"Auditoría de {entityType}."));
    [HttpGet("date-range")] public async Task<IActionResult> GetByDateRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate) => Ok(new ApiResponse<IEnumerable<AuditLogResponseDto>>(await _service.GetLogsByDateRange(startDate, endDate), true, "Auditoría por rango de fechas."));
    [HttpGet("{id}")] public async Task<IActionResult> GetById(Guid id) { var l = await _service.GetLogById(id); return l == null ? NotFound(new ApiResponse<object>(false, "Auditoría no encontrada.")) : Ok(new ApiResponse<AuditLogResponseDto>(l, true, "Auditoría encontrada.")); }
    [HttpPost] public async Task<IActionResult> Create([FromBody] CreateAuditLogDto dto) { try { var id = await _service.LogActionAsync(dto); return Ok(new ApiResponse<object>(new { LogId = id }, true, "Auditoría registrada.")); } catch (Exception ex) { return BadRequest(new ApiResponse<object>(false, ex.Message)); } }
}

[Route("api/v1/audit-log-changes"), ApiController]
public class AuditLogChangeController : ControllerBase
{
    private readonly IAuditLogChangeService _service;
    public AuditLogChangeController(IAuditLogChangeService service) => _service = service;
    [HttpGet] public async Task<IActionResult> GetAll() => Ok(new ApiResponse<IEnumerable<AuditLogChangeResponseDto>>(await _service.GetAllChanges(), true, "Lista de cambios auditados."));
    [HttpGet("audit-log/{auditLogId}")] public async Task<IActionResult> GetByAuditLogId(Guid auditLogId) => Ok(new ApiResponse<IEnumerable<AuditLogChangeResponseDto>>(await _service.GetChangesByAuditLogId(auditLogId), true, "Cambios del registro."));
    [HttpGet("{id}")] public async Task<IActionResult> GetById(Guid id) { var c = await _service.GetChangeById(id); return c == null ? NotFound(new ApiResponse<object>(false, "Cambio no encontrado.")) : Ok(new ApiResponse<AuditLogChangeResponseDto>(c, true, "Cambio encontrado.")); }
    [HttpPost] public async Task<IActionResult> Create([FromBody] CreateAuditLogChangeDto dto) { try { var id = await _service.CreateChange(dto); return Ok(new ApiResponse<object>(new { ChangeId = id }, true, "Cambio registrado.")); } catch (Exception ex) { return BadRequest(new ApiResponse<object>(false, ex.Message)); } }
    [HttpDelete("{id}")] public async Task<IActionResult> Delete(Guid id) { try { await _service.DeleteChange(id); return Ok(new ApiResponse<object>(true, "Cambio eliminado.")); } catch (Exception ex) { return BadRequest(new ApiResponse<object>(false, ex.Message)); } }
}

[Route("api/v1/membership-applications"), ApiController]
public class MembershipApplicationController : ControllerBase
{
    private readonly IMembershipApplicationService _service;
    public MembershipApplicationController(IMembershipApplicationService service) => _service = service;
    [HttpGet] public async Task<IActionResult> GetAll() => Ok(new ApiResponse<IEnumerable<MembershipApplicationResponseDto>>(await _service.GetAllApplications(), true, "Lista de solicitudes."));
    [HttpGet("pending")] public async Task<IActionResult> GetPending() => Ok(new ApiResponse<IEnumerable<MembershipApplicationResponseDto>>(await _service.GetPendingApplications(), true, "Solicitudes pendientes."));
    [HttpGet("university/{universityId}")] public async Task<IActionResult> GetByUniversityId(Guid universityId) => Ok(new ApiResponse<IEnumerable<MembershipApplicationResponseDto>>(await _service.GetApplicationsByUniversityId(universityId), true, "Solicitudes de la universidad."));
    [HttpGet("{id}")] public async Task<IActionResult> GetById(Guid id) { var a = await _service.GetApplicationById(id); return a == null ? NotFound(new ApiResponse<object>(false, "Solicitud no encontrada.")) : Ok(new ApiResponse<MembershipApplicationResponseDto>(a, true, "Solicitud encontrada.")); }
    [HttpPost] public async Task<IActionResult> Create([FromBody] CreateMembershipApplicationDto dto) { try { var id = await _service.CreateApplication(dto); return Ok(new ApiResponse<object>(new { ApplicationId = id }, true, "Solicitud creada.")); } catch (Exception ex) { return BadRequest(new ApiResponse<object>(false, ex.Message)); } }
    [HttpPatch("{id}")] public async Task<IActionResult> Update(Guid id, [FromBody] UpdateMembershipApplicationDto dto) { try { await _service.UpdateApplication(id, dto); return Ok(new ApiResponse<object>(true, "Solicitud actualizada.")); } catch (Exception ex) { return BadRequest(new ApiResponse<object>(false, ex.Message)); } }
    [HttpDelete("{id}")] public async Task<IActionResult> Delete(Guid id) { try { await _service.DeleteApplication(id); return Ok(new ApiResponse<object>(true, "Solicitud eliminada.")); } catch (Exception ex) { return BadRequest(new ApiResponse<object>(false, ex.Message)); } }
}
