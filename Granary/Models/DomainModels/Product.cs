using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Granary.Models.DomainModels;

public class Product
{
    public int ProductId { get; set; } // Primary key, foreign key to the three join tables

    [Required]
    public string ProductName { get; set; } = string.Empty;

    [Range(1, int.MaxValue, ErrorMessage = "The Category field is required.")]
    public int CategoryId { get; set; } // Foreign key to Category

    [Range(1, int.MaxValue, ErrorMessage = "The Supplier field is required.")]
    public int SupplierId { get; set; } // Foreign key to Supplier

    [Required]
    public string UnitType { get; set; } = string.Empty;

    public decimal StockQuantity { get; set; }

    // Tag helper to set max length of string for description input
    [StringLength(30, ErrorMessage = "Description cannot exceed 30 characters.")]
    public string Description { get; set; } = string.Empty;

    public Supplier? Supplier { get; set; } // Navigation property for Suppliers
    public ICollection<InvoiceProduct> InvoiceProducts { get; set; } = new List<InvoiceProduct>(); // Navigation property for InvoiceProducts
    public ICollection<RecipeProduct>? RecipeProducts { get; set; } // Navigation property for RecipeProducts

    [ValidateNever]
    public Category Category { get; set; } = null!; // Navigation property for Category, configured to be required

}
