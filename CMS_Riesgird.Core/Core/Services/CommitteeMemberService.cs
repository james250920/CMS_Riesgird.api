using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Core.Services;

public class CommitteeMemberService : ICommitteeMemberService
{
    private readonly ICommitteeMemberRepository _repository;

    public CommitteeMemberService(ICommitteeMemberRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<CommitteeMemberResponseDto>> GetAllMembers()
    {
        var members = await _repository.GetAllMembersAsync();
        return members.Select(m => MapToResponseDto(m));
    }

    public async Task<CommitteeMemberResponseDto?> GetMemberById(Guid id)
    {
        var member = await _repository.GetMemberByIdAsync(id);
        if (member == null)
            return null;

        return MapToResponseDto(member);
    }

    public async Task<IEnumerable<CommitteeMemberResponseDto>> GetMembersByCongressId(Guid congressId)
    {
        var members = await _repository.GetMembersByCongressIdAsync(congressId);
        return members.Select(m => MapToResponseDto(m));
    }

    public async Task<IEnumerable<CommitteeMemberResponseDto>> GetMembersByRole(string role)
    {
        var members = await _repository.GetMembersByRoleAsync(role);
        return members.Select(m => MapToResponseDto(m));
    }

    public async Task<Guid> CreateMember(CreateCommitteeMemberDto dto)
    {
        var member = new CommitteeMembers
        {
            Id = Guid.NewGuid(),
            CongressId = dto.CongressId,
            FullName = dto.FullName,
            Role = dto.Role,
            Institution = dto.Institution,
            Email = dto.Email,
            SortOrder = dto.SortOrder
        };

        await _repository.AddMemberAsync(member);
        return member.Id;
    }

    public async Task UpdateMember(Guid id, UpdateCommitteeMemberDto dto)
    {
        var member = await _repository.GetMemberByIdAsync(id);
        if (member == null)
            throw new Exception("Miembro del comité no encontrado");

        member.CongressId = dto.CongressId;
        member.FullName = dto.FullName ?? member.FullName;
        member.Role = dto.Role ?? member.Role;
        member.Institution = dto.Institution ?? member.Institution;
        member.Email = dto.Email ?? member.Email;
        member.SortOrder = dto.SortOrder;

        await _repository.UpdateMemberAsync(member);
    }

    public async Task DeleteMember(Guid id)
    {
        await _repository.DeleteMemberAsync(id);
    }

    private CommitteeMemberResponseDto MapToResponseDto(CommitteeMembers member)
    {
        return new CommitteeMemberResponseDto
        {
            Id = member.Id,
            CongressId = member.CongressId,
            FullName = member.FullName,
            Role = member.Role,
            Institution = member.Institution,
            Email = member.Email,
            SortOrder = member.SortOrder
        };
    }
}
