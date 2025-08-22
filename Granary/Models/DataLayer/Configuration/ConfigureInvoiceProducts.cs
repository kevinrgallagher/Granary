using Granary.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Granary.Models.DataLayer.Configuration;

public class ConfigureInvoiceProducts : IEntityTypeConfiguration<InvoiceProduct>
{
    public void Configure(EntityTypeBuilder<InvoiceProduct> entity)
    {
        // InvoiceProduct (dependent) → Invoice (principal), required FK
        // Delete behavior: Cascade — deleting an Invoice deletes its InvoiceProducts
        entity.HasOne(ip => ip.Invoice)
              .WithMany(i => i.InvoiceProducts)
              .HasForeignKey(ip => ip.InvoiceId)
              .IsRequired()
              .OnDelete(DeleteBehavior.Cascade);

        // InvoiceProduct (dependent) → Product (principal), required FK
        // Delete behavior: Restrict — cannot delete a Product while InvoiceProducts reference it
        entity.HasOne(ip => ip.Product)
              .WithMany(p => p.InvoiceProducts)
              .HasForeignKey(ip => ip.ProductId)
              .IsRequired()
              .OnDelete(DeleteBehavior.Restrict);

        // Configure decimal precision for quantity (e.g., 25.00)
        entity.Property(ip => ip.Quantity)
              .HasColumnType("decimal(10, 2)");

        // Configure decimal precision for price at time of purchase (e.g., 2.99)
        entity.Property(ip => ip.UnitPrice)
              .HasColumnType("decimal(10, 2)");

        // Seed data
        entity.HasData(
            // Invoice 1
            new InvoiceProduct { InvoiceProductId = 1, InvoiceId = 1, ProductId = 1, Quantity = 25.00m, UnitPrice = 2.99m },
            new InvoiceProduct { InvoiceProductId = 2, InvoiceId = 1, ProductId = 2, Quantity = 15.00m, UnitPrice = 1.49m },

            // Invoice 2
            new InvoiceProduct { InvoiceProductId = 3, InvoiceId = 2, ProductId = 3, Quantity = 40.00m, UnitPrice = 1.25m },
            new InvoiceProduct { InvoiceProductId = 4, InvoiceId = 2, ProductId = 4, Quantity = 20.00m, UnitPrice = 3.25m },

            // Invoice 3
            new InvoiceProduct { InvoiceProductId = 5, InvoiceId = 3, ProductId = 5, Quantity = 10.00m, UnitPrice = 1.99m },
            new InvoiceProduct { InvoiceProductId = 6, InvoiceId = 3, ProductId = 6, Quantity = 12.00m, UnitPrice = 0.75m },

            // Invoice 4
            new InvoiceProduct { InvoiceProductId = 7, InvoiceId = 4, ProductId = 7, Quantity = 18.00m, UnitPrice = 1.49m },
            new InvoiceProduct { InvoiceProductId = 8, InvoiceId = 4, ProductId = 8, Quantity = 22.00m, UnitPrice = 1.25m },

            // Invoice 5
            new InvoiceProduct { InvoiceProductId = 9, InvoiceId = 5, ProductId = 9, Quantity = 50.00m, UnitPrice = 0.89m },
            new InvoiceProduct { InvoiceProductId = 10, InvoiceId = 5, ProductId = 10, Quantity = 30.00m, UnitPrice = 1.10m }
        );
    }
}
