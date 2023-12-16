using Restaurant.Society.Domain.Digital.Menu.Base;

namespace Restaurant.Society.Domain.Digital.Menu.Entities;

public class RestaurantSetting : BaseEntity
{
    /// <summary>Gets or sets the restaurant identifier.</summary>
    /// <value>The restaurant identifier.</value>
    public Guid RestaurantId { get; set; }

    /// <summary>Gets or sets the restaurant.</summary>
    /// <value>The restaurant.</value>
    public RestaurantProfile Restaurant { get; set; }

    /// <summary>The subscription start date time for the entity</summary>
    /// <value>The subscription start</value>
    public DateTime SubscriptionStart { get; set; }

    /// <summary>The subscription expired date time for the entity</summary>
    /// <value>The subscription expired</value>
    public DateTime SubscriptionExpired { get; set; }

    /// <summary>Gets or sets the storage.</summary>
    /// <value>The storage.</value>
    public double Storage { get; set; }
}
