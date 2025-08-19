using System.ComponentModel.DataAnnotations;

namespace Granary.Models.DomainModels;

public class Invoice
{
    [Required]
    public int InvoiceId { get; set; } // Primary key, foreign key to InvoiceProduct

    [Required]
    public int SupplierId { get; set; } // Foreign key to Supplier

    [Required]
    public string InvoiceNumber { get; set; } = string.Empty;

    [Required]
    public DateTime InvoiceDate { get; set; } = DateTime.Now;

    [Required]
    public DateTime DueDate { get; set; } = DateTime.Now.AddDays(30);

    [Required]
    public string Status { get; set; } = "Pending"; // Default status is Pending

    public Supplier? Supplier { get; set; } // Navigation property for Supplier

    public ICollection<InvoiceProduct>? InvoiceProducts { get; set; } // Navigation property for InvoiceProducts

}
