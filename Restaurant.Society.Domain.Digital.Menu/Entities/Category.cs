﻿using Restaurant.Society.Domain.Digital.Menu.Base;

namespace Restaurant.Society.Domain.Digital.Menu.Entities;

public class Category : BaseEntity
{
    /// <summary>Gets or sets the first name.</summary>
    /// <value>The first name.</value>
    public string Name { get; set; }

    /// <summary>Gets or set the food items.</summary>
    /// <value>The food items.</value>
    public List<Fooditem> Fooditems { get; set; }
}
