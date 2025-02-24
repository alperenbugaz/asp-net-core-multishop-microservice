namespace MultiShop.Images.Services
{
    public interface ICloudStorageService
    {
        Task<string> GetSignedUrlAsync(string fileNameToRead, int timeOutInMinutes = 30);
        Task<string> UploadFileAsync(IFormFile file, string fileNameToSave);
        Task DeleteFileAsync(string fileNameToDelete);
    }
}
