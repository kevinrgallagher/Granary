using System.ComponentModel.DataAnnotations;

namespace Granary.Models.DomainModels;

public class InvoiceProduct
{
    public int InvoiceProductId { get; set; } // Primary key for InvoiceProduct

    [Required]
    public int InvoiceId { get; set; } // Foreign key to Invoice

    [Required]
    public int ProductId { get; set; } // Foreign key to Product

    [Required]
    public decimal UnitPrice { get; set; } = 0.0m;

    public decimal Quantity { get; set; }

    public Invoice Invoice { get; set; } = null!; // Navigation property for Invoice
    public Product Product { get; set; } = null!; // Navigation property for Product
}
