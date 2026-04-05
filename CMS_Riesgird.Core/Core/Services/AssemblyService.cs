using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Core.Services;

public class AssemblyService : IAssemblyService
{
    private readonly IAssemblyRepository _repository;

    public AssemblyService(IAssemblyRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<AssemblyResponseDto>> GetAllAssemblies()
    {
        var assemblies = await _repository.GetAllAssembliesAsync();
        return assemblies.Select(a => MapToResponseDto(a));
    }

    public async Task<AssemblyResponseDto?> GetAssemblyById(Guid id)
    {
        var assembly = await _repository.GetAssemblyByIdAsync(id);
        if (assembly == null)
            return null;

        return MapToResponseDto(assembly);
    }

    public async Task<IEnumerable<AssemblyResponseDto>> GetAssembliesByYear(int year)
    {
        var assemblies = await _repository.GetAssembliesByYearAsync(year);
        return assemblies.Select(a => MapToResponseDto(a));
    }

    public async Task<IEnumerable<AssemblyResponseDto>> GetPublicAssemblies()
    {
        var assemblies = await _repository.GetPublicAssembliesAsync();
        return assemblies.Select(a => MapToResponseDto(a));
    }

    public async Task<Guid> CreateAssembly(CreateAssemblyDto dto)
    {
        var assembly = new Assemblies
        {
            Id = Guid.NewGuid(),
            Year = dto.Year,
            Number = dto.Number,
            Title = dto.Title,
            Description = dto.Description,
            Date = dto.Date,
            Location = dto.Location,
            VirtualLink = dto.VirtualLink,
            AgendaFileUrl = dto.AgendaFileUrl,
            AgendaFileName = dto.AgendaFileName,
            AgreementsFileUrl = dto.AgreementsFileUrl,
            AgreementsFileName = dto.AgreementsFileName,
            ConvocationUrl = dto.ConvocationUrl,
            MinutesUrl = dto.MinutesUrl,
            MinutesFileUrl = dto.MinutesFileUrl,
            MinutesFileName = dto.MinutesFileName,
            AttendeesCount = dto.AttendeesCount,
            IsPublic = dto.IsPublic,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        await _repository.AddAssemblyAsync(assembly);
        return assembly.Id;
    }

    public async Task UpdateAssembly(Guid id, UpdateAssemblyDto dto)
    {
        var assembly = await _repository.GetAssemblyByIdAsync(id);
        if (assembly == null)
            throw new Exception("Asamblea no encontrada");

        assembly.Year = dto.Year;
        assembly.Number = dto.Number;
        assembly.Title = dto.Title ?? assembly.Title;
        assembly.Description = dto.Description ?? assembly.Description;
        assembly.Date = dto.Date;
        assembly.Location = dto.Location ?? assembly.Location;
        assembly.VirtualLink = dto.VirtualLink ?? assembly.VirtualLink;
        assembly.AgendaFileUrl = dto.AgendaFileUrl ?? assembly.AgendaFileUrl;
        assembly.AgendaFileName = dto.AgendaFileName ?? assembly.AgendaFileName;
        assembly.AgreementsFileUrl = dto.AgreementsFileUrl ?? assembly.AgreementsFileUrl;
        assembly.AgreementsFileName = dto.AgreementsFileName ?? assembly.AgreementsFileName;
        assembly.ConvocationUrl = dto.ConvocationUrl ?? assembly.ConvocationUrl;
        assembly.MinutesUrl = dto.MinutesUrl ?? assembly.MinutesUrl;
        assembly.MinutesFileUrl = dto.MinutesFileUrl ?? assembly.MinutesFileUrl;
        assembly.MinutesFileName = dto.MinutesFileName ?? assembly.MinutesFileName;
        assembly.AttendeesCount = dto.AttendeesCount ?? assembly.AttendeesCount;
        assembly.IsPublic = dto.IsPublic;
        assembly.UpdatedAt = DateTime.UtcNow;

        await _repository.UpdateAssemblyAsync(assembly);
    }

    public async Task DeleteAssembly(Guid id)
    {
        await _repository.DeleteAssemblyAsync(id);
    }

    private AssemblyResponseDto MapToResponseDto(Assemblies assembly)
    {
        return new AssemblyResponseDto
        {
            Id = assembly.Id,
            Year = assembly.Year,
            Number = assembly.Number,
            Title = assembly.Title,
            Description = assembly.Description,
            Date = assembly.Date,
            Location = assembly.Location,
            VirtualLink = assembly.VirtualLink,
            AgendaFileUrl = assembly.AgendaFileUrl,
            AgendaFileName = assembly.AgendaFileName,
            AgreementsFileUrl = assembly.AgreementsFileUrl,
            AgreementsFileName = assembly.AgreementsFileName,
            ConvocationUrl = assembly.ConvocationUrl,
            MinutesUrl = assembly.MinutesUrl,
            MinutesFileUrl = assembly.MinutesFileUrl,
            MinutesFileName = assembly.MinutesFileName,
            AttendeesCount = assembly.AttendeesCount,
            IsPublic = assembly.IsPublic,
            CreatedAt = assembly.CreatedAt,
            UpdatedAt = assembly.UpdatedAt
        };
    }
}
