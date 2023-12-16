using Restaurant.Society.Domain.Digital.Menu.Base;

namespace Restaurant.Society.Domain.Digital.Menu.Entities;

public class RestaurantProfile : BaseEntity
{
    /// <summary>Gets or sets the first name.</summary>
    /// <value>The first name.</value>
    public string Name { get; set; }

    /// <summary>Gets or sets the logo.</summary>
    /// <value>The logo.</value>
    public string Logo { get; set; }

    /// <summary>Gets or sets the phone.</summary>
    /// <value>The phnoe.</value>
    public string Phone { get; set; }

    /// <summary>Gets or sets email.</summary>
    /// <value>The email.</value>
    public string Email { get; set; }

    /// <summary>Gets or sets the address.</summary>
    /// <value>The address.</value>
    public string Address { get; set; }
}
