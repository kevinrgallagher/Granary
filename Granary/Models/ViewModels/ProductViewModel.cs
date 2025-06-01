namespace Granary.Models.ViewModels;

public class ProductViewModel
{
    public int ProductId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string UnitType { get; set; } = string.Empty;
    public decimal UnitPrice { get; set; }
    public string Description { get; set; } = string.Empty;
    public int CategoryId { get; set; }

    // For populating product list UI with category name
    public string CategoryName { get; set; } = string.Empty;

    // Formatted string for displaying unit price without unnecessary trailing zeroes
    public string FormattedUnitPrice =>
    UnitPrice % 1 == 0
        ? UnitPrice.ToString("C0")
        : UnitPrice.ToString("C2");
}
