using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Core.Services;

public class DownloadableTemplateService : IDownloadableTemplateService
{
    private readonly IDownloadableTemplateRepository _repository;

    public DownloadableTemplateService(IDownloadableTemplateRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<DownloadableTemplateResponseDto>> GetAllTemplates()
    {
        var templates = await _repository.GetAllTemplatesAsync();
        return templates.Select(t => MapToResponseDto(t));
    }

    public async Task<DownloadableTemplateResponseDto?> GetTemplateById(Guid id)
    {
        var template = await _repository.GetTemplateByIdAsync(id);
        if (template == null)
            return null;

        return MapToResponseDto(template);
    }

    public async Task<IEnumerable<DownloadableTemplateResponseDto>> GetActiveTemplates()
    {
        var templates = await _repository.GetActiveTemplatesAsync();
        return templates.Select(t => MapToResponseDto(t));
    }

    public async Task<IEnumerable<DownloadableTemplateResponseDto>> GetTemplatesByVersion(string version)
    {
        var templates = await _repository.GetTemplatesByVersionAsync(version);
        return templates.Select(t => MapToResponseDto(t));
    }

    public async Task<Guid> CreateTemplate(CreateDownloadableTemplateDto dto)
    {
        var template = new DownloadableTemplates
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Description = dto.Description,
            FileUrl = dto.FileUrl,
            FileName = dto.FileName,
            FileSize = dto.FileSize,
            Version = dto.Version,
            DownloadCount = 0,
            UploadDate = DateTime.UtcNow,
            IsActive = dto.IsActive
        };

        await _repository.AddTemplateAsync(template);
        return template.Id;
    }

    public async Task UpdateTemplate(Guid id, UpdateDownloadableTemplateDto dto)
    {
        var template = await _repository.GetTemplateByIdAsync(id);
        if (template == null)
            throw new Exception("Plantilla no encontrada");

        template.Name = dto.Name ?? template.Name;
        template.Description = dto.Description ?? template.Description;
        template.FileUrl = dto.FileUrl ?? template.FileUrl;
        template.FileName = dto.FileName ?? template.FileName;
        template.FileSize = dto.FileSize ?? template.FileSize;
        template.Version = dto.Version ?? template.Version;
        template.IsActive = dto.IsActive;

        await _repository.UpdateTemplateAsync(template);
    }

    public async Task DeleteTemplate(Guid id)
    {
        await _repository.DeleteTemplateAsync(id);
    }

    public async Task RecordDownloadAsync(Guid id)
    {
        await _repository.IncrementDownloadCountAsync(id);
    }

    private DownloadableTemplateResponseDto MapToResponseDto(DownloadableTemplates template)
    {
        return new DownloadableTemplateResponseDto
        {
            Id = template.Id,
            Name = template.Name,
            Description = template.Description,
            FileUrl = template.FileUrl,
            FileName = template.FileName,
            FileSize = template.FileSize,
            Version = template.Version,
            DownloadCount = template.DownloadCount,
            UploadDate = template.UploadDate,
            IsActive = template.IsActive
        };
    }
}
