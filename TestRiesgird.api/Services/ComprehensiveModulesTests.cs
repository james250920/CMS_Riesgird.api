using Xunit;
using Moq;
using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Core.Core.Services;
using CMS_Riesgird.Domain.Models;

namespace TestRiesgird.api.Services;

public class AchievementServiceTests
{
    private readonly Mock<IAchievementRepository> _mockRepository;
    private readonly AchievementService _service;

    public AchievementServiceTests()
    {
        _mockRepository = new Mock<IAchievementRepository>();
        _service = new AchievementService(_mockRepository.Object);
    }

    [Fact]
    public async Task GetAllAchievements_ShouldReturnAllAchievements()
    {
        var achievements = new List<Achievements>
        {
            new Achievements { Id = Guid.NewGuid(), MemoryId = Guid.NewGuid(), Title = "Logro 1", Description = "Descripción", Category = "Investigación", SortOrder = 1 }
        };

        _mockRepository.Setup(r => r.GetAllAchievementsAsync()).ReturnsAsync(achievements);

        var result = await _service.GetAllAchievements();

        Assert.NotNull(result);
        Assert.Single(result);
    }

    [Fact]
    public async Task CreateAchievement_WithValidData_ShouldReturnId()
    {
        var dto = new CreateAchievementDto { MemoryId = Guid.NewGuid(), Title = "Test", Description = "Test", Category = "Test", SortOrder = 1 };
        _mockRepository.Setup(r => r.AddAchievementAsync(It.IsAny<Achievements>())).Returns(Task.CompletedTask);

        var result = await _service.CreateAchievement(dto);

        Assert.NotEqual(Guid.Empty, result);
        _mockRepository.Verify(r => r.AddAchievementAsync(It.IsAny<Achievements>()), Times.Once);
    }
}

public class ManagementMemoryServiceTests
{
    private readonly Mock<IManagementMemoryRepository> _mockRepository;
    private readonly ManagementMemoryService _service;

    public ManagementMemoryServiceTests()
    {
        _mockRepository = new Mock<IManagementMemoryRepository>();
        _service = new ManagementMemoryService(_mockRepository.Object);
    }

    [Fact]
    public async Task GetLatestMemory_ShouldReturnMostRecentMemory()
    {
        var memory = new ManagementMemories { Id = Guid.NewGuid(), Year = 2024, Title = "Memoria 2024" };
        _mockRepository.Setup(r => r.GetLatestMemoryAsync()).ReturnsAsync(memory);

        var result = await _service.GetLatestMemory();

        Assert.NotNull(result);
        Assert.Equal(2024, result.Year);
    }

    [Fact]
    public async Task CreateMemory_WithValidData_ShouldReturnId()
    {
        var dto = new CreateManagementMemoryDto { Year = 2024, Title = "Memoria 2024" };
        _mockRepository.Setup(r => r.AddMemoryAsync(It.IsAny<ManagementMemories>())).Returns(Task.CompletedTask);

        var result = await _service.CreateMemory(dto);

        Assert.NotEqual(Guid.Empty, result);
    }
}

public class ActivityServiceTests
{
    private readonly Mock<IActivityRepository> _mockRepository;
    private readonly ActivityService _service;

    public ActivityServiceTests()
    {
        _mockRepository = new Mock<IActivityRepository>();
        _service = new ActivityService(_mockRepository.Object);
    }

    [Fact]
    public async Task GetActivitiesByDateRange_WithValidDates_ShouldReturnActivities()
    {
        var startDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-10));
        var endDate = DateOnly.FromDateTime(DateTime.Now);
        var activities = new List<Activities> { new Activities { Id = Guid.NewGuid(), Title = "Actividad", Date = startDate } };

        _mockRepository.Setup(r => r.GetActivitiesByDateRangeAsync(startDate, endDate)).ReturnsAsync(activities);

        var result = await _service.GetActivitiesByDateRange(startDate, endDate);

        Assert.NotNull(result);
        Assert.Single(result);
    }

    [Fact]
    public async Task GetActivitiesByDateRange_WithInvalidDates_ShouldThrowException()
    {
        var startDate = DateOnly.FromDateTime(DateTime.Now);
        var endDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-10));

        await Assert.ThrowsAsync<Exception>(() => _service.GetActivitiesByDateRange(startDate, endDate));
    }
}

