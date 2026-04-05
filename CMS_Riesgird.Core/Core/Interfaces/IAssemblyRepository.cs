using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Core.Interfaces;

public interface IAssemblyRepository
{
    Task<IEnumerable<Assemblies>> GetAllAssembliesAsync();
    Task<Assemblies?> GetAssemblyByIdAsync(Guid id);
    Task<IEnumerable<Assemblies>> GetAssembliesByYearAsync(int year);
    Task<IEnumerable<Assemblies>> GetPublicAssembliesAsync();
    Task AddAssemblyAsync(Assemblies assembly);
    Task UpdateAssemblyAsync(Assemblies assembly);
    Task DeleteAssemblyAsync(Guid id);
}
