namespace Restaurant.Society.Admin.Entities;

public class ApplicationSetting
{

    public int ApplicationSettingId { get; set; }
    /// <summary>
    /// Application setting parameter name
    /// </summary>
    public string? ParamName { get; set; }

    /// <summary>
    /// Value of the paramenter
    /// </summary>
    public string? Value1 { get; set; }


    /// <summary>
    /// Value of the paramenter
    /// </summary>
    public string? Value2 { get; set; }


    /// <summary>
    /// Value of the paramenter
    /// </summary>
    public string? Value3 { get; set; }

    /// <summary>
    /// where it is used in
    /// </summary>
    public string? Scope { get; set; }
}
