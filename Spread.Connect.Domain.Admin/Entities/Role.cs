namespace Spread.Connect.Domain.Admin.Entities;

public class Role
{
    public Guid RoleId { get; set; }
    public string Name { get; set; }
    public bool Inactive { get; set; }
    public List<SpreadUserRole> SpreadUserRoles { get; set; } = new List<SpreadUserRole>();
}
