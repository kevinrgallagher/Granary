using Granary.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Granary.Models
{
    public class ConfigureRecipes : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> entity)
        {
            entity.HasData(
                new Recipe
                {
                    RecipeId = 1,
                    Name = "Tomato Soup",
                    Description = "A warm and savory soup made from fresh tomatoes and onions."
                },
                new Recipe
                {
                    RecipeId = 2,
                    Name = "Stuffed Mushrooms",
                    Description = "Mushroom caps filled with a savory onion and herb blend."
                },
                new Recipe
                {
                    RecipeId = 3,
                    Name = "Marinara Sauce",
                    Description = "A classic Italian-style tomato and mushroom sauce."
                },
                new Recipe
                {
                    RecipeId = 4,
                    Name = "Onion Salad",
                    Description = "A fresh salad combining red and yellow onions with cherry tomatoes."
                }
            );
        }
    }
}
