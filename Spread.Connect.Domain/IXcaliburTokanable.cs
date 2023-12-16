namespace Spread.Connect.Domain;


public interface ISpreadTokanable : ITokenable
{

    /// <summary>Gets the roles.</summary>
    /// <value>The roles.</value>
    public List<string> Roles { get; }

    /// <summary>
    /// Gets or sets a value indicating whether [requires password reset].
    /// </summary>
    /// <value>
    ///   <c>true</c> if [requires password reset]; otherwise, <c>false</c>.
    /// </value>
    public bool RequiresPasswordReset { get; set; }

    ///// <summary>Gets or sets the tenant identifier.</summary>
    ///// <value>The tenant identifier.</value>
    //public Guid TenantId { get; set; }

    ///// <summary>Gets the tenant permission.</summary>
    ///// <value>The tenant permission.</value>
    //public List<(string, string)> TenantPermission { get; }

    ///// <summary>Gets the name of the employer.</summary>
    ///// <value>The name of the employer.</value>
    //string EmployerName { get; }

    ///// <summary>Gets or sets the tenant identifier.</summary>
    ///// <value>The tenant identifier.</value>
    //public int LogLevel { get; }

}
