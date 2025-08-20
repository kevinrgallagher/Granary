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
        return View(vm);
    }
}

