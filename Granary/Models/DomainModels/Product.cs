using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Granary.Models.DomainModels;

public class Product
{
    public int ProductId { get; set; } // Primary key, foreign key to the three join tables

    [Required(ErrorMessage="Please enter the name of the product.")]
    public string ProductName { get; set; } = string.Empty;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Please select a category.")]
    public int CategoryId { get; set; } // Foreign key to Category

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Please select a supplier.")]
    public int SupplierId { get; set; } // Foreign key to Supplier
    
    [Range(1, int.MaxValue, ErrorMessage = "Please select a unit type.")]
    public int UnitTypeId { get; set; } // Foreign key to UnitType

    [Required]
    [Range(0, 1000, ErrorMessage = "Stock quantity cannot exceed 1,000 units.")]
    public decimal StockQuantity { get; set; }

    [StringLength(30, ErrorMessage = "Description cannot exceed 30 characters.")]
    public string Description { get; set; } = string.Empty;

    public Supplier? Supplier { get; set; } // Navigation property for Suppliers
    public ICollection<InvoiceProduct> InvoiceProducts { get; set; } = new List<InvoiceProduct>(); // Navigation property for InvoiceProducts
    public ICollection<RecipeProduct>? RecipeProducts { get; set; } // Navigation property for RecipeProducts

    [ValidateNever]
    public Category Category { get; set; } = null!; // Navigation property for Category
    public UnitType UnitType { get; set; } = default!; // Navigation property for UnitType

}
