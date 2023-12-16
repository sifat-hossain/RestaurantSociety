namespace Restaurant.Society.Domain.Framework.Settings;

/// <summary>
/// Mapping app settings properties class for azure storage
/// </summary>
public class AzureStorageSettings
{
    /// <summary>
    /// The azure storage connection string
    /// </summary>
    public string StorageConnectionString { get; set; }

    /// <summary>
    /// The blob container name
    /// </summary>
    public string BlobContainerName { get; set; }

    /// <summary>
    /// Use web server flag
    /// </summary>
    public bool UseWebServer { get; set; }
}
