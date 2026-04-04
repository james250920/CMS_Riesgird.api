using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CMS_Riesgird.Core.Core.Interfaces;

namespace CMS_Riesgird.api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FileImgController : ControllerBase
    {
        private readonly IMinioService _minioService;
        private const string Folder = "img";

        public FileImgController(IMinioService minioService)
        {
            _minioService = minioService;
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                    return BadRequest(new { success = false, message = "Imagen inválida" });

                var url = await _minioService.UploadFileAsync(file, Folder);

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
                    return BadRequest(new { success = false, message = "URL de la imagen es requerida" });

                await _minioService.DeleteFileAsync(fileUrl);

                return Ok(new { success = true, message = "Imagen eliminada correctamente" });
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
                    return BadRequest(new { success = false, message = "Nombre de la imagen es requerido" });

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
                    return BadRequest(new { success = false, message = "Nombre de la imagen es requerido" });

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
                return BadRequest(new { success = false, message = "Nombre de la imagen es requerido" });

            var url = _minioService.GetPublicUrl(Folder, fileName);
            return Ok(new { success = true, url });
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] string fileUrl, IFormFile newFile)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(fileUrl))
                    return BadRequest(new { success = false, message = "URL de la imagen es requerida" });

                if (newFile == null || newFile.Length == 0)
                    return BadRequest(new { success = false, message = "Nueva imagen inválida" });

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
