namespace Granary.Models.ViewModels;

public class InventoryViewModel
{
    public int ProductId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string UnitType { get; set; } = string.Empty;
    public decimal UnitPrice { get; set; }
    public decimal StockQuantity { get; set; }

    // Calculated field for total value of product in inventory
    public decimal TotalValue => UnitPrice * StockQuantity;

    // Formatted string for displaying total value without unnecessary trailing zeroes
    public string FormattedTotalValue =>
    TotalValue % 1 == 0
        ? TotalValue.ToString("C0")
        : TotalValue.ToString("C2");

    // Formatted string for displaying unit price without unnecessary trailing zeroes
    public string FormattedUnitPrice =>
    UnitPrice % 1 == 0
        ? UnitPrice.ToString("C0")
        : UnitPrice.ToString("C2");

    // Formatted string for displaying stock quantity without unnecessary trailing zeroes
    public string FormattedStockQuantity =>
        StockQuantity % 1 == 0
            ? StockQuantity.ToString("0")
            : StockQuantity.ToString("0.##");
}   

