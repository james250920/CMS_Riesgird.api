using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Core.Services;

public class ResearcherService : IResearcherService
{
    private readonly IResearcherRepository _repository;

    public ResearcherService(IResearcherRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ResearcherResponseDto>> GetAllResearchers()
    {
        var researchers = await _repository.GetAllResearchersAsync();
        return researchers.Select(r => MapToResponseDto(r));
    }

    public async Task<ResearcherResponseDto?> GetResearcherById(Guid id)
    {
        var researcher = await _repository.GetResearcherByIdAsync(id);
        if (researcher == null)
            return null;

        return MapToResponseDto(researcher);
    }

    public async Task<IEnumerable<ResearcherResponseDto>> GetResearchersByUniversityId(Guid universityId)
    {
        var researchers = await _repository.GetResearchersByUniversityIdAsync(universityId);
        return researchers.Select(r => MapToResponseDto(r));
    }

    public async Task<IEnumerable<ResearcherResponseDto>> GetPublicResearchers()
    {
        var researchers = await _repository.GetPublicResearchersAsync();
        return researchers.Select(r => MapToResponseDto(r));
    }

    public async Task<IEnumerable<ResearcherResponseDto>> GetResearchersByResearchArea(string researchArea)
    {
        var researchers = await _repository.GetResearchersByResearchAreaAsync(researchArea);
        return researchers.Select(r => MapToResponseDto(r));
    }

    public async Task<IEnumerable<ResearcherResponseDto>> GetActiveResearchers()
    {
        var researchers = await _repository.GetActiveResearchersAsync();
        return researchers.Select(r => MapToResponseDto(r));
    }

    public async Task<Guid> CreateResearcher(CreateResearcherDto dto)
    {
        var researcher = new Researchers
        {
            Id = Guid.NewGuid(),
            UniversityId = dto.UniversityId,
            FullName = dto.FullName,
            Email = dto.Email,
            Phone = dto.Phone,
            Dni = dto.Dni,
            PhotoUrl = dto.PhotoUrl,
            Specialty = dto.Specialty,
            ResearchAreas = dto.ResearchAreas,
            OrcidId = dto.OrcidId,
            ScopusId = dto.ScopusId,
            GoogleScholarUrl = dto.GoogleScholarUrl,
            Faculty = dto.Faculty,
            Department = dto.Department,
            Position = dto.Position,
            Bio = dto.Bio,
            PublicationsCount = dto.PublicationsCount,
            IsActive = dto.IsActive,
            IsPublic = dto.IsPublic,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        await _repository.AddResearcherAsync(researcher);
        return researcher.Id;
    }

    public async Task UpdateResearcher(Guid id, UpdateResearcherDto dto)
    {
        var researcher = await _repository.GetResearcherByIdAsync(id);
        if (researcher == null)
            throw new Exception("Investigador no encontrado");

        researcher.UniversityId = dto.UniversityId;
        researcher.FullName = dto.FullName ?? researcher.FullName;
        researcher.Email = dto.Email ?? researcher.Email;
        researcher.Phone = dto.Phone ?? researcher.Phone;
        researcher.Dni = dto.Dni ?? researcher.Dni;
        researcher.PhotoUrl = dto.PhotoUrl ?? researcher.PhotoUrl;
        researcher.Specialty = dto.Specialty ?? researcher.Specialty;
        researcher.ResearchAreas = dto.ResearchAreas ?? researcher.ResearchAreas;
        researcher.OrcidId = dto.OrcidId ?? researcher.OrcidId;
        researcher.ScopusId = dto.ScopusId ?? researcher.ScopusId;
        researcher.GoogleScholarUrl = dto.GoogleScholarUrl ?? researcher.GoogleScholarUrl;
        researcher.Faculty = dto.Faculty ?? researcher.Faculty;
        researcher.Department = dto.Department ?? researcher.Department;
        researcher.Position = dto.Position ?? researcher.Position;
        researcher.Bio = dto.Bio ?? researcher.Bio;
        researcher.PublicationsCount = dto.PublicationsCount;
        researcher.IsActive = dto.IsActive;
        researcher.IsPublic = dto.IsPublic;
        researcher.UpdatedAt = DateTime.UtcNow;

        await _repository.UpdateResearcherAsync(researcher);
    }

    public async Task DeleteResearcher(Guid id)
    {
        await _repository.DeleteResearcherAsync(id);
    }

    private ResearcherResponseDto MapToResponseDto(Researchers researcher)
    {
        return new ResearcherResponseDto
        {
            Id = researcher.Id,
            UniversityId = researcher.UniversityId,
            FullName = researcher.FullName,
            Email = researcher.Email,
            Phone = researcher.Phone,
            Dni = researcher.Dni,
            PhotoUrl = researcher.PhotoUrl,
            Specialty = researcher.Specialty,
            ResearchAreas = researcher.ResearchAreas,
            OrcidId = researcher.OrcidId,
            ScopusId = researcher.ScopusId,
            GoogleScholarUrl = researcher.GoogleScholarUrl,
            Faculty = researcher.Faculty,
            Department = researcher.Department,
            Position = researcher.Position,
            Bio = researcher.Bio,
            PublicationsCount = researcher.PublicationsCount,
            IsActive = researcher.IsActive,
            IsPublic = researcher.IsPublic,
            CreatedAt = researcher.CreatedAt,
            UpdatedAt = researcher.UpdatedAt
        };
    }
}
