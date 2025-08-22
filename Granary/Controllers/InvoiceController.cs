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
    public IActionResult AddInvoiceProduct(int id)
    {
        var invoiceNumber = context.Invoices
            .Where(i => i.InvoiceId == id)
            .Select(i => i.InvoiceNumber)
            .FirstOrDefault();

        string supplierName = context.Invoices
            .Where(i => i.InvoiceId == id)
            .Select(i => i.Supplier != null ? i.Supplier.SupplierName : "Unknown Supplier")
            .FirstOrDefault() ?? "Unknown Supplier";

        var vm = new AddInvoiceProductViewModel
        {
            InvoiceProduct = new InvoiceProduct
            {
                InvoiceId = id,
                ProductId = 0, // Default to no product selected
                UnitPrice = 0.0m,
                Quantity = 0.0m,
            },
            SupplierName = supplierName,
            InvoiceNumber = invoiceNumber ?? string.Empty,
            Products = new SelectList(context.Products.ToList(), "ProductId", "ProductName")
        };

        vm.Products = new SelectList(context.Products.ToList(), "ProductId", "ProductName");
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

        // If invalid, re-populate product dropdown
        vm.Products = new SelectList(context.Products.ToList(), "ProductId", "ProductName");
        return View(vm);
    }

    // Form submission for adding an invoice
    [HttpPost]
    public IActionResult AddInvoice(AddInvoiceViewModel vm)
    {
        if (ModelState.IsValid)
        {
            context.Invoices.Add(vm.Invoice);
            context.SaveChanges();
            return RedirectToAction("Invoice");
        }

        // If invalid, re-populate the suppliers dropdown and return to the view
        vm.Suppliers = new SelectList(context.Suppliers.ToList(), "SupplierId", "SupplierName");
        return View("AddInvoice", vm);
    }
}

