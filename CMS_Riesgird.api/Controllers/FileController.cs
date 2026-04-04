using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Minio;
using Minio.DataModel.Args;

namespace CMS_Riesgird.api.Controllers
{   
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        IMinioClient _minioClient;

        public FileController()
        {
            _minioClient = new MinioClient()
                .WithEndpoint("cdn.menfroyt-dev.com")
                .WithCredentials("menfroyt", "JamesFrank9999")
                .WithSSL(false)
                .Build();
        }

        [HttpPost]
        public async Task<IActionResult> Uplaod(IFormFile file)
        {
            try
            {
                var response = await _minioClient.PutObjectAsync(new PutObjectArgs()
                     .WithBucket("riesgridpanel")
                     .WithObject(file.FileName)
                     .WithStreamData(file.OpenReadStream())
                     .WithObjectSize(file.Length));
                if (response.ResponseStatusCode == System.Net.HttpStatusCode.OK)
                {
                    return Ok("File has been uploaded.");
                }
                return BadRequest("File upload failed.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        public async Task<IActionResult> Download(string fileName)
        {
            try
            {
                var steam = new MemoryStream();
                await _minioClient.GetObjectAsync(new GetObjectArgs()
                    .WithBucket("test")
                    .WithObject(fileName)
                    .WithCallbackStream((dataSteam) => dataSteam.CopyTo(steam)));

                steam.Position = 0;

                return File(steam, "application/octet-stream", fileName);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetDownloadLink(string fileName)
        {
            try
            {
                var fileLink = await _minioClient.PresignedGetObjectAsync(new PresignedGetObjectArgs()
                    .WithBucket("test")
                    .WithObject(fileName)
                    .WithExpiry(60 * 60)
                    );
                return Ok(fileLink);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}