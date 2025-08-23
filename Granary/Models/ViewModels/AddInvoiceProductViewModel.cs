using Granary.Models.DomainModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Granary.Models.ViewModels;
public class AddInvoiceProductViewModel
{
    public InvoiceProduct InvoiceProduct { get; set; } = new();

    [BindNever, ValidateNever]
    public Invoice Invoice { get; set; } = new();

    [ValidateNever]
    public string? SupplierName { get; set; } = "No supplier found.";

    [ValidateNever]
    public string? InvoiceNumber { get; set; } = "No invoice found.";

    [BindNever, ValidateNever]
    public SelectList Products { get; set; } = null!;

    public decimal LineItemValue => InvoiceProduct.UnitPrice * InvoiceProduct.Quantity;

}
