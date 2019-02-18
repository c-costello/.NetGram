using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetGram.Models.Util
{
    public class Blob
    {
        public CloudStorageAccount CloudStorageAccount { get; set; }
        public CloudBlobClient CloudBlobClient { get; set; }

        public Blob(IConfiguration configuration)
        {
            CloudStorageAccount = CloudStorageAccount.Parse(configuration["BlobConnectionString"]);
            CloudBlobClient = CloudStorageAccount.CreateCloudBlobClient();
        }

        //Get Container
        public async Task<CloudBlobContainer> GetContainer(string containerName)
        {
            CloudBlobContainer cbc = CloudBlobClient.GetContainerReference(containerName);
            await cbc.CreateIfNotExistsAsync();
            await cbc.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });

            return cbc;
        }
        //Get Blob
        public async Task<CloudBlob> GetBlob(string imageName, string containerName)
        {
            CloudBlobContainer container = await GetContainer(containerName);

            CloudBlob blob = container.GetBlobReference(imageName);

            return blob;
        }

        public async Task UploadImage(CloudBlobContainer cloudBlobContainer, string fileName, string filePath)
        {
            var blobFile = cloudBlobContainer.GetBlockBlobReference(fileName);
            await blobFile.UploadFromFileAsync(filePath);
        }
    }
}
