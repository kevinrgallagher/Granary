using Granary.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Granary.Models;

public class ConfigureInvoices : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> entity)
    {
        entity.HasData(
            new Invoice
            {
                InvoiceId = 1,
                SupplierId = 1,
                InvoiceDate = new DateTime(2024, 11, 15),
                InvoiceNumber = "INV-1001",
                DueDate = new DateTime(2024, 12, 15),
                Status = "Pending"
            },
            new Invoice
            {
                InvoiceId = 2,
                SupplierId = 2,
                InvoiceDate = new DateTime(2024, 12, 2),
                InvoiceNumber = "INV-1002",
                DueDate = new DateTime(2025, 1, 2),
                Status = "Paid"
            },
            new Invoice
            {
                InvoiceId = 3,
                SupplierId = 3,
                InvoiceDate = new DateTime(2025, 1, 7),
                InvoiceNumber = "INV-1003",
                DueDate = new DateTime(2025, 2, 7),
                Status = "Pending"
            },
            new Invoice
            {
                InvoiceId = 4,
                SupplierId = 4,
                InvoiceDate = new DateTime(2025, 2, 10),
                InvoiceNumber = "INV-1004",
                DueDate = new DateTime(2025, 3, 10),
                Status = "Overdue"
            },
            new Invoice
            {
                InvoiceId = 5,
                SupplierId = 5,
                InvoiceDate = new DateTime(2025, 3, 3),
                InvoiceNumber = "INV-1005",
                DueDate = new DateTime(2025, 4, 3),
                Status = "Paid"
            }
        );
    }
}
