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
                InvoiceDate = new DateTime(2024, 11, 15)
            },
            new Invoice
            {
                InvoiceId = 2,
                SupplierId = 2,
                InvoiceDate = new DateTime(2024, 12, 2)
            },
            new Invoice
            {
                InvoiceId = 3,
                SupplierId = 3,
                InvoiceDate = new DateTime(2025, 1, 7)
            },
            new Invoice
            {
                InvoiceId = 4,
                SupplierId = 4,
                InvoiceDate = new DateTime(2025, 2, 10)
            },
            new Invoice
            {
                InvoiceId = 5,
                SupplierId = 5,
                InvoiceDate = new DateTime(2025, 3, 3)
            }
        );
    }
}
