﻿using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;


namespace Granary.Models.DomainModels;

public class Product
{
    public int ProductId { get; set; } // Primary key, foreign key to the three join tables

    [Range(1, int.MaxValue, ErrorMessage = "Please select a category.")]
    public int CategoryId { get; set; } // Foreign key to Category

    public string ProductName { get; set; } = string.Empty;

    public string UnitType { get; set; } = string.Empty;

    public decimal UnitPrice { get; set; } = 0.0m;

    public decimal StockQuantity { get; set; }

    public string Description { get; set; } = string.Empty;

    public ICollection<SupplierProduct>? SupplierProducts { get; set; } // Navigation property for SupplierProducts
    public ICollection<InvoiceProduct>? InvoiceProducts { get; set; } // Navigation property for InvoiceProducts
    public ICollection<RecipeProduct>? RecipeProducts { get; set; } // Navigation property for RecipeProducts

    [ValidateNever]
    public Category Category { get; set; } = null!; // Navigation property for Category, configured to be required

}