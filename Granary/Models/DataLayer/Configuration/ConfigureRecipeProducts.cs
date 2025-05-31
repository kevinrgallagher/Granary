using Granary.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Granary.Models;

public class ConfigureRecipeProducts : IEntityTypeConfiguration<RecipeProduct>
{
    public void Configure(EntityTypeBuilder<RecipeProduct> entity)
    {
        // Configure decimal precision
        entity.Property(p => p.Quantity)
            .HasColumnType("decimal(10, 2)");

        // Composite key
        entity.HasKey(rp => new { rp.RecipeId, rp.ProductId });

        entity.HasData(
            // Tomato Soup (Recipe 1)
            new RecipeProduct { RecipeId = 1, ProductId = 1, Quantity = 4.0m },  // Cherry Tomatoes
            new RecipeProduct { RecipeId = 1, ProductId = 7, Quantity = 1.0m },  // Yellow Onions

            // Stuffed Mushrooms (Recipe 2)
            new RecipeProduct { RecipeId = 2, ProductId = 4, Quantity = 6.0m },  // White Mushrooms
            new RecipeProduct { RecipeId = 2, ProductId = 8, Quantity = 0.5m },  // Red Onions

            // Marinara Sauce (Recipe 3)
            new RecipeProduct { RecipeId = 3, ProductId = 2, Quantity = 3.0m },  // Roma Tomatoes
            new RecipeProduct { RecipeId = 3, ProductId = 5, Quantity = 2.0m },  // Portobello Mushrooms

            // Onion Salad (Recipe 4)
            new RecipeProduct { RecipeId = 4, ProductId = 7, Quantity = 1.0m },  // Yellow Onions
            new RecipeProduct { RecipeId = 4, ProductId = 8, Quantity = 1.0m },  // Red Onions
            new RecipeProduct { RecipeId = 4, ProductId = 1, Quantity = 1.0m }   // Cherry Tomatoes
        );
    }
}
