using Microsoft.EntityFrameworkCore;
using Restaurant.Society.Domain.Digital.Menu.Entities;

namespace Restaurant.Society.Application.Digital.Menu;

public interface IDigitalMenuDbContext
{
    DbSet<Category> Category { get; set; }
    DbSet<Fooditem> Fooditem { get; set; }
    DbSet<MenuBar> MenuBar { get; set; }
    DbSet<FoodMenu> FoodMenu { get; set; }
    DbSet<RestaurantSetting> RestaurantSetting { get; set; }
    DbSet<RestaurantProfile> RestaurantProfile { get; set; }
}
