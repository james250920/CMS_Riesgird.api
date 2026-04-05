using CMS_Riesgird.Core.Core.DTOs;

namespace CMS_Riesgird.Core.Core.Interfaces;

public interface IDownloadableTemplateService
{
    Task<IEnumerable<DownloadableTemplateResponseDto>> GetAllTemplates();
    Task<DownloadableTemplateResponseDto?> GetTemplateById(Guid id);
    Task<IEnumerable<DownloadableTemplateResponseDto>> GetActiveTemplates();
    Task<IEnumerable<DownloadableTemplateResponseDto>> GetTemplatesByVersion(string version);
    Task<Guid> CreateTemplate(CreateDownloadableTemplateDto dto);
    Task UpdateTemplate(Guid id, UpdateDownloadableTemplateDto dto);
    Task DeleteTemplate(Guid id);
    Task RecordDownloadAsync(Guid id);
}
