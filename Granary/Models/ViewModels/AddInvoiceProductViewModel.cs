using Granary.Models.DomainModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Granary.Models.ViewModels;
public class AddInvoiceProductViewModel
{
    public InvoiceProduct InvoiceProduct { get; set; } = new();

    public int InvoiceId { get; set; }

    public int ProductId { get; set; }

    public string InvoiceNumber { get; set; } = string.Empty;

    public string SupplierName { get; set; } = string.Empty;

    
    [BindNever]
    [ValidateNever]
    public SelectList Products { get; set; } = null!;

    public decimal LineItemValue => InvoiceProduct.UnitPrice * InvoiceProduct.Quantity;

}
