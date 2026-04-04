using Microsoft.AspNetCore.Mvc;
using CMS_Riesgird.Core.Core.Interfaces;

namespace CMS_Riesgird.api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FileDocController : ControllerBase
    {
        private readonly IMinioService _minioService;
        private const string Folder = "documentos";

        public FileDocController(IMinioService minioService)
        {
            _minioService = minioService;
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                    return BadRequest(new { success = false, message = "Documento inválido" });

                var url = await _minioService.UploadFileAsync(file, Folder);
                Console.WriteLine($"Archivo subido: {url}");
                return Ok(new { success = true, url });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] string fileUrl)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(fileUrl))
                    return BadRequest(new { success = false, message = "URL del documento es requerida" });

                await _minioService.DeleteFileAsync(fileUrl);

                return Ok(new { success = true, message = "Documento eliminado correctamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Download([FromQuery] string fileName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(fileName))
                    return BadRequest(new { success = false, message = "Nombre del documento es requerido" });

                var fileBytes = await _minioService.DownloadFileAsync(Folder, fileName);

                return File(fileBytes, "application/octet-stream", fileName);
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetDownloadLink([FromQuery] string fileName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(fileName))
                    return BadRequest(new { success = false, message = "Nombre del documento es requerido" });

                var link = await _minioService.GetDownloadLinkAsync(Folder, fileName);

                return Ok(new { success = true, url = link });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetPublicUrl([FromQuery] string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                return BadRequest(new { success = false, message = "Nombre del documento es requerido" });

            var url = _minioService.GetPublicUrl(Folder, fileName);
            return Ok(new { success = true, url });
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] string fileUrl, IFormFile newFile)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(fileUrl))
                    return BadRequest(new { success = false, message = "URL del documento es requerida" });

                if (newFile == null || newFile.Length == 0)
                    return BadRequest(new { success = false, message = "Nuevo documento inválido" });

                var newUrl = await _minioService.UpdateFileAsync(fileUrl, newFile, Folder);

                return Ok(new { success = true, url = newUrl });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }
    }
}
