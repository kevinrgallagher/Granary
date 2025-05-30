namespace Granary.Models.DomainModels;

public class InvoiceProduct
{
    public int InvoiceId { get; set; } // Composite key one, foreign key to Invoice
    public int ProductId { get; set; } // Composite key two, foreign key to Product
    public decimal Quantity { get; set; }

    public Invoice Invoice { get; set; } = null!; // Navigation property for Invoice
    public Product Product { get; set; } = null!; // Navigation property for Product
}
