using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Core.Services;

public class ExpertService : IExpertService
{
    private readonly IExpertRepository _repository;

    public ExpertService(IExpertRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ExpertResponseDto>> GetAllExperts()
    {
        var experts = await _repository.GetAllExpertsAsync();
        return experts.Select(e => MapToResponseDto(e));
    }

    public async Task<ExpertResponseDto?> GetExpertById(Guid id)
    {
        var expert = await _repository.GetExpertByIdAsync(id);
        if (expert == null)
            return null;

        return MapToResponseDto(expert);
    }

    public async Task<IEnumerable<ExpertResponseDto>> GetPublicExperts()
    {
        var experts = await _repository.GetPublicExpertsAsync();
        return experts.Select(e => MapToResponseDto(e));
    }

    public async Task<IEnumerable<ExpertResponseDto>> GetActiveExperts()
    {
        var experts = await _repository.GetActiveExpertsAsync();
        return experts.Select(e => MapToResponseDto(e));
    }

    public async Task<IEnumerable<ExpertResponseDto>> GetExpertsByExpertiseArea(string expertiseArea)
    {
        var experts = await _repository.GetExpertsByExpertiseAreaAsync(expertiseArea);
        return experts.Select(e => MapToResponseDto(e));
    }

    public async Task<IEnumerable<ExpertResponseDto>> GetExpertsByCountry(string country)
    {
        var experts = await _repository.GetExpertsByCountryAsync(country);
        return experts.Select(e => MapToResponseDto(e));
    }

    public async Task<IEnumerable<ExpertResponseDto>> GetAvailableExperts()
    {
        var experts = await _repository.GetAvailableExpertsAsync();
        return experts.Select(e => MapToResponseDto(e));
    }

    public async Task<IEnumerable<ExpertResponseDto>> GetExpertsAvailableForConsulting()
    {
        var experts = await _repository.GetExpertsAvailableForConsultingAsync();
        return experts.Select(e => MapToResponseDto(e));
    }

    public async Task<IEnumerable<ExpertResponseDto>> GetExpertsAvailableForTraining()
    {
        var experts = await _repository.GetExpertsAvailableForTrainingAsync();
        return experts.Select(e => MapToResponseDto(e));
    }

    public async Task<IEnumerable<ExpertResponseDto>> GetExpertsAvailableForResearch()
    {
        var experts = await _repository.GetExpertsAvailableForResearchAsync();
        return experts.Select(e => MapToResponseDto(e));
    }

    public async Task<Guid> CreateExpert(CreateExpertDto dto)
    {
        var expert = new Experts
        {
            Id = Guid.NewGuid(),
            FullName = dto.FullName,
            Email = dto.Email,
            Phone = dto.Phone,
            PhotoUrl = dto.PhotoUrl,
            Title = dto.Title,
            Organization = dto.Organization,
            ExpertiseAreas = dto.ExpertiseAreas,
            Specialties = dto.Specialties,
            SpecialtyInRiskGovernance = dto.SpecialtyInRiskGovernance,
            YearsOfExperience = dto.YearsOfExperience,
            Institution = dto.Institution,
            Position = dto.Position,
            Country = dto.Country,
            City = dto.City,
            Bio = dto.Bio,
            LinkedinUrl = dto.LinkedinUrl,
            Website = dto.Website,
            CvFileUrl = dto.CvFileUrl,
            IsAvailable = dto.IsAvailable,
            AvailableForConsulting = dto.AvailableForConsulting,
            AvailableForTraining = dto.AvailableForTraining,
            AvailableForResearch = dto.AvailableForResearch,
            IsActive = dto.IsActive,
            IsPublic = dto.IsPublic,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        await _repository.AddExpertAsync(expert);
        return expert.Id;
    }

    public async Task UpdateExpert(Guid id, UpdateExpertDto dto)
    {
        var expert = await _repository.GetExpertByIdAsync(id);
        if (expert == null)
            throw new Exception("Experto no encontrado");

        expert.FullName = dto.FullName ?? expert.FullName;
        expert.Email = dto.Email ?? expert.Email;
        expert.Phone = dto.Phone ?? expert.Phone;
        expert.PhotoUrl = dto.PhotoUrl ?? expert.PhotoUrl;
        expert.Title = dto.Title ?? expert.Title;
        expert.Organization = dto.Organization ?? expert.Organization;
        expert.ExpertiseAreas = dto.ExpertiseAreas ?? expert.ExpertiseAreas;
        expert.Specialties = dto.Specialties ?? expert.Specialties;
        expert.SpecialtyInRiskGovernance = dto.SpecialtyInRiskGovernance ?? expert.SpecialtyInRiskGovernance;
        expert.YearsOfExperience = dto.YearsOfExperience ?? expert.YearsOfExperience;
        expert.Institution = dto.Institution ?? expert.Institution;
        expert.Position = dto.Position ?? expert.Position;
        expert.Country = dto.Country ?? expert.Country;
        expert.City = dto.City ?? expert.City;
        expert.Bio = dto.Bio ?? expert.Bio;
        expert.LinkedinUrl = dto.LinkedinUrl ?? expert.LinkedinUrl;
        expert.Website = dto.Website ?? expert.Website;
        expert.CvFileUrl = dto.CvFileUrl ?? expert.CvFileUrl;
        expert.IsAvailable = dto.IsAvailable ?? expert.IsAvailable;
        expert.AvailableForConsulting = dto.AvailableForConsulting ?? expert.AvailableForConsulting;
        expert.AvailableForTraining = dto.AvailableForTraining ?? expert.AvailableForTraining;
        expert.AvailableForResearch = dto.AvailableForResearch ?? expert.AvailableForResearch;
        expert.IsActive = dto.IsActive;
        expert.IsPublic = dto.IsPublic;
        expert.UpdatedAt = DateTime.UtcNow;

        await _repository.UpdateExpertAsync(expert);
    }

    public async Task DeleteExpert(Guid id)
    {
        await _repository.DeleteExpertAsync(id);
    }

    private ExpertResponseDto MapToResponseDto(Experts expert)
    {
        return new ExpertResponseDto
        {
            Id = expert.Id,
            FullName = expert.FullName,
            Email = expert.Email,
            Phone = expert.Phone,
            PhotoUrl = expert.PhotoUrl,
            Title = expert.Title,
            Organization = expert.Organization,
            ExpertiseAreas = expert.ExpertiseAreas,
            Specialties = expert.Specialties,
            SpecialtyInRiskGovernance = expert.SpecialtyInRiskGovernance,
            YearsOfExperience = expert.YearsOfExperience,
            Institution = expert.Institution,
            Position = expert.Position,
            Country = expert.Country,
            City = expert.City,
            Bio = expert.Bio,
            LinkedinUrl = expert.LinkedinUrl,
            Website = expert.Website,
            CvFileUrl = expert.CvFileUrl,
            IsAvailable = expert.IsAvailable,
            AvailableForConsulting = expert.AvailableForConsulting,
            AvailableForTraining = expert.AvailableForTraining,
            AvailableForResearch = expert.AvailableForResearch,
            IsActive = expert.IsActive,
            IsPublic = expert.IsPublic,
            CreatedAt = expert.CreatedAt,
            UpdatedAt = expert.UpdatedAt
        };
    }
}
