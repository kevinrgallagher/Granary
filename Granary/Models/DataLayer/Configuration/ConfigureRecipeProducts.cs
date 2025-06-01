using Granary.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Granary.Models;

public class ConfigureRecipeProducts : IEntityTypeConfiguration<RecipeProduct>
{
    public void Configure(EntityTypeBuilder<RecipeProduct> entity)
    {
        // Configure decimal precision for quantity
        entity.Property(p => p.Quantity)
                      .HasColumnType("decimal(10, 2)");
        
        // Define composite primary key for recipe product
        entity.HasKey(rp => new { rp.RecipeId, rp.ProductId });

        // Establish required relationship between recipe product and recipe, deleting a recipe deletes its recipe products
        entity.HasOne(rp => rp.Recipe)
              .WithMany(r => r.RecipeProducts)
              .HasForeignKey(rp => rp.RecipeId)
              .IsRequired()
              .OnDelete(DeleteBehavior.Cascade);

        // Establish required relationship between recipe product and product, cannot delete product if it's used in a recipe
        entity.HasOne(rp => rp.Product)
              .WithMany(p => p.RecipeProducts)
              .HasForeignKey(rp => rp.ProductId)
              .IsRequired()
              .OnDelete(DeleteBehavior.Restrict);

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
