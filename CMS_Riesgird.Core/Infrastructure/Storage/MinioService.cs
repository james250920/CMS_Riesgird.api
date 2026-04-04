using CMS_Riesgird.Core.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Minio;
using Minio.DataModel.Args;
using System.Net;

namespace CMS_Riesgird.Core.Infrastructure.Storage
{
    public class MinioService : IMinioService
    {
        
        
        private readonly IMinioClient _minioClient;
        private readonly string _bucket;
        private readonly string _viewpoint;
        private readonly ILogger<MinioService> _logger;

        public MinioService(IConfiguration config, ILogger<MinioService> logger)
        {
            _logger = logger;
            _bucket = config["Minio:Bucket"]!;
            _viewpoint = config["Minio:Viewpoint"]!.TrimEnd('/');

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            var endpoint = config["Minio:Endpoint"]!;
            var accessKey = config["Minio:AccessKey"]!;
            var secretKey = config["Minio:SecretKey"]!;
            var useSSL = config.GetValue<bool>("Minio:UseSSL", false);

            _logger.LogInformation("MinIO configurado -> Endpoint: {Endpoint}, Bucket: {Bucket}, SSL: {SSL}",
                endpoint, _bucket, useSSL);

            var client = new MinioClient()
                .WithEndpoint(endpoint)
                .WithCredentials(accessKey, secretKey);

            if (useSSL)
                client = client.WithSSL();

            _minioClient = client.Build();
        }

        public async Task<string> UploadFileAsync(IFormFile file, string folder)
        {
            await EnsureBucketExistsAsync();

            var shortGuid = Guid.NewGuid().ToString("N").Substring(0, 4);
            var objectName = $"{folder}/{shortGuid}-{file.FileName}";
            var contentType = file.ContentType ?? "application/octet-stream";

            _logger.LogInformation("Subiendo archivo: {ObjectName} al bucket: {Bucket} con ContentType: {ContentType}",
                objectName, _bucket, contentType);

            using var stream = file.OpenReadStream();

            await _minioClient.PutObjectAsync(new PutObjectArgs()
                .WithBucket(_bucket)
                .WithObject(objectName)
                .WithStreamData(stream)
                .WithObjectSize(file.Length)
                .WithContentType(contentType));

            var url = $"{_viewpoint}/{_bucket}/{objectName}";

            _logger.LogInformation("Archivo subido correctamente: {Url}", url);
            return url;
        }

        public async Task DeleteFileAsync(string fileUrl)
        {
            var key = ExtractKeyFromUrl(fileUrl);

            _logger.LogInformation("Eliminando archivo: {Key} del bucket: {Bucket}", key, _bucket);

            var removeArgs = new RemoveObjectArgs()
                .WithBucket(_bucket)
                .WithObject(key);

            await _minioClient.RemoveObjectAsync(removeArgs);
        }

        public async Task<byte[]> DownloadFileAsync(string folder, string fileName)
        {
            var objectName = $"{folder}/{fileName}";

            _logger.LogInformation("Descargando archivo: {ObjectName} del bucket: {Bucket}", objectName, _bucket);

            using var stream = new MemoryStream();

            var getArgs = new GetObjectArgs()
                .WithBucket(_bucket)
                .WithObject(objectName)
                .WithCallbackStream(async (dataStream, ct) =>
                {
                    await dataStream.CopyToAsync(stream, ct);
                });

            await _minioClient.GetObjectAsync(getArgs);

            return stream.ToArray();
        }

        public async Task<string> GetDownloadLinkAsync(string folder, string fileName, int expiryInSeconds = 1800)
        {
            var objectName = $"{folder}/{fileName}";

            var presignedArgs = new PresignedGetObjectArgs()
                .WithBucket(_bucket)
                .WithObject(objectName)
                .WithExpiry(expiryInSeconds);

            var link = await _minioClient.PresignedGetObjectAsync(presignedArgs);

            _logger.LogInformation("Link generado para: {ObjectName} -> {Link}", objectName, link);
            return link;
        }

        public string GetPublicUrl(string folder, string fileName)
        {
            var url = $"{_viewpoint}/{_bucket}/{folder}/{fileName}";
            _logger.LogInformation("URL pública generada: {Url}", url);
            return url;
        }

        public async Task<string> UpdateFileAsync(string fileUrl, IFormFile newFile, string folder)
        {
            await DeleteFileAsync(fileUrl);
            var newUrl = await UploadFileAsync(newFile, folder);
            return newUrl;
        }

        private string ExtractKeyFromUrl(string fileUrl)
        {
            var prefix = $"{_viewpoint}/{_bucket}/";
            if (fileUrl.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                return fileUrl[prefix.Length..];

            return fileUrl;
        }

        private async Task EnsureBucketExistsAsync()
        {
            var bucketExistsArgs = new BucketExistsArgs()
                .WithBucket(_bucket);

            bool found = await _minioClient.BucketExistsAsync(bucketExistsArgs);

            _logger.LogInformation("Bucket '{Bucket}' existe: {Found}", _bucket, found);

            if (!found)
            {
                var makeBucketArgs = new MakeBucketArgs()
                    .WithBucket(_bucket);

                await _minioClient.MakeBucketAsync(makeBucketArgs);
                _logger.LogInformation("Bucket '{Bucket}' creado", _bucket);
            }
        }
    }
}