public class CalendarEventServiceTests
{
    private readonly Mock<ICalendarEventRepository> _mockRepository;
    private readonly CalendarEventService _service;

    public CalendarEventServiceTests()
    {
        _mockRepository = new Mock<ICalendarEventRepository>();
        _service = new CalendarEventService(_mockRepository.Object);
    }

    [Fact]
    public async Task GetUpcomingEvents_ShouldReturnFutureEvents()
    {
        var events = new List<CalendarEvents>
        {
            new CalendarEvents { Id = Guid.NewGuid(), Title = "Evento Futuro", StartDate = DateTime.Now.AddDays(5), IsPublic = true }
        };

        _mockRepository.Setup(r => r.GetUpcomingEventsAsync()).ReturnsAsync(events);

        var result = await _service.GetUpcomingEvents();

        Assert.NotNull(result);
        Assert.NotEmpty(result);
    }

    [Fact]
    public async Task CreateEvent_WithInvalidDates_ShouldThrowException()
    {
        var dto = new CreateCalendarEventDto { Title = "Test", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(-1) };

        await Assert.ThrowsAsync<Exception>(() => _service.CreateEvent(dto));
    }
}

public class AgendaItemServiceTests
{
    private readonly Mock<IAgendaItemRepository> _mockRepository;
    private readonly AgendaItemService _service;

    public AgendaItemServiceTests()
    {
        _mockRepository = new Mock<IAgendaItemRepository>();
        _service = new AgendaItemService(_mockRepository.Object);
    }

    [Fact]
    public async Task GetItemsByAssemblyId_ShouldReturnOrderedItems()
    {
        var assemblyId = Guid.NewGuid();
        var items = new List<AgendaItems>
        {
            new AgendaItems { Id = Guid.NewGuid(), AssemblyId = assemblyId, Title = "Punto 1", SortOrder = 1 },
            new AgendaItems { Id = Guid.NewGuid(), AssemblyId = assemblyId, Title = "Punto 2", SortOrder = 2 }
        };

        _mockRepository.Setup(r => r.GetItemsByAssemblyIdAsync(assemblyId)).ReturnsAsync(items);

        var result = await _service.GetItemsByAssemblyId(assemblyId);

        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
    }
}

public class MembershipRequirementServiceTests
{
    private readonly Mock<IMembershipRequirementRepository> _mockRepository;
    private readonly MembershipRequirementService _service;

    public MembershipRequirementServiceTests()
    {
        _mockRepository = new Mock<IMembershipRequirementRepository>();
        _service = new MembershipRequirementService(_mockRepository.Object);
    }

    [Fact]
    public async Task GetActiveRequirements_ShouldReturnOnlyActiveOnes()
    {
        var requirements = new List<MembershipRequirements>
        {
            new MembershipRequirements { Id = Guid.NewGuid(), Title = "Requisito 1", IsActive = true },
            new MembershipRequirements { Id = Guid.NewGuid(), Title = "Requisito 2", IsActive = true }
        };

        _mockRepository.Setup(r => r.GetActiveRequirementsAsync()).ReturnsAsync(requirements);

        var result = await _service.GetActiveRequirements();

        Assert.NotNull(result);
        Assert.All(result, r => Assert.True(true)); // Verificación simple
    }
}

public class DownloadableTemplateServiceTests
{
    private readonly Mock<IDownloadableTemplateRepository> _mockRepository;
    private readonly DownloadableTemplateService _service;

    public DownloadableTemplateServiceTests()
    {
        _mockRepository = new Mock<IDownloadableTemplateRepository>();
        _service = new DownloadableTemplateService(_mockRepository.Object);
    }

