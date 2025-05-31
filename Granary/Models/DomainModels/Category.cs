namespace Granary.Models.DomainModels;

public class Category
{
    public int CategoryId { get; set; } // Primary key, foreign key to Product
    public string CategoryName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public ICollection<Product>? Products { get; set; } // Navigation property for Products
}
