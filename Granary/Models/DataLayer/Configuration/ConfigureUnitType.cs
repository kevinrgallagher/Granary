using Granary.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Granary.Models.DataLayer.Configuration;

public class ConfigureUnitTypes : IEntityTypeConfiguration<UnitType>
{
    public void Configure(EntityTypeBuilder<UnitType> entity)
    {
        // Establish required relationship between unit type and product, cannot delete unit type if products exist
        entity.HasMany(u => u.Products)
              .WithOne(p => p.UnitType)
              .HasForeignKey(p => p.UnitTypeId)
              .IsRequired()
              .OnDelete(DeleteBehavior.Restrict);

        // Seed data
        entity.HasData(
            new UnitType
            {
                UnitTypeId = 1,
                Name = "Ounce",
                Abbreviation = "oz",
                IsActive = true
            },
            new UnitType
            {
                UnitTypeId = 2,
                Name = "Pound",
                Abbreviation = "lb",
                IsActive = true
            },
            new UnitType
            {
                UnitTypeId = 3,
                Name = "Gallon",
                Abbreviation = "gal",
                IsActive = true
            },
            new UnitType
            {
                UnitTypeId = 4,
                Name = "Each",
                Abbreviation = "ea",
                IsActive = true
            });
    }
}


