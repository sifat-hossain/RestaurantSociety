namespace Restaurant.Society.Domain.Digital.Menu.Base;

public class BaseEntity
{
    /// <summary>Gets or sets the primary key.</summary>
    /// <value>The primary key.</value>
    public Guid Id { get; set; }

    /// <summary>Gets or sets the tenant identifier.</summary>
    /// <value>The tenant identifier.</value>
    public Guid TenantId { get; set; }

    /// <summary>
    /// The creation date time for the entity
    /// </summary>
    public DateTime CreationDate { get; set; }

    /// <summary>
    /// Gets or sets a flag to identify if the object has been deleted
    /// </summary>
    public bool IsDelete { get; set; }

    /// <summary>
    /// Gets or sets a flag to identify if the object has been deleted from
    /// the device and needs to be deleted from the service database.
    /// </summary>
    public bool IsActive { get; set; }
}
