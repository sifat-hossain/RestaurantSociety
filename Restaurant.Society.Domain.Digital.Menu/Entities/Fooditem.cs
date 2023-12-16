using Restaurant.Society.Domain.Digital.Menu.Base;

namespace Restaurant.Society.Domain.Digital.Menu.Entities;

public class Fooditem : BaseEntity
{
    /// <summary>Gets or sets the first name.</summary>
    /// <value>The first name.</value>
    public string Name { get; set; }

    /// <summary>Gets or sets the description.</summary>
    /// <value>The description.</value>
    public string Description { get; set; }

    /// <summary>Gets or sets the quantity.</summary>
    /// <value>The quantity.</value>
    public double Quantity { get; set; }

    /// <summary>Gets or sets price.</summary>
    /// <value>The price.</value>
    public decimal Price { get; set; }

    /// <summary>Gets or sets the discount.</summary>
    /// <value>The discount.</value>
    public decimal Discount { get; set; }

    /// <summary>Gets or sets the category identifier.</summary>
    /// <value>The category identifier.</value>
    public Guid CategoryId { get; set; }

    /// <summary>Gets or sets the category.</summary>
    /// <value>The category.</value>
    public Category Category { get; set; }

}
