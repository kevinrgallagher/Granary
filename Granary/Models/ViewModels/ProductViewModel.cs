namespace Granary.Models.ViewModels;

public class ProductViewModel
{
    public int ProductId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string UnitType { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int CategoryId { get; set; }
    public decimal StockQuantity { get; set; }

    // For populating product list UI with category name
    public string CategoryName { get; set; } = string.Empty;

    // For populating product list UI with average unit price over time
    public decimal AverageUnitPrice { get; set; }

    // Calculated field for total value of product in inventory
    public decimal TotalValue => AverageUnitPrice * StockQuantity;

    // For displaying total value
    public string FormattedTotalValue =>
    TotalValue % 1 == 0
        ? TotalValue.ToString("C0")
        : TotalValue.ToString("C2");

    // For displaying stock quantity
    public string FormattedStockQuantity =>
        StockQuantity % 1 == 0
            ? StockQuantity.ToString("0")
            : StockQuantity.ToString("0.##");

    // For displaying average unit price
    public string FormattedAverageUnitPrice =>
        AverageUnitPrice <= 0 ? "—" : AverageUnitPrice.ToString("0.##");
}

