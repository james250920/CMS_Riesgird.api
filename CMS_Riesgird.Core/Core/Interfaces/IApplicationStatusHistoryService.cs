using CMS_Riesgird.Core.Core.DTOs;

namespace CMS_Riesgird.Core.Core.Interfaces;

public interface IApplicationStatusHistoryService
{
    Task<IEnumerable<ApplicationStatusHistoryResponseDto>> GetAllHistories();
    Task<ApplicationStatusHistoryResponseDto?> GetHistoryById(Guid id);
    Task<IEnumerable<ApplicationStatusHistoryResponseDto>> GetHistoriesByApplicationId(Guid applicationId);
    Task<IEnumerable<ApplicationStatusHistoryResponseDto>> GetHistoriesByStatus(string status);
    Task<Guid> CreateHistory(CreateApplicationStatusHistoryDto dto);
    Task UpdateHistory(Guid id, UpdateApplicationStatusHistoryDto dto);
    Task DeleteHistory(Guid id);
}
