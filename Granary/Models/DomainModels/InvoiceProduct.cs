using System.ComponentModel.DataAnnotations;

namespace Granary.Models.DomainModels;

public class InvoiceProduct
{
    public int InvoiceProductId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "InvoiceId missing.")]
    public int InvoiceId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Please select a product.")]
    public int ProductId { get; set; }

    [Range(0.01, 1000, ErrorMessage = "Please enter a unit price.")]
    public decimal UnitPrice { get; set; }

    [Range(0.01, 1000, ErrorMessage = "Please enter a quantity.")]
    public decimal Quantity { get; set; }

    public Invoice Invoice { get; set; } = null!;
    public Product Product { get; set; } = null!;
}
