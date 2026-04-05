using CMS_Riesgird.Core.Core.DTOs;

namespace CMS_Riesgird.Core.Core.Interfaces;

public interface IAssemblyService
{
    Task<IEnumerable<AssemblyResponseDto>> GetAllAssemblies();
    Task<AssemblyResponseDto?> GetAssemblyById(Guid id);
    Task<IEnumerable<AssemblyResponseDto>> GetAssembliesByYear(int year);
    Task<IEnumerable<AssemblyResponseDto>> GetPublicAssemblies();
    Task<Guid> CreateAssembly(CreateAssemblyDto dto);
    Task UpdateAssembly(Guid id, UpdateAssemblyDto dto);
    Task DeleteAssembly(Guid id);
}
