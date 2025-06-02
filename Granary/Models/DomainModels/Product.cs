using System.ComponentModel.DataAnnotations;

namespace Granary.Models.DomainModels;

public class Product
{
    public int ProductId { get; set; } // Primary key, foreign key to the three join tables

    [Required]
    public int CategoryId { get; set; } // Foreign key to Category

    [Required]
    public string ProductName { get; set; } = string.Empty;

    [Required]
    public string UnitType { get; set; } = string.Empty;

    [Required]
    public decimal UnitPrice { get; set; } = 0.0m;

    [Required]
    public decimal StockQuantity { get; set; }

    [Required]
    public string Description { get; set; } = string.Empty;

    public ICollection<SupplierProduct>? SupplierProducts { get; set; } // Navigation property for SupplierProducts
    public ICollection<InvoiceProduct>? InvoiceProducts { get; set; } // Navigation property for InvoiceProducts
    public ICollection<RecipeProduct>? RecipeProducts { get; set; } // Navigation property for RecipeProducts
    public Category Category { get; set; } = null!; // Navigation property for Category, configured to be required

}