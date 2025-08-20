using System.ComponentModel.DataAnnotations;

namespace Granary.Models.DomainModels;

public class UnitType
{
    public int UnitTypeId { get; set; }

    public int ProductId { get; set; } // Foreign key to Product

    [Required, MaxLength(50)]
    public string Name { get; set; } = string.Empty;

    [Required, MaxLength(10)]
    public string Abbreviation { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;

    public ICollection<Product> Products { get; set; } = new List<Product>(); // Navigation property for Products
}
