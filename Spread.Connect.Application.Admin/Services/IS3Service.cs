namespace Spread.Connect.Application.Admin.Services;

public interface IS3Service
{
    Task CreateFolder(string awsFolderName);
    Task<bool> Exists(string filePath);
    Task<byte[]> GetS3Object(string filePath);
    Task UploadFile(byte[] data, string filePath);
    Task<string> GetFileName(string folderPath);
    Task DeleteFile(string filePath);
}
