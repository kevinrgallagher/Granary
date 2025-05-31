using System.ComponentModel.DataAnnotations;

namespace Granary.Models.DomainModels;

public class RecipeProduct
{
    [Required]
    public int RecipeId { get; set; } // Composite key one, foreign key to Recipe

    [Required]
    public int ProductId { get; set; } // Composite key two, foreign key to Product

    [Required]
    public decimal Quantity { get; set; }

    public Recipe Recipe { get; set; } = null!; // Navigation property for Recipe
    public Product Product { get; set; } = null!; // Navigation property for Product
}
