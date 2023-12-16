using Restaurant.Society.Domain.Digital.Menu.Base;

namespace Restaurant.Society.Domain.Digital.Menu.Entities;

public class FoodMenu : BaseEntity
{
    /// <summary>Gets or sets the first name.</summary>
    /// <value>The first name.</value>
    public string Name { get; set; }

    /// <summary>Gets or sets the image.</summary>
    /// <value>The image.</value>
    public string Image { get; set; }

    /// <summary>Gets or sets the video.</summary>
    /// <value>The video.</value>
    public string Video { get; set; }

    /// <summary>Gets or sets price.</summary>
    /// <value>The price.</value>
    public decimal Price { get; set; }

    /// <summary>Gets or sets the discount.</summary>
    /// <value>The discount.</value>
    public decimal Discount { get; set; }

    /// <summary>Gets or sets the quantity.</summary>
    /// <value>The quantity.</value>
    public double Quantity { get; set; }

    /// <summary>Gets or sets the food item identifier.</summary>
    /// <value>The food item identifier.</value>
    public Guid FoodItemId { get; set; }

    /// <summary>Gets or sets the food item.</summary>
    /// <value>The food item.</value>
    public Fooditem Fooditem { get; set; }

    /// <summary>Gets or sets the menu identifier.</summary>
    /// <value>The menu identifier.</value>
    public Guid MenuId { get; set; }

    /// <summary>Gets or sets the menu.</summary>
    /// <value>The menu.</value>
    public MenuBar Menu { get; set; }
}
