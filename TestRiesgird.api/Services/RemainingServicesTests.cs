using Xunit;
using Moq;
using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Core.Core.Services;
using CMS_Riesgird.Domain.Models;

namespace TestRiesgird.api.Services;

public class AuthorityServiceTests
{
    private readonly Mock<IAuthorityRepository> _mockRepository;
    private readonly AuthorityService _service;

    public AuthorityServiceTests()
    {
        _mockRepository = new Mock<IAuthorityRepository>();
        _service = new AuthorityService(_mockRepository.Object);
    }

    [Fact]
    public async Task GetAllAuthorities_ShouldReturnAllAuthorities()
    {
        // Arrange
        var authorities = new List<Authorities>
        {
            new Authorities
            {
                Id = Guid.NewGuid(),
                Name = "Authority 1",
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            }
        };

        _mockRepository.Setup(r => r.GetAllAuthoritiesAsync()).ReturnsAsync(authorities);

        // Act
        var result = await _service.GetAllAuthorities();

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
    }

    [Fact]
    public async Task GetAuthorityById_WithValidId_ShouldReturnAuthority()
    {
        // Arrange
        var authorityId = Guid.NewGuid();
        var authority = new Authorities
        {
            Id = authorityId,
            Name = "Test Authority",
            IsActive = true,
            CreatedAt = DateTime.UtcNow
        };

        _mockRepository.Setup(r => r.GetAuthorityByIdAsync(authorityId)).ReturnsAsync(authority);

        // Act
        var result = await _service.GetAuthorityById(authorityId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(authorityId, result.Id);
    }

    [Fact]
    public async Task CreateAuthority_WithValidData_ShouldReturnAuthorityId()
    {
        // Arrange
        var dto = new CreateAuthorityDto
        {
            Name = "New Authority",
            IsActive = true
        };

        _mockRepository.Setup(r => r.AddAuthorityAsync(It.IsAny<Authorities>())).Returns(Task.CompletedTask);

        // Act
        var result = await _service.CreateAuthority(dto);

        // Assert
        Assert.NotEqual(Guid.Empty, result);
        _mockRepository.Verify(r => r.AddAuthorityAsync(It.IsAny<Authorities>()), Times.Once);
    }
}

public class AssemblyServiceTests
{
    private readonly Mock<IAssemblyRepository> _mockRepository;
    private readonly AssemblyService _service;

    public AssemblyServiceTests()
    {
        _mockRepository = new Mock<IAssemblyRepository>();
        _service = new AssemblyService(_mockRepository.Object);
    }

    [Fact]
    public async Task GetAllAssemblies_ShouldReturnAllAssemblies()
    {
        // Arrange
        var assemblies = new List<Assemblies>
        {
            new Assemblies
            {
                Id = Guid.NewGuid(),
                Number = 1,
                Title = "Assembly 1",
                Date = DateOnly.FromDateTime(DateTime.Now),
                Location = "Lima",
                Description = "Test assembly",
                IsPublic = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            }
        };

        _mockRepository.Setup(r => r.GetAllAssembliesAsync()).ReturnsAsync(assemblies);

        // Act
        var result = await _service.GetAllAssemblies();

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
    }

