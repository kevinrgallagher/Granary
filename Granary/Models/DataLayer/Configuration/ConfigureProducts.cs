using Granary.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Granary.Models.DataLayer.Configuration;

internal class ConfigureProducts : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> entity)
    {
        // Configure decimal precision for on-hand quantity (e.g., 12.50)
        entity.Property(p => p.StockQuantity)
              .HasColumnType("decimal(10, 2)");

        // Product (dependent) → Category (principal), required FK
        // Delete behavior: Restrict — cannot delete a Category while Products reference it
        entity.HasOne(p => p.Category)
              .WithMany(c => c.Products)
              .HasForeignKey(p => p.CategoryId)
              .IsRequired()
              .OnDelete(DeleteBehavior.Restrict);

        // Product (dependent) → Supplier (principal), required FK
        // Delete behavior: Restrict — cannot delete a Supplier while Products reference it
        entity.HasOne(p => p.Supplier)
              .WithMany(s => s.Products)
              .HasForeignKey(p => p.SupplierId)
              .IsRequired()
              .OnDelete(DeleteBehavior.Restrict);

        // Product (principal) → RecipeProducts (dependents), required FK on RecipeProduct
        // Delete behavior: Restrict — cannot delete a Product while RecipeProducts reference it
        entity.HasMany(p => p.RecipeProducts)
              .WithOne(rp => rp.Product)
              .HasForeignKey(rp => rp.ProductId)
              .IsRequired()
              .OnDelete(DeleteBehavior.Restrict);

        // Seed data
        entity.HasData(
            new Product { ProductId = 1, ProductName = "Cherry Tomatoes", UnitType = "Pound", StockQuantity = 100.00m, Description = "Small sweet tomatoes", CategoryId = 1, SupplierId = 4 },
            new Product { ProductId = 2, ProductName = "Roma Tomatoes", UnitType = "Ounce", StockQuantity = 200.00m, Description = "Ideal for sauces", CategoryId = 1, SupplierId = 4 },
            new Product { ProductId = 3, ProductName = "Beefsteak Tomatoes", UnitType = "Ounce", StockQuantity = 150.00m, Description = "Large slicing tomato", CategoryId = 1, SupplierId = 4 },

            new Product { ProductId = 4, ProductName = "White Mushrooms", UnitType = "Each", StockQuantity = 80.00m, Description = "Mild and versatile", CategoryId = 2, SupplierId = 3 },
            new Product { ProductId = 5, ProductName = "Portobello Mushrooms", UnitType = "Pound", StockQuantity = 60.00m, Description = "Meaty texture, great grilled", CategoryId = 2, SupplierId = 3 },
            new Product { ProductId = 6, ProductName = "Shiitake Mushrooms", UnitType = "Each", StockQuantity = 300.00m, Description = "Savory and rich flavor", CategoryId = 2, SupplierId = 3 },

            new Product { ProductId = 7, ProductName = "Yellow Onions", UnitType = "Pound", StockQuantity = 500.00m, Description = "Common all-purpose onion", CategoryId = 3, SupplierId = 5 },
            new Product { ProductId = 8, ProductName = "Red Onions", UnitType = "Ounce", StockQuantity = 400.00m, Description = "Colorful and sharp", CategoryId = 3, SupplierId = 5 },
            new Product { ProductId = 9, ProductName = "Sweet Onions", UnitType = "Pound", StockQuantity = 350.00m, Description = "Mild and sweet", CategoryId = 3, SupplierId = 5 },
            new Product { ProductId = 10, ProductName = "Sweet Onions", UnitType = "Each", StockQuantity = 50.00m, Description = "Mild and sweet", CategoryId = 3, SupplierId = 5 }
        );
    }
}
