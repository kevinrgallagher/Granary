using Granary.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Granary.Models;

public class ConfigureSuppliers : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> entity)
    {
        // Establish required relationship between supplier and invoice, cannot delete supplier if invoice exist
        entity.HasMany(s => s.Invoices)
              .WithOne(i => i.Supplier)
              .HasForeignKey(i => i.SupplierId)
              .IsRequired()
              .OnDelete(DeleteBehavior.Restrict);

        // Establish required relationship between supplier and product, cannot delete supplier if product exist
        entity.HasMany(s => s.Products)
              .WithOne(p => p.Supplier)
              .HasForeignKey(p => p.SupplierId)
              .IsRequired()
              .OnDelete(DeleteBehavior.Restrict);

        entity.HasData(
            new Supplier
            {
                SupplierId = 1,
                SupplierName = "Fresh Farms Co.",
                ContactName = "Lena Ortiz",
                ContactEmail = "lena@freshfarms.com",
                ContactPhone = "555-101-0001"
            },
            new Supplier
            {
                SupplierId = 2,
                SupplierName = "Harvest Supply Ltd.",
                ContactName = "Marcus Liu",
                ContactEmail = "marcus@harvestsupply.com",
                ContactPhone = "555-101-0002"
            },
            new Supplier
            {
                SupplierId = 3,
                SupplierName = "Mushroom Masters",
                ContactName = "Jill Tanaka",
                ContactEmail = "jill@mushroommasters.com",
                ContactPhone = "555-101-0003"
            },
            new Supplier
            {
                SupplierId = 4,
                SupplierName = "Tomato Town Inc.",
                ContactName = "Rick Valenti",
                ContactEmail = "rick@tomatotown.com",
                ContactPhone = "555-101-0004"
            },
            new Supplier
            {
                SupplierId = 5,
                SupplierName = "Onion Bros.",
                ContactName = "Nina Patel",
                ContactEmail = "nina@onionbros.com",
                ContactPhone = "555-101-0005"
            }
        );
    }
}
