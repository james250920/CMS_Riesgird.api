using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Core.Interfaces;

public interface ISpecializationProgramRepository
{
    Task<IEnumerable<SpecializationPrograms>> GetAllProgramsAsync();
    Task<SpecializationPrograms?> GetProgramByIdAsync(Guid id);
    Task<IEnumerable<SpecializationPrograms>> GetPublicProgramsAsync();
    Task<IEnumerable<SpecializationPrograms>> GetOpenEnrollmentProgramsAsync();
    Task<IEnumerable<SpecializationPrograms>> GetUpcomingProgramsAsync();
    Task<IEnumerable<SpecializationPrograms>> GetProgramsByUniversityAsync(string university);
    Task AddProgramAsync(SpecializationPrograms program);
    Task UpdateProgramAsync(SpecializationPrograms program);
    Task DeleteProgramAsync(Guid id);
}
