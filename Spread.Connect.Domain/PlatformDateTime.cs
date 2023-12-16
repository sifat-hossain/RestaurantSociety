namespace Spread.Connect.Domain;

public class PlatformDateTime : IDateTime
{
    public DateTime UtcNow => DateTime.UtcNow;
    public DateTime MinDate => DateTime.MinValue;
    public DateTime MaxDate => DateTime.MaxValue;
}
