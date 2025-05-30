namespace Granary.Models.DomainModels;

public class Product
{
    public int ProductId { get; set; } // Primary key, foreign key to the three join tables
    public int CategoryId { get; set; } // Foreign key to Category
    public string Name { get; set; } = string.Empty;
    public string UnitType { get; set; } = string.Empty;
    public decimal UnitPrice { get; set; } = 0.0m;
    public decimal StockQuantity { get; set; }
    public string Description { get; set; } = string.Empty;

    public ICollection<SupplierProduct>? SupplierProducts { get; set; } // Navigation property for SupplierProducts
    public ICollection<InvoiceProduct>? InvoiceProducts { get; set; } // Navigation property for InvoiceProducts
    public ICollection<RecipeProduct>? RecipeProducts { get; set; } // Navigation property for RecipeProducts
    public Category? Category { get; set; } // Navigation property for Category

}