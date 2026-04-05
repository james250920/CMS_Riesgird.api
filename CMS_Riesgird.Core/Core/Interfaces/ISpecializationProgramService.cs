using CMS_Riesgird.Core.Core.DTOs;

namespace CMS_Riesgird.Core.Core.Interfaces;

public interface ISpecializationProgramService
{
    Task<IEnumerable<SpecializationProgramResponseDto>> GetAllPrograms();
    Task<SpecializationProgramResponseDto?> GetProgramById(Guid id);
    Task<IEnumerable<SpecializationProgramResponseDto>> GetPublicPrograms();
    Task<IEnumerable<SpecializationProgramResponseDto>> GetOpenEnrollmentPrograms();
    Task<IEnumerable<SpecializationProgramResponseDto>> GetUpcomingPrograms();
    Task<IEnumerable<SpecializationProgramResponseDto>> GetProgramsByUniversity(string university);
    Task<Guid> CreateProgram(CreateSpecializationProgramDto dto);
    Task UpdateProgram(Guid id, UpdateSpecializationProgramDto dto);
    Task DeleteProgram(Guid id);
}
