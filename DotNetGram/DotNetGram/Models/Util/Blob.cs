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

        /// <summary>
        /// Set Configuration
        /// </summary>
        /// <param name="configuration">IConfiguration</param>
        public Blob(IConfiguration configuration)
        {
            CloudStorageAccount = CloudStorageAccount.Parse(configuration["ConnectionStrings:BlobConnectionString"]);
            CloudBlobClient = CloudStorageAccount.CreateCloudBlobClient();
        }

        /// <summary>
        /// Get Container
        /// </summary>
        /// <param name="containerName">string</param>
        /// <returns>Task\<CloudBlobContainer\></returns>
        public async Task<CloudBlobContainer> GetContainer(string containerName)
        {
            CloudBlobContainer cbc = CloudBlobClient.GetContainerReference(containerName);
            await cbc.CreateIfNotExistsAsync();
            await cbc.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });

            return cbc;
        }

        /// <summary>
        /// Get Blob (Image)
        /// </summary>
        /// <param name="imageName">string</param>
        /// <param name="containerName">string</param>
        /// <returns>Task<CloudBlob></returns>
        public async Task<CloudBlob> GetBlob(string imageName, string containerName)
        {
            CloudBlobContainer container = await GetContainer(containerName);

            CloudBlob blob = container.GetBlobReference(imageName);

            return blob;
        }

        /// <summary>
        /// Upload image to blob storage
        /// </summary>
        /// <param name="cloudBlobContainer">CloudBlobContainer</param>
        /// <param name="fileName">string</param>
        /// <param name="filePath">string</param>
        /// <returns></returns>
        public async Task UploadImage(CloudBlobContainer cloudBlobContainer, string fileName, string filePath)
        {
            var blobFile = cloudBlobContainer.GetBlockBlobReference(fileName);
            await blobFile.UploadFromFileAsync(filePath);
        }
    }
}
