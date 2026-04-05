using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Core.Services;

public class UniversityBrigadeService : IUniversityBrigadeService
{
    private readonly IUniversityBrigadeRepository _repository;

    public UniversityBrigadeService(IUniversityBrigadeRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<UniversityBrigadeResponseDto>> GetAllUniversityBrigades()
    {
        var brigades = await _repository.GetAllUniversityBrigadesAsync();
        return brigades.Select(b => MapToResponseDto(b));
    }

    public async Task<IEnumerable<UniversityBrigadeResponseDto>> GetUniversityBrigadesByUniversityId(Guid universityId)
    {
        var brigades = await _repository.GetUniversityBrigadesByUniversityIdAsync(universityId);
        return brigades.Select(b => MapToResponseDto(b));
    }

    public async Task<UniversityBrigadeResponseDto?> GetUniversityBrigadeById(Guid id)
    {
        var brigade = await _repository.GetUniversityBrigadeByIdAsync(id);
        if (brigade == null)
            return null;

        return MapToResponseDto(brigade);
    }

    public async Task<Guid> CreateUniversityBrigade(CreateUniversityBrigadeDto dto)
    {
        var brigade = new UniversityBrigades
        {
            Id = Guid.NewGuid(),
            UniversityId = dto.UniversityId,
            Name = dto.Name,
            Description = dto.Description,
            Coordinator = dto.Coordinator,
            CoordinatorEmail = dto.CoordinatorEmail,
            CoordinatorPhone = dto.CoordinatorPhone,
            ContactEmail = dto.ContactEmail,
            MembersCount = dto.MembersCount,
            FoundedDate = dto.FoundedDate,
            Certifications = dto.Certifications,
            LogoUrl = dto.LogoUrl,
            IsActive = dto.IsActive,
            IsPublic = dto.IsPublic,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        await _repository.AddUniversityBrigadeAsync(brigade);
        return brigade.Id;
    }

    public async Task UpdateUniversityBrigade(Guid id, UpdateUniversityBrigadeDto dto)
    {
        var brigade = await _repository.GetUniversityBrigadeByIdAsync(id);
        if (brigade == null)
            throw new Exception("Brigada universitaria no encontrada");

        brigade.UniversityId = dto.UniversityId;
        brigade.Name = dto.Name ?? brigade.Name;
        brigade.Description = dto.Description ?? brigade.Description;
        brigade.Coordinator = dto.Coordinator ?? brigade.Coordinator;
        brigade.CoordinatorEmail = dto.CoordinatorEmail ?? brigade.CoordinatorEmail;
        brigade.CoordinatorPhone = dto.CoordinatorPhone ?? brigade.CoordinatorPhone;
        brigade.ContactEmail = dto.ContactEmail ?? brigade.ContactEmail;
        brigade.MembersCount = dto.MembersCount ?? brigade.MembersCount;
        brigade.FoundedDate = dto.FoundedDate ?? brigade.FoundedDate;
        brigade.Certifications = dto.Certifications ?? brigade.Certifications;
        brigade.LogoUrl = dto.LogoUrl ?? brigade.LogoUrl;
        brigade.IsActive = dto.IsActive;
        brigade.IsPublic = dto.IsPublic;
        brigade.UpdatedAt = DateTime.UtcNow;

        await _repository.UpdateUniversityBrigadeAsync(brigade);
    }

    public async Task DeleteUniversityBrigade(Guid id)
    {
        await _repository.DeleteUniversityBrigadeAsync(id);
    }

    private UniversityBrigadeResponseDto MapToResponseDto(UniversityBrigades brigade)
    {
        return new UniversityBrigadeResponseDto
        {
            Id = brigade.Id,
            UniversityId = brigade.UniversityId,
            Name = brigade.Name,
            Description = brigade.Description,
            Coordinator = brigade.Coordinator,
            CoordinatorEmail = brigade.CoordinatorEmail,
            CoordinatorPhone = brigade.CoordinatorPhone,
            ContactEmail = brigade.ContactEmail,
            MembersCount = brigade.MembersCount,
            FoundedDate = brigade.FoundedDate,
            Certifications = brigade.Certifications,
            LogoUrl = brigade.LogoUrl,
            IsActive = brigade.IsActive,
            IsPublic = brigade.IsPublic,
            CreatedAt = brigade.CreatedAt,
            UpdatedAt = brigade.UpdatedAt
        };
    }
}
