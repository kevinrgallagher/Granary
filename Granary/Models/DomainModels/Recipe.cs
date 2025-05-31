namespace Granary.Models.DomainModels;

public class Recipe
{
    public int RecipeId { get; set; } // Primary key, foreign key to RecipeProduct
    public string RecipeName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public ICollection<RecipeProduct>? RecipeProducts { get; set; } // Navigation property for RecipeProducts

}