    [Fact]
    public async Task GetAssemblyById_WithValidId_ShouldReturnAssembly()
    {
        // Arrange
        var assemblyId = Guid.NewGuid();
        var assembly = new Assemblies
        {
            Id = assemblyId,
            Number = 1,
            Title = "Test Assembly",
            Date = DateOnly.FromDateTime(DateTime.Now),
            Location = "Lima",
            Description = "Test",
            IsPublic = true,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _mockRepository.Setup(r => r.GetAssemblyByIdAsync(assemblyId)).ReturnsAsync(assembly);

        // Act
        var result = await _service.GetAssemblyById(assemblyId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(assemblyId, result.Id);
        Assert.Equal("Test Assembly", result.Title);
    }

    [Fact]
    public async Task CreateAssembly_WithValidData_ShouldReturnAssemblyId()
    {
        // Arrange
        var dto = new CreateAssemblyDto
        {
            Number = 2,
            Title = "New Assembly",
            Date = DateOnly.FromDateTime(DateTime.Now),
            Location = "Lima",
            Description = "New Assembly Description",
            IsPublic = true
        };

        _mockRepository.Setup(r => r.AddAssemblyAsync(It.IsAny<Assemblies>())).Returns(Task.CompletedTask);

        // Act
        var result = await _service.CreateAssembly(dto);

        // Assert
        Assert.NotEqual(Guid.Empty, result);
        _mockRepository.Verify(r => r.AddAssemblyAsync(It.IsAny<Assemblies>()), Times.Once);
    }

    [Fact]
    public async Task GetPublicAssemblies_ShouldReturnOnlyPublicAssemblies()
    {
        // Arrange
        var assemblies = new List<Assemblies>
        {
            new Assemblies { Id = Guid.NewGuid(), Number = 1, Title = "Public", Date = DateOnly.FromDateTime(DateTime.Now), Location = "Lima", Description = "Desc", IsPublic = true, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new Assemblies { Id = Guid.NewGuid(), Number = 2, Title = "Private", Date = DateOnly.FromDateTime(DateTime.Now), Location = "Lima", Description = "Desc", IsPublic = false, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
        };

        _mockRepository.Setup(r => r.GetPublicAssembliesAsync()).ReturnsAsync(assemblies.Where(a => a.IsPublic).ToList());

        // Act
        var result = await _service.GetPublicAssemblies();

        // Assert
        Assert.NotNull(result);
        Assert.All(result, a => Assert.True(a.IsPublic));
    }
}

public class UniversityBrigadeServiceTests
{
    private readonly Mock<IUniversityBrigadeRepository> _mockRepository;
    private readonly UniversityBrigadeService _service;

    public UniversityBrigadeServiceTests()
    {
        _mockRepository = new Mock<IUniversityBrigadeRepository>();
        _service = new UniversityBrigadeService(_mockRepository.Object);
    }

    [Fact]
    public async Task GetAllBrigades_ShouldReturnAllBrigades()
    {
        // Arrange
        var brigades = new List<UniversityBrigades>
        {
            new UniversityBrigades
            {
                Id = Guid.NewGuid(),
                UniversityId = Guid.NewGuid(),
                Name = "Brigade 1",
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            }
        };

        _mockRepository.Setup(r => r.GetAllBrigadesAsync()).ReturnsAsync(brigades);

        // Act
        var result = await _service.GetAllBrigades();

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
    }

    [Fact]
    public async Task GetBrigadeById_WithValidId_ShouldReturnBrigade()
    {
        // Arrange
        var brigadeId = Guid.NewGuid();
        var brigade = new UniversityBrigades
        {
            Id = brigadeId,
            UniversityId = Guid.NewGuid(),
            Name = "Test Brigade",
            IsActive = true,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _mockRepository.Setup(r => r.GetBrigadeByIdAsync(brigadeId)).ReturnsAsync(brigade);

        // Act
        var result = await _service.GetBrigadeById(brigadeId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(brigadeId, result.Id);
        Assert.Equal("Test Brigade", result.Name);
    }

    [Fact]
    public async Task CreateBrigade_WithValidData_ShouldReturnBrigadeId()
    {
        // Arrange
        var dto = new CreateUniversityBrigadeDto
        {
            UniversityId = Guid.NewGuid(),
            Name = "New Brigade",
            IsActive = true
        };

        _mockRepository.Setup(r => r.AddBrigadeAsync(It.IsAny<UniversityBrigades>())).Returns(Task.CompletedTask);

        // Act
        var result = await _service.CreateBrigade(dto);

        // Assert
        Assert.NotEqual(Guid.Empty, result);
        _mockRepository.Verify(r => r.AddBrigadeAsync(It.IsAny<UniversityBrigades>()), Times.Once);
    }

    [Fact]
    public async Task GetActiveBrigades_ShouldReturnOnlyActiveBrigades()
    {
        // Arrange
        var brigades = new List<UniversityBrigades>
        {
            new UniversityBrigades { Id = Guid.NewGuid(), UniversityId = Guid.NewGuid(), Name = "Active", IsActive = true, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new UniversityBrigades { Id = Guid.NewGuid(), UniversityId = Guid.NewGuid(), Name = "Inactive", IsActive = false, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
        };

        _mockRepository.Setup(r => r.GetActiveBrigadesAsync()).ReturnsAsync(brigades.Where(b => b.IsActive).ToList());

        // Act
        var result = await _service.GetActiveBrigades();

        // Assert
        Assert.NotNull(result);
        Assert.All(result, b => Assert.True(b.IsActive));
    }
}

public class TechnicalTeamMemberServiceTests
{
    private readonly Mock<ITechnicalTeamMemberRepository> _mockRepository;
    private readonly TechnicalTeamMemberService _service;

    public TechnicalTeamMemberServiceTests()
    {
        _mockRepository = new Mock<ITechnicalTeamMemberRepository>();
        _service = new TechnicalTeamMemberService(_mockRepository.Object);
    }

    [Fact]
    public async Task GetAllMembers_ShouldReturnAllMembers()
    {
        // Arrange
        var members = new List<TechnicalTeamMembers>
        {
            new TechnicalTeamMembers
            {
                Id = Guid.NewGuid(),
                FullName = "Team Member 1",
                Email = "member1@example.com",
                Role = "Developer",
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            }
        };

        _mockRepository.Setup(r => r.GetAllMembersAsync()).ReturnsAsync(members);

        // Act
        var result = await _service.GetAllMembers();

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
    }

    [Fact]
    public async Task GetMemberById_WithValidId_ShouldReturnMember()
    {
        // Arrange
        var memberId = Guid.NewGuid();
        var member = new TechnicalTeamMembers
        {
            Id = memberId,
            FullName = "Test Member",
            Email = "test@example.com",
            Role = "Developer",
            IsActive = true,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _mockRepository.Setup(r => r.GetMemberByIdAsync(memberId)).ReturnsAsync(member);

        // Act
        var result = await _service.GetMemberById(memberId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(memberId, result.Id);
        Assert.Equal("Test Member", result.FullName);
    }

    [Fact]
    public async Task CreateMember_WithValidData_ShouldReturnMemberId()
    {
        // Arrange
        var dto = new CreateTechnicalTeamMemberDto
        {
            FullName = "New Member",
            Email = "new@example.com",
            Role = "Developer",
            IsActive = true
        };

        _mockRepository.Setup(r => r.AddMemberAsync(It.IsAny<TechnicalTeamMembers>())).Returns(Task.CompletedTask);

        // Act
        var result = await _service.CreateMember(dto);

        // Assert
        Assert.NotEqual(Guid.Empty, result);
        _mockRepository.Verify(r => r.AddMemberAsync(It.IsAny<TechnicalTeamMembers>()), Times.Once);
    }
}
