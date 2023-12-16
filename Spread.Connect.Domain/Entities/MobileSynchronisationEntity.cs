
namespace Spread.Connect.Domain.Entities;

public class MobileSynchronisationEntity
{
    /// <summary>Gets or sets the tenant identifier.</summary>
    /// <value>The tenant identifier.</value>
    public Guid TenantId { get; set; }

    /// <summary>
    /// The primary key for all objects on the device
    /// </summary>
    public Guid MobileId { get; set; }

    /// <summary>
    /// The last modification date time for the entity
    /// </summary>
    public DateTime? ModifiedDate { get; set; }

    /// <summary>
    /// Gets or sets the user Id of the last user who modified the record
    /// </summary>
    public Guid? ModifiedByUserId { get; set; }

    /// <summary>
    /// Gets or sets a flag to identify if the object has been archived and can be purged from
    /// the device.
    /// </summary>
    public bool IsPendingDelete { get; set; }

    /// <summary>
    /// Gets or sets a flag to identify if the object has been deleted from
    /// the device and needs to be deleted from the service database.
    /// </summary>
    public bool IsDeleted { get; set; }
}
