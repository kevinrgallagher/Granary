using Granary.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Granary.Models;

public class ConfigureSupplierProducts : IEntityTypeConfiguration<SupplierProduct>
{
    public void Configure(EntityTypeBuilder<SupplierProduct> entity)
    {
        // Define composite primary key
        entity.HasKey(sp => new { sp.SupplierId, sp.ProductId });

        // Establish required relationship between supplier product and supplier, cannot delete supplier if supplier products exist
        entity.HasOne(sp => sp.Supplier)
              .WithMany(s => s.SupplierProducts)
              .HasForeignKey(sp => sp.SupplierId)
              .IsRequired()
              .OnDelete(DeleteBehavior.Restrict);

        // Establish required relationship between supplier product and product, cannot delete product if supplier products exist
        entity.HasOne(sp => sp.Product)
              .WithMany(p => p.SupplierProducts)
              .HasForeignKey(sp => sp.ProductId)
              .IsRequired()
              .OnDelete(DeleteBehavior.Restrict);

        entity.HasData(
            new SupplierProduct { SupplierId = 1, ProductId = 1 },
            new SupplierProduct { SupplierId = 1, ProductId = 2 },
            new SupplierProduct { SupplierId = 2, ProductId = 3 },
            new SupplierProduct { SupplierId = 2, ProductId = 4 },
            new SupplierProduct { SupplierId = 3, ProductId = 5 },
            new SupplierProduct { SupplierId = 3, ProductId = 6 },
            new SupplierProduct { SupplierId = 4, ProductId = 2 },
            new SupplierProduct { SupplierId = 4, ProductId = 3 },
            new SupplierProduct { SupplierId = 5, ProductId = 7 },
            new SupplierProduct { SupplierId = 5, ProductId = 8 }
        );
    }
}
