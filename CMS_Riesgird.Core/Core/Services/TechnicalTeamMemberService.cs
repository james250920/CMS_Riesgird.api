using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Core.Services;

public class TechnicalTeamMemberService : ITechnicalTeamMemberService
{
    private readonly ITechnicalTeamMemberRepository _repository;

    public TechnicalTeamMemberService(ITechnicalTeamMemberRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<TechnicalTeamMemberResponseDto>> GetAllTechnicalTeamMembers()
    {
        var members = await _repository.GetAllTechnicalTeamMembersAsync();
        return members.Select(m => MapToResponseDto(m));
    }

    public async Task<IEnumerable<TechnicalTeamMemberResponseDto>> GetTechnicalTeamMembersByUniversityId(Guid universityId)
    {
        var members = await _repository.GetTechnicalTeamMembersByUniversityIdAsync(universityId);
        return members.Select(m => MapToResponseDto(m));
    }

    public async Task<TechnicalTeamMemberResponseDto?> GetTechnicalTeamMemberById(Guid id)
    {
        var member = await _repository.GetTechnicalTeamMemberByIdAsync(id);
        if (member == null)
            return null;

        return MapToResponseDto(member);
    }

    public async Task<Guid> CreateTechnicalTeamMember(CreateTechnicalTeamMemberDto dto)
    {
        var member = new TechnicalTeamMembers
        {
            Id = Guid.NewGuid(),
            UniversityId = dto.UniversityId,
            FullName = dto.FullName,
            TeamType = dto.TeamType,
            Email = dto.Email,
            Phone = dto.Phone,
            Dni = dto.Dni,
            PhotoUrl = dto.PhotoUrl,
            Position = dto.Position,
            Specialty = dto.Specialty,
            AreaRepresented = dto.AreaRepresented,
            ResolutionNumber = dto.ResolutionNumber,
            ResolutionDate = dto.ResolutionDate,
            ResolutionFileUrl = dto.ResolutionFileUrl,
            IsActive = dto.IsActive,
            IsPublic = dto.IsPublic,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        await _repository.AddTechnicalTeamMemberAsync(member);
        return member.Id;
    }

    public async Task UpdateTechnicalTeamMember(Guid id, UpdateTechnicalTeamMemberDto dto)
    {
        var member = await _repository.GetTechnicalTeamMemberByIdAsync(id);
        if (member == null)
            throw new Exception("Miembro del equipo técnico no encontrado");

        member.UniversityId = dto.UniversityId;
        member.FullName = dto.FullName ?? member.FullName;
        member.TeamType = dto.TeamType ?? member.TeamType;
        member.Email = dto.Email ?? member.Email;
        member.Phone = dto.Phone ?? member.Phone;
        member.Dni = dto.Dni ?? member.Dni;
        member.PhotoUrl = dto.PhotoUrl ?? member.PhotoUrl;
        member.Position = dto.Position ?? member.Position;
        member.Specialty = dto.Specialty ?? member.Specialty;
        member.AreaRepresented = dto.AreaRepresented ?? member.AreaRepresented;
        member.ResolutionNumber = dto.ResolutionNumber ?? member.ResolutionNumber;
        member.ResolutionDate = dto.ResolutionDate ?? member.ResolutionDate;
        member.ResolutionFileUrl = dto.ResolutionFileUrl ?? member.ResolutionFileUrl;
        member.IsActive = dto.IsActive;
        member.IsPublic = dto.IsPublic;
        member.UpdatedAt = DateTime.UtcNow;

        await _repository.UpdateTechnicalTeamMemberAsync(member);
    }

    public async Task DeleteTechnicalTeamMember(Guid id)
    {
        await _repository.DeleteTechnicalTeamMemberAsync(id);
    }

    private TechnicalTeamMemberResponseDto MapToResponseDto(TechnicalTeamMembers member)
    {
        return new TechnicalTeamMemberResponseDto
        {
            Id = member.Id,
            UniversityId = member.UniversityId,
            FullName = member.FullName,
            TeamType = member.TeamType,
            Email = member.Email,
            Phone = member.Phone,
            Dni = member.Dni,
            PhotoUrl = member.PhotoUrl,
            Position = member.Position,
            Specialty = member.Specialty,
            AreaRepresented = member.AreaRepresented,
            ResolutionNumber = member.ResolutionNumber,
            ResolutionDate = member.ResolutionDate,
            ResolutionFileUrl = member.ResolutionFileUrl,
            IsActive = member.IsActive,
            IsPublic = member.IsPublic,
            CreatedAt = member.CreatedAt,
            UpdatedAt = member.UpdatedAt
        };
    }
}