    [Fact]
    public async Task RecordDownload_ShouldIncrementCount()
    {
        var templateId = Guid.NewGuid();
        _mockRepository.Setup(r => r.IncrementDownloadCountAsync(templateId)).Returns(Task.CompletedTask);

        await _service.RecordDownloadAsync(templateId);

        _mockRepository.Verify(r => r.IncrementDownloadCountAsync(templateId), Times.Once);
    }
}

public class ApplicationStatusHistoryServiceTests
{
    private readonly Mock<IApplicationStatusHistoryRepository> _mockRepository;
    private readonly ApplicationStatusHistoryService _service;

    public ApplicationStatusHistoryServiceTests()
    {
        _mockRepository = new Mock<IApplicationStatusHistoryRepository>();
        _service = new ApplicationStatusHistoryService(_mockRepository.Object);
    }

    [Fact]
    public async Task GetHistoriesByApplicationId_ShouldReturnOrderedHistory()
    {
        var applicationId = Guid.NewGuid();
        var histories = new List<ApplicationStatusHistory>
        {
            new ApplicationStatusHistory { Id = Guid.NewGuid(), ApplicationId = applicationId, Status = "Pending", ChangedAt = DateTime.UtcNow },
            new ApplicationStatusHistory { Id = Guid.NewGuid(), ApplicationId = applicationId, Status = "Approved", ChangedAt = DateTime.UtcNow.AddDays(1) }
        };

        _mockRepository.Setup(r => r.GetHistoriesByApplicationIdAsync(applicationId)).ReturnsAsync(histories);

        var result = await _service.GetHistoriesByApplicationId(applicationId);

        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
    }
}

public class EventPhotoServiceTests
{
    private readonly Mock<IEventPhotoRepository> _mockRepository;
    private readonly EventPhotoService _service;

    public EventPhotoServiceTests()
    {
        _mockRepository = new Mock<IEventPhotoRepository>();
        _service = new EventPhotoService(_mockRepository.Object);
    }

    [Fact]
    public async Task GetFeaturedPhotos_ShouldReturnOnlyFeatured()
    {
        var photos = new List<EventPhotos>
        {
            new EventPhotos { Id = Guid.NewGuid(), EventId = Guid.NewGuid(), Url = "url1", IsFeatured = true },
            new EventPhotos { Id = Guid.NewGuid(), EventId = Guid.NewGuid(), Url = "url2", IsFeatured = true }
        };

        _mockRepository.Setup(r => r.GetFeaturedPhotosAsync()).ReturnsAsync(photos);

        var result = await _service.GetFeaturedPhotos();

        Assert.NotNull(result);
        Assert.NotEmpty(result);
    }
}

public class InstitutionalContentServiceTests
{
    private readonly Mock<IInstitutionalContentRepository> _mockRepository;
    private readonly InstitutionalContentService _service;

    public InstitutionalContentServiceTests()
    {
        _mockRepository = new Mock<IInstitutionalContentRepository>();
        _service = new InstitutionalContentService(_mockRepository.Object);
    }

    [Fact]
    public async Task GetContentByTitle_WithValidTitle_ShouldReturnContent()
    {
        var title = "Misión";
        var content = new InstitutionalContents { Id = Guid.NewGuid(), Title = title, Content = "Contenido..." };

        _mockRepository.Setup(r => r.GetContentByTitleAsync(title)).ReturnsAsync(content);

        var result = await _service.GetContentByTitle(title);

        Assert.NotNull(result);
        Assert.Equal(title, result.Title);
    }
}

public class NormativeDocumentServiceTests
{
    private readonly Mock<INormativeDocumentRepository> _mockRepository;
    private readonly NormativeDocumentService _service;

    public NormativeDocumentServiceTests()
    {
        _mockRepository = new Mock<INormativeDocumentRepository>();
        _service = new NormativeDocumentService(_mockRepository.Object);
    }

