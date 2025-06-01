using Granary.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Granary.Models;

public class ConfigureInvoiceProducts : IEntityTypeConfiguration<InvoiceProduct>
{

    public void Configure(EntityTypeBuilder<InvoiceProduct> entity)
    {
        // Establish composite key for InvoiceProduct
        entity.HasKey(ip => new { ip.InvoiceId, ip.ProductId });

        // Establish required relationship between invoice product and invoice, deleting invoice deletes invoice products
        entity.HasOne(ip => ip.Invoice)
              .WithMany(i => i.InvoiceProducts)
              .HasForeignKey(ip => ip.InvoiceId)
              .IsRequired()
              .OnDelete(DeleteBehavior.Cascade);

        // Establish required relationship between invoice product and product, deleting product does not delete invoice products
        entity.HasOne(ip => ip.Product)
              .WithMany(p => p.InvoiceProducts)
              .HasForeignKey(ip => ip.ProductId)
              .IsRequired()
              .OnDelete(DeleteBehavior.Restrict);

        // Configure decimal precision
        entity.Property(p => p.Quantity)
            .HasColumnType("decimal(10, 2)");

        // Define composite key
        entity.HasKey(ip => new { ip.InvoiceId, ip.ProductId });

        entity.HasData(
            new InvoiceProduct { InvoiceId = 1, ProductId = 1, Quantity = 25.0m },
            new InvoiceProduct { InvoiceId = 1, ProductId = 2, Quantity = 15.0m },

            new InvoiceProduct { InvoiceId = 2, ProductId = 3, Quantity = 40.0m },
            new InvoiceProduct { InvoiceId = 2, ProductId = 4, Quantity = 20.0m },

            new InvoiceProduct { InvoiceId = 3, ProductId = 5, Quantity = 10.0m },
            new InvoiceProduct { InvoiceId = 3, ProductId = 6, Quantity = 12.0m },

            new InvoiceProduct { InvoiceId = 4, ProductId = 2, Quantity = 18.0m },
            new InvoiceProduct { InvoiceId = 4, ProductId = 3, Quantity = 22.0m },

            new InvoiceProduct { InvoiceId = 5, ProductId = 7, Quantity = 50.0m },
            new InvoiceProduct { InvoiceId = 5, ProductId = 8, Quantity = 30.0m }
        );
    }
}
