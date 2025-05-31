using Granary.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Granary.Models;

internal class ConfigureCategories : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> entity)
    {
        entity.HasData(
            new Category
            {
                CategoryId = 1,
                CategoryName = "Tomatoes",
                Description = "Includes all tomato varieties like Roma, Cherry, and Beefsteak."
            },
            new Category
            {
                CategoryId = 2,
                CategoryName = "Mushrooms",
                Description = "Covers common edible mushrooms such as White, Portobello, and Shiitake."
            },
            new Category
            {
                CategoryId = 3,
                CategoryName = "Onions",
                Description = "Includes Yellow, Red, Sweet, and specialty onions like Cippolini."
            }
        );
    }
}
