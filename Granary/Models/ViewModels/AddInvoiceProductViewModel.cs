using Granary.Models.DomainModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Granary.Models.ViewModels;
public class AddInvoiceProductViewModel
{
    public InvoiceProduct InvoiceProduct { get; set; } = new();
    public int InvoiceProductId { get; set; } = new();
    public decimal UnitPrice { get; set; } = new();
    public decimal Quantity { get; set; } = new();

    public Invoice Invoice { get; set; } = new();
    public int ProductId { get; set; } = new();

    [BindNever]
    [ValidateNever]
    public SelectList Products { get; set; } = null!;

    public decimal LineItemValue => UnitPrice * Quantity;

}
