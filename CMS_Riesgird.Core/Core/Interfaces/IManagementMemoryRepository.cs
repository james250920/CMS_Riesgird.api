using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Core.Interfaces;

public interface IManagementMemoryRepository
{
    Task<IEnumerable<ManagementMemories>> GetAllMemoriesAsync();
    Task<ManagementMemories?> GetMemoryByIdAsync(Guid id);
    Task<IEnumerable<ManagementMemories>> GetPublicMemoriesAsync();
    Task<IEnumerable<ManagementMemories>> GetMemoriesByYearAsync(int year);
    Task<IEnumerable<ManagementMemories>> GetMemoriesByPeriodAsync(string period);
    Task<ManagementMemories?> GetLatestMemoryAsync();
    Task AddMemoryAsync(ManagementMemories memory);
    Task UpdateMemoryAsync(ManagementMemories memory);
    Task DeleteMemoryAsync(Guid id);
}
