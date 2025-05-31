namespace Granary.Models.DomainModels;

public class Invoice
{
    public int InvoiceId { get; set; } // Primary key, foreign key to InvoiceProduct
    public int SupplierId { get; set; } // Foreign key to Supplier
    public string InvoiceNumber { get; set; } = string.Empty;
    public DateTime InvoiceDate { get; set; } = DateTime.Now;
    public DateTime DueDate { get; set; } = DateTime.Now.AddDays(30);
    public string Status { get; set; } = "Pending"; // Default status is Pending

    public ICollection<InvoiceProduct>? InvoiceProducts { get; set; } // Navigation property for InvoiceProducts
    public Supplier? Supplier { get; set; } // Navigation property for Supplier
}
