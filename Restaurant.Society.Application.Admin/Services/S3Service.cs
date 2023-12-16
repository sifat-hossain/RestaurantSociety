using Amazon.S3;
using Amazon.S3.Encryption;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Microsoft.Extensions.Options;
using Restaurant.Society.Application.Admin.Services.Responses;
using System.Security.Cryptography;

namespace Restaurant.Society.Application.Admin.Services;

public class S3Service : IS3Service
{
    private readonly IAmazonS3 _s3Client;
    private readonly UploadSettings _uploadSettings;
    public S3Service(IAmazonS3 s3Client, IOptions<UploadSettings> options)
    {
        _uploadSettings = options.Value;
        _s3Client = new AmazonS3Client(new AmazonS3Config()
        {
            UseAccelerateEndpoint = true
        });
    }

    [Obsolete]
    public async Task CreateFolder(string awsFolderName)
    {
        EncryptionMaterials encryptionMaterials = new EncryptionMaterials(RSA.Create());

        AmazonS3EncryptionClient client = new AmazonS3EncryptionClient(encryptionMaterials);

        PutObjectRequest putObjectRequest = new PutObjectRequest
        {
            BucketName = _uploadSettings.BucketName,
            StorageClass = S3StorageClass.Standard,
            ServerSideEncryptionMethod = ServerSideEncryptionMethod.AES256,
            CannedACL = S3CannedACL.Private,
            Key = awsFolderName,
            ContentBody = awsFolderName
        };

        await client.PutObjectAsync(putObjectRequest);
    }

    public async Task<bool> Exists(string filePath)
    {
        var listResponse = await _s3Client.ListObjectsV2Async(new ListObjectsV2Request
        {
            BucketName = _uploadSettings.BucketName,
            Prefix = filePath
        });

        return listResponse.S3Objects.Any();
    }

    public async Task<byte[]> GetS3Object(string filePath)
    {
        var request = new GetObjectRequest();
        request.BucketName = _uploadSettings.BucketName;
        request.Key = filePath;

        GetObjectResponse response = await _s3Client.GetObjectAsync(request);
        using var stream = response.ResponseStream;
        var bytes = ReadStream(stream);
        return bytes;
    }

    private static byte[] ReadStream(Stream responseStream)
    {
        byte[] buffer = new byte[16 * 1024];
        using MemoryStream ms = new MemoryStream();
        int read;
        while ((read = responseStream.Read(buffer, 0, buffer.Length)) > 0)
        {
            ms.Write(buffer, 0, read);
        }
        return ms.ToArray();
    }

    public async Task UploadFile(byte[] data, string filePath)
    {
        var fileTransferUtility = new TransferUtility(_s3Client);
        using var stream = new MemoryStream(data);
        await fileTransferUtility.UploadAsync(stream, _uploadSettings.BucketName, filePath);
    }

    public async Task<string> GetFileName(string folderPath)
    {
        var fileName = Path.GetRandomFileName();
        var fileExists = await Exists(string.Concat(folderPath, fileName));
        if (fileExists)
        {
            return await GetFileName(folderPath);
        }
        return fileName;
    }

    public async Task DeleteFile(string filePath)
    {
        var deleteObjectRequest = new DeleteObjectRequest
        {
            BucketName = _uploadSettings.BucketName,
            Key = filePath
        };

        await _s3Client.DeleteObjectAsync(deleteObjectRequest);
    }
}