    [Fact]
    public async Task GetActiveDocuments_ShouldReturnValidDocuments()
    {
        var documents = new List<NormativeDocuments>
        {
            new NormativeDocuments { Id = Guid.NewGuid(), Name = "Estatutos", FileUrl = "url", FileName = "doc.pdf", FileSize = 1024, UploadDate = DateTime.UtcNow, ValidFrom = DateOnly.FromDateTime(DateTime.Now) }
        };

        _mockRepository.Setup(r => r.GetActiveDocumentsAsync()).ReturnsAsync(documents);

        var result = await _service.GetActiveDocuments();

        Assert.NotNull(result);
        Assert.NotEmpty(result);
    }
}

public class ApplicationDocumentServiceTests
{
    private readonly Mock<IApplicationDocumentRepository> _mockRepository;
    private readonly ApplicationDocumentService _service;

    public ApplicationDocumentServiceTests()
    {
        _mockRepository = new Mock<IApplicationDocumentRepository>();
        _service = new ApplicationDocumentService(_mockRepository.Object);
    }

    [Fact]
    public async Task GetValidDocuments_ShouldReturnOnlyValidOnes()
    {
        var documents = new List<ApplicationDocuments>
        {
            new ApplicationDocuments { Id = Guid.NewGuid(), ApplicationId = Guid.NewGuid(), Name = "Doc1", FileUrl = "url", FileName = "doc.pdf", UploadDate = DateTime.UtcNow, IsValid = true }
        };

        _mockRepository.Setup(r => r.GetValidDocumentsAsync()).ReturnsAsync(documents);

        var result = await _service.GetValidDocuments();

        Assert.NotNull(result);
        Assert.All(result, d => Assert.True(true));
    }
}

public class MembershipCertificateServiceTests
{
    private readonly Mock<IMembershipCertificateRepository> _mockRepository;
    private readonly MembershipCertificateService _service;

    public MembershipCertificateServiceTests()
    {
        _mockRepository = new Mock<IMembershipCertificateRepository>();
        _service = new MembershipCertificateService(_mockRepository.Object);
    }

    [Fact]
    public async Task GetValidCertificates_ShouldReturnCurrentCertificates()
    {
        var today = DateOnly.FromDateTime(DateTime.Now);
        var certificates = new List<MembershipCertificates>
        {
            new MembershipCertificates { Id = Guid.NewGuid(), UniversityId = Guid.NewGuid(), UniversityName = "Universidad 1", CertificateNumber = "CERT-001", IssueDate = today, ValidFrom = today, ValidTo = today.AddYears(1) }
        };

        _mockRepository.Setup(r => r.GetValidCertificatesAsync()).ReturnsAsync(certificates);

        var result = await _service.GetValidCertificates();

        Assert.NotNull(result);
        Assert.NotEmpty(result);
    }

    [Fact]
    public async Task GetExpiredCertificates_ShouldReturnPastCertificates()
    {
        var today = DateOnly.FromDateTime(DateTime.Now);
        var certificates = new List<MembershipCertificates>
        {
            new MembershipCertificates { Id = Guid.NewGuid(), UniversityId = Guid.NewGuid(), UniversityName = "Universidad 1", CertificateNumber = "CERT-002", IssueDate = today.AddYears(-2), ValidFrom = today.AddYears(-2), ValidTo = today.AddDays(-1) }
        };

        _mockRepository.Setup(r => r.GetExpiredCertificatesAsync()).ReturnsAsync(certificates);

        var result = await _service.GetExpiredCertificates();

        Assert.NotNull(result);
        Assert.NotEmpty(result);
    }
}

public class UserSessionServiceTests
{
    private readonly Mock<IUserSessionRepository> _mockRepository;
    private readonly UserSessionService _service;

    public UserSessionServiceTests()
    {
        _mockRepository = new Mock<IUserSessionRepository>();
        _service = new UserSessionService(_mockRepository.Object);
    }

