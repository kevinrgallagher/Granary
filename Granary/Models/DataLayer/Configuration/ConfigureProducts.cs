using Granary.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Granary.Models;

internal class ConfigureProducts : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> entity)
    {
        // Configure decimal precision
        entity.Property(p => p.StockQuantity)
            .HasColumnType("decimal(10, 2)");

        // Configure decimal precision
        entity.Property(p => p.UnitPrice)
            .HasColumnType("decimal(10, 2)");

        entity.HasData(
            new Product { ProductId = 1, Name = "Cherry Tomatoes", UnitType = "each", UnitPrice = 2.99m, StockQuantity = 100, Description = "Small sweet tomatoes", CategoryId = 1 },
            new Product { ProductId = 2, Name = "Roma Tomatoes", UnitType = "pound", UnitPrice = 1.49m, StockQuantity = 200, Description = "Ideal for sauces", CategoryId = 1 },
            new Product { ProductId = 3, Name = "Beefsteak Tomatoes", UnitType = "each", UnitPrice = 1.25m, StockQuantity = 150, Description = "Large slicing tomato", CategoryId = 1 },
            new Product { ProductId = 4, Name = "White Mushrooms", UnitType = "pound", UnitPrice = 3.25m, StockQuantity = 80, Description = "Mild and versatile", CategoryId = 2 },
            new Product { ProductId = 5, Name = "Portobello Mushrooms", UnitType = "each", UnitPrice = 1.99m, StockQuantity = 60, Description = "Meaty texture, great grilled", CategoryId = 2 },
            new Product { ProductId = 6, Name = "Shiitake Mushrooms", UnitType = "ounce", UnitPrice = 0.75m, StockQuantity = 300, Description = "Savory and rich flavor", CategoryId = 2 },
            new Product { ProductId = 7, Name = "Yellow Onions", UnitType = "pound", UnitPrice = 0.89m, StockQuantity = 500, Description = "Common all-purpose onion", CategoryId = 3 },
            new Product { ProductId = 8, Name = "Red Onions", UnitType = "pound", UnitPrice = 1.10m, StockQuantity = 400, Description = "Colorful and sharp", CategoryId = 3 },
            new Product { ProductId = 9, Name = "Sweet Onions", UnitType = "pound", UnitPrice = 1.30m, StockQuantity = 350, Description = "Mild and sweet", CategoryId = 3 },
            new Product { ProductId = 10, Name = "Cippolini Onions", UnitType = "each", UnitPrice = 0.60m, StockQuantity = 250, Description = "Small and sweet, ideal for roasting", CategoryId = 3 }
        );
    }
}
