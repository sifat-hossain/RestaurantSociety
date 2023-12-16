using System.Collections.Generic;
using System.Linq;

namespace Spread.Connect.Domain.Framework.Services;

/// <summary>
/// Service for file signatures
/// </summary>
public class FileService
{
    #region Private Methods
    /// <summary>
    /// Helper method for getting a default list of supported file signatures and thier
    /// associated file extension
    /// </summary>
    /// <returns>a dictionary of key value pairs matching a file signature to it's associated extension</returns>
    private static Dictionary<byte[], string> GetDefaultSupportedSignatures()
    {
        return new Dictionary<byte[], string>
            {
                { new byte[] { 0x25, 0x50, 0x44, 0x46 },".pdf" },
                { new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A },".png" },
                { new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },".jpeg"},
                { new byte[] { 0xFF, 0xD8, 0xFF, 0xE2 },".jpeg"},
                { new byte[] { 0xFF, 0xD8, 0xFF, 0xE3 },".jpeg"},
                { new byte[] { 0xFF, 0xD8, 0xFF, 0xE1 },".jpg"},
                { new byte[] { 0xFF, 0xD8, 0xFF, 0xE8 },".jpg"},
                { new byte[] { 0x47, 0x49, 0x46, 0x38 },".gif" },
                { new byte[] { 0x49, 0x20, 0x49 },".tiff" },
                { new byte[] { 0x49, 0x49, 0x2A, 0x00 },".tiff" },
                { new byte[] { 0x52, 0x49, 0x46, 0x46 },".webp" },
            };
    }
    #endregion

    #region Protected Methods
    /// <summary>
    /// Overridable method for getting the header signatures for common file types.
    /// </summary>
    /// <returns>a dictionary of key value pairs matching a file signature to it's associated extension</returns>
    /// <remarks>
    /// This should be overriden if a specific set of files are required. Example - If it
    /// is known that the image should always be a PNG then only the signature for PNGs 
    /// should be provided
    /// </remarks>
    protected virtual Dictionary<byte[], string> GetSupportedFileSignatureType() => GetDefaultSupportedSignatures();
    #endregion

    #region Public Methods
    /// <summary>
    /// Method to get the file extension for the file from the header of the byte array
    /// </summary>
    /// <param name="bytes">The file bytes</param>
    /// <returns>
    /// The file extension to be used for the file, if it is found from 
    /// the <cref>GetSupportFileSignatureType</cref> method; otherwise null
    /// </returns>
    public string GetFileExtensionForFileType(byte[] bytes)
    {
        //  Iterate through each supported file type signature to get the correct extension
        foreach (KeyValuePair<byte[], string> supportedSignature in GetSupportedFileSignatureType())
        {
            IEnumerable<byte> header = bytes.Take(supportedSignature.Key.Length);
            if (header.SequenceEqual(supportedSignature.Key))
            {
                return supportedSignature.Value;
            }
        }

        //  If we get here the signature is not available or not supported so return null
        return null;
    } 
    #endregion
}