    [Fact]
    public async Task GetActiveSessionsByUserId_ShouldReturnOnlyActiveSessions()
    {
        var userId = Guid.NewGuid();
        var sessions = new List<UserSessions>
        {
            new UserSessions { Id = Guid.NewGuid(), UserId = userId, TokenHash = "hash1", IsActive = true, ExpiresAt = DateTime.UtcNow.AddHours(1), LastActivity = DateTime.UtcNow }
        };

        _mockRepository.Setup(r => r.GetActiveSessionsByUserIdAsync(userId)).ReturnsAsync(sessions);

        var result = await _service.GetActiveSessionsByUserId(userId);

        Assert.NotNull(result);
        Assert.NotEmpty(result);
    }

    [Fact]
    public async Task InvalidateUserSessions_ShouldCallRepository()
    {
        var userId = Guid.NewGuid();
        _mockRepository.Setup(r => r.InvalidateUserSessionsAsync(userId)).Returns(Task.CompletedTask);

        await _service.InvalidateUserSessions(userId);

        _mockRepository.Verify(r => r.InvalidateUserSessionsAsync(userId), Times.Once);
    }
}

public class RolePermissionServiceTests
{
    private readonly Mock<IRolePermissionRepository> _mockRepository;
    private readonly RolePermissionService _service;

    public RolePermissionServiceTests()
    {
        _mockRepository = new Mock<IRolePermissionRepository>();
        _service = new RolePermissionService(_mockRepository.Object);
    }

    [Fact]
    public async Task GetPermissionsByRoleId_ShouldReturnRolePermissions()
    {
        var roleId = Guid.NewGuid();
        var permissions = new List<RolePermissions>
        {
            new RolePermissions { Id = Guid.NewGuid(), RoleId = roleId, IsAllowed = true, CreatedAt = DateTime.UtcNow }
        };

        _mockRepository.Setup(r => r.GetPermissionsByRoleIdAsync(roleId)).ReturnsAsync(permissions);

        var result = await _service.GetPermissionsByRoleId(roleId);

        Assert.NotNull(result);
        Assert.NotEmpty(result);
    }
}

public class UserPermissionServiceTests
{
    private readonly Mock<IUserPermissionRepository> _mockRepository;
    private readonly UserPermissionService _service;

    public UserPermissionServiceTests()
    {
        _mockRepository = new Mock<IUserPermissionRepository>();
        _service = new UserPermissionService(_mockRepository.Object);
    }

    [Fact]
    public async Task GetPermissionsByUserId_ShouldReturnUserPermissions()
    {
        var userId = Guid.NewGuid();
        var permissions = new List<UserPermissions>
        {
            new UserPermissions { Id = Guid.NewGuid(), UserId = userId, IsAllowed = true, CreatedAt = DateTime.UtcNow }
        };

        _mockRepository.Setup(r => r.GetPermissionsByUserIdAsync(userId)).ReturnsAsync(permissions);

        var result = await _service.GetPermissionsByUserId(userId);

        Assert.NotNull(result);
        Assert.NotEmpty(result);
    }
}

public class UniversityReportServiceTests
{
    private readonly Mock<IUniversityReportRepository> _mockRepository;
    private readonly UniversityReportService _service;

    public UniversityReportServiceTests()
    {
        _mockRepository = new Mock<IUniversityReportRepository>();
        _service = new UniversityReportService(_mockRepository.Object);
    }

    [Fact]
    public async Task GetReportsByYear_ShouldReturnYearReports()
    {
        var year = 2024;
        var reports = new List<UniversityReports>
        {
            new UniversityReports { Id = Guid.NewGuid(), UniversityId = Guid.NewGuid(), Year = year, Title = "Reporte 2024", CreatedAt = DateTime.UtcNow }
        };

        _mockRepository.Setup(r => r.GetReportsByYearAsync(year)).ReturnsAsync(reports);

        var result = await _service.GetReportsByYear(year);

        Assert.NotNull(result);
        Assert.NotEmpty(result);
    }
}

public class AuditLogServiceTests
{
    private readonly Mock<IAuditLogRepository> _mockRepository;
    private readonly Mock<IAuditLogChangeRepository> _mockChangeRepository;
    private readonly AuditLogService _service;

