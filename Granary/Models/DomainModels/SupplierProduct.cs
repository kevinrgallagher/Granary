using System.ComponentModel.DataAnnotations;

namespace Granary.Models.DomainModels;

public class SupplierProduct
{
    [Required]
    public int SupplierId { get; set; } // Composite key one, foreign key to Supplier

    [Required]
    public int ProductId { get; set; } // Composite key two, foreign key to Product

    public Supplier Supplier { get; set; } = null!; // Navigation property for Supplier
    public Product Product { get; set; } = null!; // Navigation property for Product
}
