namespace Restaurant.Society.Admin.Entities;

public class UnregisterBrotherhoodUser
{
    public Guid UserId { get; set; }
    public string? Name { get; set; }
    public string? MobileNo { get; set; }
    public bool IsRegistered { get; set; }
}
