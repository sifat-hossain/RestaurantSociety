namespace Restaurant.Society.Admin.Entities;

public class SpreadUserRole
{
    public Guid SpreadUserRoleId { get; set; }
    public Guid SpreadUserId { get; set; }
    public SpreadUser SpreadUser { get; set; }
    public Guid RoleId { get; set; }
    public Role Role { get; set; }
}
