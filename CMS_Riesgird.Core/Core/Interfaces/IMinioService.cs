using Microsoft.AspNetCore.Http;

namespace CMS_Riesgird.Core.Core.Interfaces
{
    public interface IMinioService
    {
        Task<string> UploadFileAsync(IFormFile file, string folder);
        Task DeleteFileAsync(string fileUrl);
        Task<byte[]> DownloadFileAsync(string folder, string fileName);
        Task<string> GetDownloadLinkAsync(string folder, string fileName, int expiryInSeconds = 1800);
        string GetPublicUrl(string folder, string fileName);
        Task<string> UpdateFileAsync(string fileUrl, IFormFile newFile, string folder);
    }
}