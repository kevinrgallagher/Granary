namespace Granary.Models.DomainModels;

public class Supplier
{
    public int SupplierId { get; set; } // Primary key, foreign key to SupplierProduct and Invoice
    public string SupplierName { get; set; } = string.Empty;

    public ICollection<SupplierProduct>? SupplierProducts { get; set; } // Navigation property for SupplierProducts
    public ICollection<Invoice>? Invoices { get; set; } // Navigation property for Invoices

}
