using CMS_Riesgird.Core.Core.DTOs;

namespace CMS_Riesgird.Core.Core.Interfaces;

public interface IResearcherService
{
    Task<IEnumerable<ResearcherResponseDto>> GetAllResearchers();
    Task<ResearcherResponseDto?> GetResearcherById(Guid id);
    Task<IEnumerable<ResearcherResponseDto>> GetResearchersByUniversityId(Guid universityId);
    Task<IEnumerable<ResearcherResponseDto>> GetPublicResearchers();
    Task<IEnumerable<ResearcherResponseDto>> GetResearchersByResearchArea(string researchArea);
    Task<IEnumerable<ResearcherResponseDto>> GetActiveResearchers();
    Task<Guid> CreateResearcher(CreateResearcherDto dto);
    Task UpdateResearcher(Guid id, UpdateResearcherDto dto);
    Task DeleteResearcher(Guid id);
}
