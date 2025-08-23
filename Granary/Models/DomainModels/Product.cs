using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Granary.Models.DomainModels;

public class Product
{
    public int ProductId { get; set; } // Primary key, foreign key to Product

    [Range(1, int.MaxValue, ErrorMessage = "Please select a supplier.")]
    public int SupplierId { get; set; } // Foreign key to Supplier

    [Range(1, int.MaxValue, ErrorMessage = "Please select a unit type.")]
    public int UnitTypeId { get; set; } // Foreign key to UnitType

    [Required(ErrorMessage="Please enter the name of the product.")]
    public string ProductName { get; set; } = string.Empty;

    [Range(1, int.MaxValue, ErrorMessage = "Please select a category.")]
    public int CategoryId { get; set; } // Foreign key to Category

    [Range(0, 1000, ErrorMessage = "Stock quantity cannot exceed 1,000 units.")]
    public decimal StockQuantity { get; set; }

    [StringLength(30, ErrorMessage = "Description cannot exceed 30 characters.")]
    public string Description { get; set; } = string.Empty;

    public ICollection<InvoiceProduct> InvoiceProducts { get; set; } = new List<InvoiceProduct>(); // Navigation property for InvoiceProducts
    public ICollection<RecipeProduct>? RecipeProducts { get; set; } // Navigation property for RecipeProducts

    public Supplier? Supplier { get; set; } // Navigation property for Suppliers

    [BindNever, ValidateNever] public Category Category { get; set; } = null!; // Navigation property for Category
    [BindNever, ValidateNever] public UnitType UnitType { get; set; } = default!; // Navigation property for UnitType
}
