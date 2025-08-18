using System.ComponentModel.DataAnnotations;

namespace Granary.Models.DomainModels;

public class InvoiceProduct
{
    [Required]
    public int InvoiceId { get; set; } // Composite key one, foreign key to Invoice

    [Required]
    public int ProductId { get; set; } // Composite key two, foreign key to Product

    [Required]

    public string UnitType { get; set; } = string.Empty;

    [Required]
    public decimal UnitPrice { get; set; } = 0.0m;

    public decimal Quantity { get; set; }

    public Invoice Invoice { get; set; } = null!; // Navigation property for Invoice
    public Product Product { get; set; } = null!; // Navigation property for Product
}
