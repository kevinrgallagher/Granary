using Granary.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Granary.Models.DataLayer.Configuration;

public class ConfigureInvoiceProducts : IEntityTypeConfiguration<InvoiceProduct>
{
    public void Configure(EntityTypeBuilder<InvoiceProduct> entity)
    {
        // Define composite key (InvoiceId + ProductId)
        entity.HasKey(ip => new { ip.InvoiceId, ip.ProductId });

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
            new InvoiceProduct { InvoiceId = 1, ProductId = 1, Quantity = 25.00m, UnitPrice = 2.99m },
            new InvoiceProduct { InvoiceId = 2, ProductId = 2, Quantity = 15.00m, UnitPrice = 1.49m },

            // Invoice 2
            new InvoiceProduct { InvoiceId = 3, ProductId = 3, Quantity = 40.00m, UnitPrice = 1.25m },
            new InvoiceProduct { InvoiceId = 4, ProductId = 4, Quantity = 20.00m, UnitPrice = 3.25m },

            // Invoice 3
            new InvoiceProduct { InvoiceId = 5, ProductId = 5, Quantity = 10.00m, UnitPrice = 1.99m },
            new InvoiceProduct { InvoiceId = 6, ProductId = 6, Quantity = 12.00m, UnitPrice = 0.75m },

            // Invoice 4
            new InvoiceProduct { InvoiceId = 7, ProductId = 7, Quantity = 18.00m, UnitPrice = 1.49m },
            new InvoiceProduct { InvoiceId = 8, ProductId = 8, Quantity = 22.00m, UnitPrice = 1.25m },

            // Invoice 5
            new InvoiceProduct { InvoiceId = 9, ProductId = 9, Quantity = 50.00m, UnitPrice = 0.89m },
            new InvoiceProduct { InvoiceId = 10, ProductId = 10, Quantity = 30.00m, UnitPrice = 1.10m }
        );
    }
}
