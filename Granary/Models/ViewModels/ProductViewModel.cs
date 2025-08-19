namespace Granary.Models.ViewModels;

public class ProductViewModel
{
    public int ProductId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string UnitType { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int CategoryId { get; set; }

    // For populating product list UI with category name
    public string CategoryName { get; set; } = string.Empty;

    // For populating product list UI with average unit price over time
    public decimal AverageUnitPrice { get; set; }

    // For displaying average unit price in a user-friendly format
    public string FormattedAverageUnitPrice =>
        AverageUnitPrice <= 0 ? "—" : AverageUnitPrice.ToString("0.##");
}

