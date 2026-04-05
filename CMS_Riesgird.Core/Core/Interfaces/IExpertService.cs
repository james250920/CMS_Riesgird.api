using CMS_Riesgird.Core.Core.DTOs;

namespace CMS_Riesgird.Core.Core.Interfaces;

public interface IExpertService
{
    Task<IEnumerable<ExpertResponseDto>> GetAllExperts();
    Task<ExpertResponseDto?> GetExpertById(Guid id);
    Task<IEnumerable<ExpertResponseDto>> GetPublicExperts();
    Task<IEnumerable<ExpertResponseDto>> GetActiveExperts();
    Task<IEnumerable<ExpertResponseDto>> GetExpertsByExpertiseArea(string expertiseArea);
    Task<IEnumerable<ExpertResponseDto>> GetExpertsByCountry(string country);
    Task<IEnumerable<ExpertResponseDto>> GetAvailableExperts();
    Task<IEnumerable<ExpertResponseDto>> GetExpertsAvailableForConsulting();
    Task<IEnumerable<ExpertResponseDto>> GetExpertsAvailableForTraining();
    Task<IEnumerable<ExpertResponseDto>> GetExpertsAvailableForResearch();
    Task<Guid> CreateExpert(CreateExpertDto dto);
    Task UpdateExpert(Guid id, UpdateExpertDto dto);
    Task DeleteExpert(Guid id);
}
