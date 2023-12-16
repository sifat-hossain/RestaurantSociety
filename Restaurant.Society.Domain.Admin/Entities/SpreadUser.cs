using Restaurant.Society.Domain.Digital.Menu;

namespace Restaurant.Society.Admin.Entities;

public class SpreadUser : ISpreadTokanable
{
    /// <summary>Gets or sets the Spread user identifier.</summary>
    /// <value>The Spread user identifier.</value>
    public Guid SpreadUserId { get; set; }

    /// <summary>Gets or sets the name of the user.</summary>
    /// <value>The name of the user.</value>
    public string UserName { get; set; }

    /// <summary>Gets or sets the first name.</summary>
    /// <value>The first name.</value>
    public string Name { get; set; }

    /// <summary>Gets or sets the surname.</summary>
    /// <value>The surname.</value>
    public string? FatherName { get; set; }

    public string? MotherName { get; set; }

    /// <summary>Gets or sets the password.</summary>
    /// <value>The password.</value>
    public string Password { get; set; }

    /// <summary>Gets or sets the email.</summary>
    /// <value>The email.</value>
    public string Email { get; set; }

    /// <summary>
    /// Person's phone number
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// Person's alternate phone number
    /// </summary>
    public string? AlternatePhone { get; set; }

    /// <summary>
    /// Person's national identification number
    /// </summary>
    public string? NID { get; set; }

    /// <summary>
    /// Person's blood group
    /// </summary>
    public string? BloodGroup { get; set; }

    /// <summary>
    /// Person's religion
    /// </summary>
    public string? Religion { get; set; }

    /// <summary>
    /// Person's professional status
    /// </summary>
    public string? ProfessionalStatus { get; set; }

    /// <summary>
    /// Person's marital status
    /// </summary>
    public string? MaritalStatus { get; set; }

    /// <summary>
    /// Person's date of birth
    /// </summary>
    public string? DateOfBirth { get; set; }

    /// <summary>
    /// Person's present address
    /// </summary>
    public string? PresentAddress { get; set; }

    /// <summary>
    /// Person's permanent address
    /// </summary>
    public string? PermanentAddress { get; set; }

    /// <summary>
    /// Name of person's school
    /// </summary>
    public string? School { get; set; }

    /// <summary>
    /// Name of person's college
    /// </summary>
    public string? College { get; set; }

    /// <summary>
    /// Name of person's university
    /// </summary>
    public string? University { get; set; }

    /// <summary>Gets or sets the refresh token.</summary>
    /// <value>The refresh token.</value>
    public string? RefreshToken { get; set; }

    /// <summary>Gets or sets the expiration date.</summary>
    /// <value>The expiration date.</value>
    public DateTime? ExpirationDate { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this instance is deleted.
    /// </summary>
    /// <value><c>true</c> if this instance is deleted; otherwise, <c>false</c>.</value>
    public bool IsDeleted { get; set; }

    /// <summary>Gets or sets the login attempts.</summary>
    /// <value>The login attempts.</value>
    public int LoginAttempts { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether [requires password reset].
    /// </summary>
    /// <value>
    ///   <c>true</c> if [requires password reset]; otherwise, <c>false</c>.
    /// </value>
    public bool RequiresPasswordReset { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this instance is suspended.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is suspended; otherwise, <c>false</c>.
    /// </value>
    public bool IsSuspended { get; set; }

    /// <summary>Gets or sets the suspended until.</summary>
    /// <value>The suspended until.</value>
    public DateTime? SuspendedUntil { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this instance is password reset.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is password reset; otherwise, <c>false</c>.
    /// </value>
    public bool IsPasswordReset { get; set; }

    /// <summary>Gets or sets the Spread user roles.</summary>
    /// <value>The Spread user roles.</value>
    public List<SpreadUserRole> SpreadUserRoles { get; set; } = new List<SpreadUserRole>();

    /// <summary>Gets the user identifier.</summary>
    /// <value>The user identifier.</value>
    public string UserId { get => SpreadUserId.ToString(); }

    /// <summary>Gets the roles.</summary>
    /// <value>The roles.</value>
    public List<string> Roles { get => SpreadUserRoles.Select(ur => ur.Role.Name).ToList(); }

    public string? ImagePath { get; set; }

    /// <summary>Gets or sets the log level.</summary>
    /// <value>The log level</value>
    //  public int LogLevel { get; set; }

    /// <summary>Gets or sets the tenant identifier.</summary>
    /// <value>The tenant identifier.</value>
    //public Guid TenantId { get; set; }

    /// <summary>Gets or sets the tenant.</summary>
    /// <value>The tenant.</value>
    //public Tenant Tenant { get; set; }

    /// <summary>Gets or sets the Spread user permissions.</summary>
    /// <value>The Spread user permissions.</value>
    // public List<SpreadUserPermission> SpreadUserPermissions { get; set; } = new List<SpreadUserPermission>();


    /// <summary>Gets the name of the employer.</summary>
    /// <value>The name of the employer.</value>
    // public string EmployerName { get => Tenant?.Name; }

    /// <summary>Gets the tenant permission.</summary>
    /// <value>The tenant permission.</value>
    //public List<(string, string)> TenantPermission
    //{
    //    get
    //    {
    //        var results = new List<(string, string)>();
    //        foreach (SpreadUserPermission permission in SpreadUserPermissions)
    //        {
    //            string permissionName = permission.Permission.Name;
    //            string tenantId = permission.TenantId.ToString();
    //            results.Add((permissionName, tenantId));
    //        }

    //        return results;
    //    }
    //}
}
