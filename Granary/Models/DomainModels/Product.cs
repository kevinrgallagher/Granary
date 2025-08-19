using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;


namespace Granary.Models.DomainModels;

public class Product
{
    public int ProductId { get; set; } // Primary key, foreign key to the three join tables

    [Range(1, int.MaxValue, ErrorMessage = "Please select a category.")]
    public int CategoryId { get; set; } // Foreign key to Category

    public int SupplierId { get; set; } // Foreign key to Supplier

    public string ProductName { get; set; } = string.Empty;

    public string UnitType { get; set; } = "-";

    public decimal StockQuantity { get; set; }

    public string Description { get; set; } = string.Empty;

    public Supplier? Supplier { get; set; } // Navigation property for Suppliers
    public ICollection<InvoiceProduct> InvoiceProducts { get; set; } = new List<InvoiceProduct>(); // Navigation property for InvoiceProducts
    public ICollection<RecipeProduct>? RecipeProducts { get; set; } // Navigation property for RecipeProducts

    [ValidateNever]
    public Category Category { get; set; } = null!; // Navigation property for Category, configured to be required

}
