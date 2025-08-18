using System.ComponentModel.DataAnnotations;

namespace Granary.Models.DomainModels;


public class Supplier
{
    [Required]
    public int SupplierId { get; set; } // Primary key, foreign key to Product and Invoice

    [Required]
    public string SupplierName { get; set; } = string.Empty;

    [Required]
    public string ContactName { get; set; } = string.Empty;

    [Required]
    public string ContactEmail { get; set; } = string.Empty;

    [Required]
    public string ContactPhone { get; set; } = string.Empty;

    public ICollection<Product>? Products { get; set; } // Navigation property for Products
    public ICollection<Invoice>? Invoices { get; set; } // Navigation property for Invoices

}
