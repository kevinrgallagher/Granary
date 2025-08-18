using Granary.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Granary.Models;

public class ConfigureRecipes : IEntityTypeConfiguration<Recipe>
{
    public void Configure(EntityTypeBuilder<Recipe> entity)
    {
        // Establish required relationship between recipe and recipe products, deleting recipe deletes recipe products
        entity.HasMany(r => r.RecipeProducts)
            .WithOne(rp => rp.Recipe)
            .HasForeignKey(rp => rp.RecipeId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        // Seed data
        entity.HasData(
            new Recipe
            {
                RecipeId = 1,
                RecipeName = "Tomato Soup",
                Description = "A warm and savory soup made from fresh tomatoes and onions."
            },
            new Recipe
            {
                RecipeId = 2,
                RecipeName = "Stuffed Mushrooms",
                Description = "Mushroom caps filled with a savory onion and herb blend."
            },
            new Recipe
            {
                RecipeId = 3,
                RecipeName = "Marinara Sauce",
                Description = "A classic Italian-style tomato and mushroom sauce."
            },
            new Recipe
            {
                RecipeId = 4,
                RecipeName = "Onion Salad",
                Description = "A fresh salad combining red and yellow onions with cherry tomatoes."
            }
        );
    }
}
