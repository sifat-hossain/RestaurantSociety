﻿namespace Spread.Connect.Domain.Framework.Settings;

/// <summary>
/// Mapping app settings properties class for jwt authentication
/// </summary>
public class AuthSettings
{
    #region Properties
    /// <summary>
    /// The signing key value
    /// </summary>
    public string SigningKey { get; set; }

    /// <summary>
    /// The signing key for merlin users
    /// </summary>
    public string MerlinKey { get; set; }

    /// <summary>
    /// The API key value to validate against
    /// </summary>
    public string ApiKey { get; set; }

    /// <summary>
    /// The Issuer value
    /// </summary>
    public string Issuer { get; set; }

    /// <summary>
    /// The Audience value
    /// </summary>
    public string Audience { get; set; }

    /// <summary>
    /// The number of minutes of the jwt token lifetime, after that time jwt bearer token gets expired
    /// </summary>
    public int LifetimeMinutes { get; set; }

    /// <summary>
    /// The number of months of the refresh token lifetime, after that time refresh token gets expired
    /// </summary>
    public int LifetimeMonths { get; set; }

    /// <summary>
    /// Count of max login attempts
    /// </summary>
    public int LoginAttempts { get; set; }

    /// <summary>
    /// Suspended user from login time in minutes
    /// </summary>
    public int SuspendedTime { get; set; }
    #endregion
}
