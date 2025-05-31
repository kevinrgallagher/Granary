using System.ComponentModel.DataAnnotations;

namespace Granary.Models.DomainModels;

public class Category
{
    [Required]
    public int CategoryId { get; set; } // Primary key, foreign key to Product

    [Required]
    public string CategoryName { get; set; } = string.Empty;

    [Required]
    public string Description { get; set; } = string.Empty;

    public ICollection<Product>? Products { get; set; } // Navigation property for Products
}
