using System.ComponentModel.DataAnnotations;

namespace Granary.Models.DomainModels;

public class Recipe
{
    [Required]
    public int RecipeId { get; set; } // Primary key, foreign key to RecipeProduct

    [Required]
    public string RecipeName { get; set; } = string.Empty;

    [Required]
    public string Description { get; set; } = string.Empty;

    public ICollection<RecipeProduct>? RecipeProducts { get; set; } // Navigation property for RecipeProducts
}
