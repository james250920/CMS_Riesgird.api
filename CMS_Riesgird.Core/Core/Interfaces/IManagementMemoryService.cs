using CMS_Riesgird.Core.Core.DTOs;

namespace CMS_Riesgird.Core.Core.Interfaces;

public interface IManagementMemoryService
{
    Task<IEnumerable<ManagementMemoryResponseDto>> GetAllMemories();
    Task<ManagementMemoryResponseDto?> GetMemoryById(Guid id);
    Task<IEnumerable<ManagementMemoryResponseDto>> GetPublicMemories();
    Task<IEnumerable<ManagementMemoryResponseDto>> GetMemoriesByYear(int year);
    Task<IEnumerable<ManagementMemoryResponseDto>> GetMemoriesByPeriod(string period);
    Task<ManagementMemoryResponseDto?> GetLatestMemory();
    Task<Guid> CreateMemory(CreateManagementMemoryDto dto);
    Task UpdateMemory(Guid id, UpdateManagementMemoryDto dto);
    Task DeleteMemory(Guid id);
}
