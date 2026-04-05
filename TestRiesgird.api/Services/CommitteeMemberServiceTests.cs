using Xunit;
using Moq;
using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Core.Core.Services;
using CMS_Riesgird.Domain.Models;

namespace TestRiesgird.api.Services;

public class CommitteeMemberServiceTests
{
    private readonly Mock<ICommitteeMemberRepository> _mockRepository;
    private readonly CommitteeMemberService _service;

    public CommitteeMemberServiceTests()
    {
        _mockRepository = new Mock<ICommitteeMemberRepository>();
        _service = new CommitteeMemberService(_mockRepository.Object);
    }

    [Fact]
    public async Task GetAllMembers_ShouldReturnAllMembers()
    {
        // Arrange
        var members = new List<CommitteeMembers>
        {
            new CommitteeMembers
            {
                Id = Guid.NewGuid(),
                CongressId = Guid.NewGuid(),
                FullName = "Dr. Member 1",
                Role = "President",
                Institution = "University 1",
                SortOrder = 1
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
        var member = new CommitteeMembers
        {
            Id = memberId,
            CongressId = Guid.NewGuid(),
            FullName = "Dr. Test",
            Role = "President",
            Institution = "University",
            SortOrder = 1
        };

        _mockRepository.Setup(r => r.GetMemberByIdAsync(memberId)).ReturnsAsync(member);

        // Act
        var result = await _service.GetMemberById(memberId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(memberId, result.Id);
        Assert.Equal("Dr. Test", result.FullName);
    }

    [Fact]
    public async Task CreateMember_WithValidData_ShouldReturnMemberId()
    {
        // Arrange
        var dto = new CreateCommitteeMemberDto
        {
            CongressId = Guid.NewGuid(),
            FullName = "New Member",
            Role = "Vice President",
            Institution = "University",
            SortOrder = 2
        };

        _mockRepository.Setup(r => r.AddMemberAsync(It.IsAny<CommitteeMembers>())).Returns(Task.CompletedTask);

        // Act
        var result = await _service.CreateMember(dto);

        // Assert
        Assert.NotEqual(Guid.Empty, result);
        _mockRepository.Verify(r => r.AddMemberAsync(It.IsAny<CommitteeMembers>()), Times.Once);
    }

    [Fact]
    public async Task GetMembersByCongressId_ShouldReturnMembersForCongress()
    {
        // Arrange
        var congressId = Guid.NewGuid();
        var members = new List<CommitteeMembers>
        {
            new CommitteeMembers { Id = Guid.NewGuid(), CongressId = congressId, FullName = "Member", Role = "Role", Institution = "Inst", SortOrder = 1 }
        };

        _mockRepository.Setup(r => r.GetMembersByCongressIdAsync(congressId)).ReturnsAsync(members);

        // Act
        var result = await _service.GetMembersByCongressId(congressId);

        // Assert
        Assert.NotNull(result);
        Assert.All(result, m => Assert.Equal(congressId, m.CongressId));
    }

    [Fact]
    public async Task GetMembersByRole_ShouldReturnMembersWithSpecificRole()
    {
        // Arrange
        var role = "President";
        var members = new List<CommitteeMembers>
        {
            new CommitteeMembers { Id = Guid.NewGuid(), CongressId = Guid.NewGuid(), FullName = "President", Role = "President", Institution = "Inst", SortOrder = 1 }
        };

        _mockRepository.Setup(r => r.GetMembersByRoleAsync(role)).ReturnsAsync(members);

        // Act
        var result = await _service.GetMembersByRole(role);

        // Assert
        Assert.NotNull(result);
        Assert.All(result, m => Assert.Equal("President", m.Role));
    }

    [Fact]
    public async Task UpdateMember_WithValidData_ShouldUpdateSuccessfully()
    {
        // Arrange
        var memberId = Guid.NewGuid();
        var existing = new CommitteeMembers
        {
            Id = memberId,
            CongressId = Guid.NewGuid(),
            FullName = "Old Name",
            Role = "President",
            Institution = "Inst",
            SortOrder = 1
        };

        var updateDto = new UpdateCommitteeMemberDto
        {
            Id = memberId,
            CongressId = Guid.NewGuid(),
            FullName = "New Name",
            Role = "Vice President",
            Institution = "Inst",
            SortOrder = 2
        };

        _mockRepository.Setup(r => r.GetMemberByIdAsync(memberId)).ReturnsAsync(existing);
        _mockRepository.Setup(r => r.UpdateMemberAsync(It.IsAny<CommitteeMembers>())).Returns(Task.CompletedTask);

        // Act
        await _service.UpdateMember(memberId, updateDto);

        // Assert
        _mockRepository.Verify(r => r.UpdateMemberAsync(It.IsAny<CommitteeMembers>()), Times.Once);
    }
}
