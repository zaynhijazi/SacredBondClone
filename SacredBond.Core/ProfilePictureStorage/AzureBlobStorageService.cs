using System;
using Microsoft.AspNetCore.Http;
using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using SacredBond.Common.DTOs;
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Azure.Storage.Sas;
using SacredBond.Core.Services;
using SacredBond.Core.Repositories;
using SacredBond.Core.Mappers;
using SacredBond.Core.Domain;
using System.Reflection.Metadata;
using System.Collections.Specialized;
using System.Web;
using Azure.Storage;

namespace SacredBond.Core.ProfilePictureStorage
{
    public class AzureBlobStorageService : IAzureBlobStorageService
    {
        private readonly IConfiguration _configuration;
        private readonly BlobServiceClient _blobServiceClient;
        private readonly BlobContainerClient _blobContainerClient;
        private readonly IProfilePicturesRepository ProfilePictures;
        private readonly IProfileRepository Profiles;
        // private readonly ProfileService _profileService;

        public AzureBlobStorageService(IConfiguration configuration, IProfilePicturesRepository profilePictures, IProfileRepository profiles)
        {
            _configuration = configuration;
            _blobServiceClient = new BlobServiceClient(_configuration.GetConnectionString("AzureBlobStorageConnection"));
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient("profile");
            ProfilePictures = profilePictures;
            Profiles = profiles;
        }

        public async Task<ProfilePicturesDto> GetProfilePictures(int profileId)
        {
           var profile = await Profiles.GetAsync(profileId);
           foreach(ProfilePicture pic in profile.ProfilePictures)
           {
                string newSasToken =  CheckAndUpdateSasToken(pic.PictureUri, pic.SasToken);
                if(newSasToken != null)
                {
                    pic.SasToken = newSasToken;
                }
                else
                {
                    throw new Exception("Picture has an expired token, and we were unable to renew it");
                }
           }
            await Profiles.SaveChangesAsync();
            return ProfileMapper.MapPictures(profile);
        }
        //This function updates a sasToken related to a blob
        public string CheckAndUpdateSasToken(string blobUri, string sasToken)
        {
            try
            {
                // Parse the SAS token from the provided URI
                Uri blobUriWithSas = new Uri(blobUri + "?" + sasToken);

                // Create a BlobUriBuilder to easily access blob properties
                BlobUriBuilder blobUriBuilder = new BlobUriBuilder(blobUriWithSas);

                // Get the blob container name and blob name from the URI
                string containerName = blobUriBuilder.BlobContainerName;
                string blobName = blobUriBuilder.BlobName;

                // Create a BlobContainerClient for the container
                BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(containerName);

                // Create a BlobClient for the blob
                BlobClient blobClient = containerClient.GetBlobClient(blobName);

                // Check if the provided SAS token has expired
                BlobSasBuilder sasBuilder = new BlobSasBuilder()
                {
                    BlobContainerName = containerName,
                    BlobName = blobName, // Use the correct blob name
                    ExpiresOn = DateTimeOffset.UtcNow // Set this to the current time
                };

                // Check if the provided SAS token has expired
                if (sasBuilder.ExpiresOn <= DateTimeOffset.UtcNow)
                {
                    // The provided SAS token has expired, generate a new one
                    sasBuilder = new BlobSasBuilder()
                    {
                        BlobContainerName = containerName,
                        BlobName = blobName,
                        ExpiresOn = DateTimeOffset.UtcNow.Add(TimeSpan.FromDays(7)) // Set the new expiration time
                                                                                    // You can also specify other parameters as needed
                    };

                    // Set the permissions for the new SAS token
                    sasBuilder.SetPermissions(BlobSasPermissions.Read); // Adjust permissions as needed

                    // Generate the new SAS token
                    string newSasToken = blobClient.GenerateSasUri(sasBuilder).Query.Trim('?');

                    // Return the new SAS token
                    return newSasToken;
                }


                // The provided SAS token is still valid, return it as is
                return sasToken;
            }
            catch (Exception ex)
            {
                // Handle any exceptions here
                Console.WriteLine($"Error: {ex.Message}");
                return null; // Return null or handle the error as needed
            }
        }


