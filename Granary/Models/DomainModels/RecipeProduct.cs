namespace Granary.Models.DomainModels;

public class RecipeProduct
{
    public int RecipeId { get; set; } // Composite key one, foreign key to Recipe
    public int ProductId { get; set; } // Composite key two, foreign key to Product
    public decimal Quantity { get; set; }

    public Recipe Recipe { get; set; } = null!; // Navigation property for Recipe
    public Product Product { get; set; } = null!; // Navigation property for Product
}
