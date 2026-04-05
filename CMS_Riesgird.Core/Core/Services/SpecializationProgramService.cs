using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Core.Services;

public class SpecializationProgramService : ISpecializationProgramService
{
    private readonly ISpecializationProgramRepository _repository;

    public SpecializationProgramService(ISpecializationProgramRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<SpecializationProgramResponseDto>> GetAllPrograms()
    {
        var programs = await _repository.GetAllProgramsAsync();
        return programs.Select(p => MapToResponseDto(p));
    }

    public async Task<SpecializationProgramResponseDto?> GetProgramById(Guid id)
    {
        var program = await _repository.GetProgramByIdAsync(id);
        if (program == null)
            return null;

        return MapToResponseDto(program);
    }

    public async Task<IEnumerable<SpecializationProgramResponseDto>> GetPublicPrograms()
    {
        var programs = await _repository.GetPublicProgramsAsync();
        return programs.Select(p => MapToResponseDto(p));
    }

    public async Task<IEnumerable<SpecializationProgramResponseDto>> GetOpenEnrollmentPrograms()
    {
        var programs = await _repository.GetOpenEnrollmentProgramsAsync();
        return programs.Select(p => MapToResponseDto(p));
    }

    public async Task<IEnumerable<SpecializationProgramResponseDto>> GetUpcomingPrograms()
    {
        var programs = await _repository.GetUpcomingProgramsAsync();
        return programs.Select(p => MapToResponseDto(p));
    }

    public async Task<IEnumerable<SpecializationProgramResponseDto>> GetProgramsByUniversity(string university)
    {
        var programs = await _repository.GetProgramsByUniversityAsync(university);
        return programs.Select(p => MapToResponseDto(p));
    }

    public async Task<Guid> CreateProgram(CreateSpecializationProgramDto dto)
    {
        var program = new SpecializationPrograms
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Description = dto.Description,
            Objectives = dto.Objectives,
            Duration = dto.Duration,
            Credits = dto.Credits,
            TargetAudience = dto.TargetAudience,
            Requirements = dto.Requirements,
            Price = dto.Price,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate,
            RegistrationDeadline = dto.RegistrationDeadline,
            EnrollmentOpen = dto.EnrollmentOpen,
            GraduatesCount = dto.GraduatesCount,
            OrganizingUniversities = dto.OrganizingUniversities,
            Coordinator = dto.Coordinator,
            ImageUrl = dto.ImageUrl,
            SyllabusFileUrl = dto.SyllabusFileUrl,
            BrochureFileUrl = dto.BrochureFileUrl,
            RegistrationUrl = dto.RegistrationUrl,
            IsPublic = dto.IsPublic,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        await _repository.AddProgramAsync(program);
        return program.Id;
    }

    public async Task UpdateProgram(Guid id, UpdateSpecializationProgramDto dto)
    {
        var program = await _repository.GetProgramByIdAsync(id);
        if (program == null)
            throw new Exception("Programa de especialización no encontrado");

        program.Name = dto.Name ?? program.Name;
        program.Description = dto.Description ?? program.Description;
        program.Objectives = dto.Objectives ?? program.Objectives;
        program.Duration = dto.Duration ?? program.Duration;
        program.Credits = dto.Credits ?? program.Credits;
        program.TargetAudience = dto.TargetAudience ?? program.TargetAudience;
        program.Requirements = dto.Requirements ?? program.Requirements;
        program.Price = dto.Price ?? program.Price;
        program.StartDate = dto.StartDate ?? program.StartDate;
        program.EndDate = dto.EndDate ?? program.EndDate;
        program.RegistrationDeadline = dto.RegistrationDeadline ?? program.RegistrationDeadline;
        program.EnrollmentOpen = dto.EnrollmentOpen ?? program.EnrollmentOpen;
        program.GraduatesCount = dto.GraduatesCount ?? program.GraduatesCount;
        program.OrganizingUniversities = dto.OrganizingUniversities ?? program.OrganizingUniversities;
        program.Coordinator = dto.Coordinator ?? program.Coordinator;
        program.ImageUrl = dto.ImageUrl ?? program.ImageUrl;
        program.SyllabusFileUrl = dto.SyllabusFileUrl ?? program.SyllabusFileUrl;
        program.BrochureFileUrl = dto.BrochureFileUrl ?? program.BrochureFileUrl;
        program.RegistrationUrl = dto.RegistrationUrl ?? program.RegistrationUrl;
        program.IsPublic = dto.IsPublic;
        program.UpdatedAt = DateTime.UtcNow;

        await _repository.UpdateProgramAsync(program);
    }

    public async Task DeleteProgram(Guid id)
    {
        await _repository.DeleteProgramAsync(id);
    }

    private SpecializationProgramResponseDto MapToResponseDto(SpecializationPrograms program)
    {
        return new SpecializationProgramResponseDto
        {
            Id = program.Id,
            Name = program.Name,
            Description = program.Description,
            Objectives = program.Objectives,
            Duration = program.Duration,
            Credits = program.Credits,
            TargetAudience = program.TargetAudience,
            Requirements = program.Requirements,
            Price = program.Price,
            StartDate = program.StartDate,
            EndDate = program.EndDate,
            RegistrationDeadline = program.RegistrationDeadline,
            EnrollmentOpen = program.EnrollmentOpen,
            GraduatesCount = program.GraduatesCount,
            OrganizingUniversities = program.OrganizingUniversities,
            Coordinator = program.Coordinator,
            ImageUrl = program.ImageUrl,
            SyllabusFileUrl = program.SyllabusFileUrl,
            BrochureFileUrl = program.BrochureFileUrl,
            RegistrationUrl = program.RegistrationUrl,
            IsPublic = program.IsPublic,
            CreatedAt = program.CreatedAt,
            UpdatedAt = program.UpdatedAt
        };
    }
}
