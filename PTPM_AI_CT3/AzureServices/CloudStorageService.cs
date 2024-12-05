using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTPM_AI_CT3.AzureServices
{
    public class CloudStorageService
    {
        private readonly string ConnectionString;
        private readonly string BlobContainerName;
        private readonly string BlobUrl;

        private readonly BlobServiceClient BlobServiceClient;
        private readonly BlobContainerClient ContainerClient;

        public CloudStorageService()
        {
            BlobServiceClient = new BlobServiceClient(ConnectionString);
            ContainerClient = BlobServiceClient.GetBlobContainerClient(BlobContainerName);

        }

        public string GetContainerName()
        {
            return BlobContainerName;
        }
        public string GetBlobUrl()
        {
            return BlobUrl;
        }

        public async Task<string> UploadImage(string imagePath, byte[] imageBytes)
        {
            BlobClient blobClient = ContainerClient.GetBlobClient(imagePath);
            BlobContentInfo info = await blobClient.UploadAsync(new MemoryStream(imageBytes), true);
            if (!string.IsNullOrEmpty(info.ETag.ToString()))
            {
                return $"{BlobUrl}/{BlobContainerName}/{imagePath}";
            }


            return null;
        }

        public async Task<bool> DeleteImage(string imageUrl)
        {
            BlobClient blobClient = ContainerClient.GetBlobClient(imageUrl.Replace($"{BlobUrl}/{BlobContainerName}/", ""));
            return await blobClient.DeleteIfExistsAsync();
        }

        public AsyncPageable<BlobItem> GetBlobs(string folderName)
        {
            AsyncPageable<BlobItem> blobs = ContainerClient.GetBlobsAsync(prefix: folderName);
            return blobs;
        }
    }
}
