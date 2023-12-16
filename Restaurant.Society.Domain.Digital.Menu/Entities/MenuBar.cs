using Restaurant.Society.Domain.Digital.Menu.Base;

namespace Restaurant.Society.Domain.Digital.Menu.Entities;

public class MenuBar : BaseEntity
{
    /// <summary>Gets or sets the first name.</summary>
    /// <value>The first name.</value>
    public string Name { get; set; }

    /// <summary>Gets or sets the description.</summary>
    /// <value>The description.</value>
    public string Description { get; set; }
}
