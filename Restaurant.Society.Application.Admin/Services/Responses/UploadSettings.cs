namespace Restaurant.Society.Application.Admin.Services.Responses;

public class UploadSettings
{
    public string FileName { get; set; }
    public string BucketName { get; set; }
    public string SignaturesDirectory { get; set; }
    public string EvidencesDirectory { get; set; }
    public string NoticeSignaturesDirectory { get; set; }
    public string NoticeImageDirectory { get; set; }
}
