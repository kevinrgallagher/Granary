using Granary.Models.DataLayer;
using Granary.Models.DomainModels;
using Granary.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Granary.Controllers;

public class InvoiceController(GranaryContext context) : Controller // Using new C# 12 primary constructor
{
    // Navigate to Invoice page
    [HttpGet]
    public IActionResult Index()
    {
        var invoices = context.Invoices
            .Include(i => i.Supplier)
            .ToList();
        return View(invoices);
    }

    // Navigate to AddInvoice page, populate the supplier dropdown
    [HttpGet]
    public IActionResult AddInvoice()
    {
        var vm = new AddInvoiceViewModel
        {
            Suppliers = new SelectList(context.Suppliers.ToList(), "SupplierId", "SupplierName")
        };
        return View(vm);
    }

    // Navigate to AddInvoiceProduct page, populate the products dropdown
    [HttpGet]
    public IActionResult AddInvoiceProduct(int id) // id = InvoiceId
    {
        // Get the invoice and include supplier details
        var invoice = context.Invoices
            .Include(i => i.Supplier)
            .FirstOrDefault(i => i.InvoiceId == id);
        if (invoice == null) return NotFound();

        // Get products, filtered by supplier, and create a formatted list of SelectListItems
        var items = context.Products
            .Where(p => p.SupplierId == invoice.SupplierId)
            .OrderBy(p => p.ProductName)
            .Select(p => new SelectListItem
            {
                Value = p.ProductId.ToString(),
                Text = p.ProductName + " (" + p.UnitType.Abbreviation + ")"
            })
            .ToList();

        // Create view model, project the invoice, create a new invoice product, and populate the dropdown
        var vm = new AddInvoiceProductViewModel
        {
            Invoice = invoice,
            // Pre-set the FK so the hidden field has a value
            InvoiceProduct = new InvoiceProduct { InvoiceId = id },
            Products = new SelectList(items, "Value", "Text")
        };

        // Return the view model to the view
        return View(vm);
    }

    // Form submission for adding an invoice product
    [HttpPost]
    public IActionResult AddInvoiceProduct(AddInvoiceProductViewModel vm)
    {
        if (ModelState.IsValid)
        {

            context.InvoiceProducts.Add(vm.InvoiceProduct);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
              
        // Rebuild list
        var items = context.Products
            .OrderBy(p => p.ProductName)
            .Select(p => new SelectListItem
            {
                Value = p.ProductId.ToString(),
                Text = p.ProductName + " (" + p.UnitType.Abbreviation + ")"
            })
            .ToList();


        var invId = vm?.InvoiceProduct?.InvoiceId ?? 0;
        vm!.Invoice = context.Invoices
            .Include(i => i.Supplier)
            .FirstOrDefault(i => i.InvoiceId == vm.InvoiceProduct.InvoiceId) ?? new Invoice();

        var selectedProductId = vm?.InvoiceProduct?.ProductId;
        vm!.Products = new SelectList(items, "Value", "Text", selectedProductId);
        vm.SupplierName = context.Invoices
            .Include(i => i.Supplier)
            .Where(i => i.InvoiceId == invId)
            .Select(i => i.Supplier != null ? i.Supplier.SupplierName : null)
            .FirstOrDefault()
            ?? "Unknown Supplier";

        return View(vm);
    }
}

