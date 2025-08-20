namespace Granary.Models.ViewModels;

public class ProductViewModel
{
    public int ProductId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int CategoryId { get; set; }
    public decimal StockQuantity { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public decimal AverageUnitPrice { get; set; }

    public int UnitTypeId { get; set; }
    public string UnitTypeName { get; set; } = string.Empty;
    public string UnitTypeAbbreviation { get; set; } = string.Empty;

    public decimal TotalValue => AverageUnitPrice * StockQuantity;

    public string FormattedStockWithUnitTypeAbbrev()
    {
        return $"{FormattedStockQuantity} {UnitTypeAbbreviation}";
    }

    public string FormattedUnitPriceWithUnitTypeAbbrev()
    {
        return $"{FormattedAverageUnitPrice}/{UnitTypeAbbreviation}";
    }

    public string FormattedStockQuantity =>
        StockQuantity % 1 == 0m
            ? StockQuantity.ToString("0")
            : StockQuantity.ToString("0.##");

    public string FormattedAverageUnitPrice =>
        AverageUnitPrice <= 0 ? "—" : AverageUnitPrice.ToString("C2");

    public string FormattedTotalValue =>
        AverageUnitPrice <= 0 ? "—" : TotalValue.ToString("C2");
}
