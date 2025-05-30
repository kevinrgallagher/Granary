using Granary.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Granary.Models
{
    public class ConfigureSuppliers : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> entity)
        {
            entity.HasData(
                new Supplier
                {
                    SupplierId = 1,
                    SupplierName = "Fresh Farms Co."
                },
                new Supplier
                {
                    SupplierId = 2,
                    SupplierName = "Harvest Supply Ltd."
                },
                new Supplier
                {
                    SupplierId = 3,
                    SupplierName = "Mushroom Masters"
                },
                new Supplier
                {
                    SupplierId = 4,
                    SupplierName = "Tomato Town Inc."
                },
                new Supplier
                {
                    SupplierId = 5,
                    SupplierName = "Onion Bros."
                }
            );
        }
    }
}