        //This function reads all the images from the db. This is a READ
        public async Task<List<BlobDto>> ListAsync()
        {
            // Create a new list object for 
            List<BlobDto> files = new List<BlobDto>();

            await foreach (BlobItem file in _blobContainerClient.GetBlobsAsync())
            {
                // Add each file retrieved from the storage container to the files list by creating a BlobDto object
                string uri = _blobContainerClient.Uri.ToString();
                var name = file.Name;
                var fullUri = $"{uri}/{name}";

                files.Add(new BlobDto
                {
                    Uri = fullUri,
                    Name = name,
                    ContentType = file.Properties.ContentType
                });
            }

            // Return all files to the requesting method
            return files;
        }
        //This function adds an image to the database. This is a CREATE
        public async Task<BlobResponseDto> UploadAsync(IFormFile blob, int ProfileId, Guid userId, int photoNumber)
        {
            var _storageContainerName = "profile";
            // Create new upload response object that we can return to the requesting method
            BlobResponseDto response = new();

            try
            {
                string fileName = blob.FileName;
                string path = $"{ProfileId.ToString()}/Img/{userId.ToString()}/{photoNumber.ToString()}";

                // Get a reference to the blob just uploaded from the API in a container from configuration settings
                BlobClient client = _blobContainerClient.GetBlobClient(path);

                // Open a stream for the file we want to upload
                await using (Stream? data = blob.OpenReadStream())
                {
                    // Upload the file async
                    await client.UploadAsync(data);
                }
                DateTimeOffset currentTime = DateTimeOffset.UtcNow;
                DateTimeOffset expirationTime = currentTime.Add(TimeSpan.FromDays(7));
                // Generate a SAS token for the uploaded blob
                BlobSasBuilder sasBuilder = new BlobSasBuilder()
                {
                    BlobContainerName = _storageContainerName,
                    BlobName = path,
                    Resource = "b", // 'b' represents a blob
                    StartsOn = currentTime, // Optional: Token start time
                    ExpiresOn = expirationTime,  // Token expiration time (7 days from start)
                };

                // Define the permissions for the SAS token (e.g., read access)
                sasBuilder.SetPermissions(BlobSasPermissions.Read);

                // Generate the SAS token as a string
                string sasToken = client.GenerateSasUri(sasBuilder).Query;


                // Update the response object with the SAS token
                response.Status = $"File {blob.FileName} Uploaded Successfully";
                response.Error = false;
                response.Blob.Uri = client.Uri.AbsoluteUri.TrimStart('?');
                response.Blob.Name = client.Name;
                response.SasToken = sasToken.TrimStart('?'); // Store the SAS token in the response

                // Store the SAS token in your database for future use by the user
               
            }
            // Handle exceptions
            catch (RequestFailedException ex) when (ex.ErrorCode == BlobErrorCode.BlobAlreadyExists)
            {
                // Handle the case where the blob already exists
                response.Status = $"File with name {blob.FileName} already exists. Please use another name to store your file.";
                response.Error = true;
            }
            catch (RequestFailedException ex)
            {
                // Handle other request failures
                response.Status = $"Unexpected error: {ex.Message}";
                response.Error = true;
            }
            catch (Exception ex)
            {
                // Handle unexpected exceptions
                response.Status = $"Unhandled Exception: {ex.Message}";
                response.Error = true;
            }

            // Return the BlobUploadResponse object
            return response;
        }

        //This is a function that is used to replace a picture. This an UPDATE
        public async Task<BlobResponseDto> ReplaceBlobByUriAsync(string blobUri, IFormFile newFile)
        {
            BlobResponseDto response = new();
            try
            {
                // Convert the IFormFile to a Stream
                using (Stream newContent = newFile.OpenReadStream())
                {
                    Uri uri = new Uri(blobUri);

                    // Get the container name and blob name from the URI
                    string containerName = uri.Segments[1].TrimEnd('/');
                    string blobName = uri.Segments[2] + uri.Segments[3] + uri.Segments[4] + uri.Segments[5].Substring(0, 1);

                    // Get a reference to the container
                    BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(containerName);

                    // Get a reference to the existing blob
                    BlobClient blobClient = containerClient.GetBlobClient(blobName);

                    // Upload the new content to replace the existing blob
                    await blobClient.UploadAsync(newContent, overwrite: true);
                    DateTimeOffset currentTime = DateTimeOffset.UtcNow;
                    DateTimeOffset expirationTime = currentTime.Add(TimeSpan.FromDays(7));
                    // Generate a new SAS token for the updated blob
                    BlobSasBuilder sasBuilder = new BlobSasBuilder()
                    {
                        BlobContainerName = containerName,
                        BlobName = blobName,
                        Resource = "b", // 'b' represents a blob
                        StartsOn = currentTime,
                        ExpiresOn = expirationTime, // SAS token survives for 7 days
                    };

                    // Define the permissions for the SAS token (e.g., read access)
                    sasBuilder.SetPermissions(BlobSasPermissions.Read);

                    // Generate the SAS token as a string without the "?"
                    string sasToken = blobClient.GenerateSasUri(sasBuilder).Query;

                    // Remove the leading '?' character from the query string
                    sasToken = sasToken.TrimStart('?');

                    // Now, you can use 'sasToken' for secure access to the updated blob
                    response.Status = $"File {newFile.FileName} Uploaded Successfully";
                    response.Error = false;
                    response.Blob.Uri = blobUri;
                    response.Blob.Name = blobName;
                    response.SasToken = sasToken.TrimStart('?'); // Store the SAS token in the response
                }
            }
            catch (RequestFailedException ex)
            {
                // Handle storage service error
                response.Status = $"Unhandled Exception: {ex.Message}";
                response.Error = true; // Upload or SAS token generation failed
            }
            return response;
        }


        //This function is used to delete a picture, remember we are expecting to have the uri stored in the database.
        //We should make the column related to the picture url and the token value as null
        public async Task<bool> DeleteBlobAsync(string blobUri)
        {
            try
            {
                Uri uri = new Uri(blobUri);
                BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(uri.Segments[1]);
                BlobClient blobClient = containerClient.GetBlobClient(uri.Segments[2]);

                if (await blobClient.ExistsAsync())
                {
                    await blobClient.DeleteAsync();
                    return true; // Deletion successful
                }
                else
                {
                    return false; // Blob doesn't exist
                }
            }
            catch (RequestFailedException ex)
            {
                // Handle exceptions (e.g., RequestFailedException)
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false; // Deletion failed
            }
        }

        Task<List<BlobItem>> IAzureBlobStorageService.ListAsync()
        {
            throw new NotImplementedException();
        }
    }
    public interface IAzureBlobStorageService
    {
        Task<List<BlobItem>> ListAsync();
        Task<BlobResponseDto> UploadAsync(IFormFile blob, int ProfileId, Guid userId, int photoNumber); //Used for adding profile pic
        Task<BlobResponseDto> ReplaceBlobByUriAsync(string blobUri, IFormFile newFile); //Used to replace one of the profile photos
        //Task<List<BlobItem>> ListBlobsInVirtualFolderAsync(string containerName, string virtualFolderPath);
        Task<bool> DeleteBlobAsync(string blobUri); //Used to delete a picture from the db, could be used when a person leaves, etc
        Task<ProfilePicturesDto> GetProfilePictures(int profileId);
    }


}


