namespace Spread.Connect.Domain.Brotherhood.Dtos;

public class ApplicationSetting
{
    public Guid ApplicationSettingId { get; set; }
    public string? ParamName { get; set; }

    /// <summary>
    /// Value of the paramenter
    /// </summary>
    public string? Value { get; set; }

    /// <summary>
    /// where it is used in
    /// </summary>
    public string? Scope { get; set; }
}