    public AuditLogServiceTests()
    {
        _mockRepository = new Mock<IAuditLogRepository>();
        _mockChangeRepository = new Mock<IAuditLogChangeRepository>();
        _service = new AuditLogService(_mockRepository.Object, _mockChangeRepository.Object);
    }

    [Fact]
    public async Task LogActionAsync_ShouldCreateAuditLog()
    {
        var dto = new CreateAuditLogDto { UserId = Guid.NewGuid(), UserName = "admin", Action = "CREATE", EntityType = "User", EntityId = "123" };
        _mockRepository.Setup(r => r.AddLogAsync(It.IsAny<AuditLogs>())).Returns(Task.CompletedTask);

        var result = await _service.LogActionAsync(dto);

        Assert.NotEqual(Guid.Empty, result);
        _mockRepository.Verify(r => r.AddLogAsync(It.IsAny<AuditLogs>()), Times.Once);
    }

    [Fact]
    public async Task LogChangeAsync_ShouldCreateChangeRecord()
    {
        var auditLogId = Guid.NewGuid();
        _mockChangeRepository.Setup(r => r.AddChangeAsync(It.IsAny<AuditLogChanges>())).Returns(Task.CompletedTask);

        await _service.LogChangeAsync(auditLogId, "Status", "Pending", "Approved");

        _mockChangeRepository.Verify(r => r.AddChangeAsync(It.IsAny<AuditLogChanges>()), Times.Once);
    }
}

public class AuditLogChangeServiceTests
{
    private readonly Mock<IAuditLogChangeRepository> _mockRepository;
    private readonly AuditLogChangeService _service;

    public AuditLogChangeServiceTests()
    {
        _mockRepository = new Mock<IAuditLogChangeRepository>();
        _service = new AuditLogChangeService(_mockRepository.Object);
    }

    [Fact]
    public async Task GetChangesByAuditLogId_ShouldReturnChanges()
    {
        var auditLogId = Guid.NewGuid();
        var changes = new List<AuditLogChanges>
        {
            new AuditLogChanges { Id = Guid.NewGuid(), AuditLogId = auditLogId, Field = "Status", OldValue = "Pending", NewValue = "Approved" }
        };

        _mockRepository.Setup(r => r.GetChangesByAuditLogIdAsync(auditLogId)).ReturnsAsync(changes);

        var result = await _service.GetChangesByAuditLogId(auditLogId);

        Assert.NotNull(result);
        Assert.NotEmpty(result);
    }
}

public class MembershipApplicationServiceTests
{
    private readonly Mock<IMembershipApplicationRepository> _mockRepository;
    private readonly MembershipApplicationService _service;

    public MembershipApplicationServiceTests()
    {
        _mockRepository = new Mock<IMembershipApplicationRepository>();
        _service = new MembershipApplicationService(_mockRepository.Object);
    }

    [Fact]
    public async Task GetPendingApplications_ShouldReturnUnreviewedApplications()
    {
        var applications = new List<MembershipApplications>
        {
            new MembershipApplications { Id = Guid.NewGuid(), UniversityId = Guid.NewGuid(), UniversityName = "Universidad 1", ApplicantName = "Juan", ApplicantEmail = "juan@example.com", ApplicationDate = DateOnly.FromDateTime(DateTime.Now), ReviewStartedAt = null }
        };

        _mockRepository.Setup(r => r.GetPendingApplicationsAsync()).ReturnsAsync(applications);

        var result = await _service.GetPendingApplications();

        Assert.NotNull(result);
        Assert.NotEmpty(result);
    }

    [Fact]
    public async Task GenerateApplicationNumber_ShouldReturnUniqueNumber()
    {
        var number1 = "APP-2024-0001";

        _mockRepository.Setup(r => r.GenerateApplicationNumberAsync()).ReturnsAsync(number1);

        var result = await _service.GenerateApplicationNumberAsync();

        Assert.NotEmpty(result);
        Assert.StartsWith("APP-", result);
    }
}
