using CMS_Riesgird.Domain.Models;

namespace CMS_Riesgird.Core.Core.Interfaces;

public interface IDownloadableTemplateRepository
{
    Task<IEnumerable<DownloadableTemplates>> GetAllTemplatesAsync();
    Task<DownloadableTemplates?> GetTemplateByIdAsync(Guid id);
    Task<IEnumerable<DownloadableTemplates>> GetActiveTemplatesAsync();
    Task<IEnumerable<DownloadableTemplates>> GetTemplatesByVersionAsync(string version);
    Task AddTemplateAsync(DownloadableTemplates template);
    Task UpdateTemplateAsync(DownloadableTemplates template);
    Task DeleteTemplateAsync(Guid id);
    Task IncrementDownloadCountAsync(Guid id);
}
