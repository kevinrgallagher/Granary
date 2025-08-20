using Granary.Models.DataLayer;
using Granary.Models.DomainModels;
using Granary.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Granary.Controllers;

public class SupplierController(GranaryContext context) : Controller // Using new C# 12 primary constructor
{
    // Navigate to Supplier page
    [HttpGet]
    public IActionResult Index()
    {
        var suppliers = context.Suppliers.ToList();
        return View(suppliers);
    }

    // Navigate to AddSupplier page
    [HttpGet]
    public IActionResult AddSupplier()
    {
        return View();
    }

    // Form submission for adding a supplier
    [HttpPost]
    public IActionResult AddSupplier(Supplier supplier)
    {
        if (ModelState.IsValid)
        {
            var sup = new Supplier
            {
                SupplierId = supplier.SupplierId,
                SupplierName = supplier.SupplierName,
                ContactName = supplier.ContactName,
                ContactEmail = supplier.ContactEmail,
                ContactPhone = supplier.ContactPhone
            };

            context.Suppliers.Add(sup);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        // If model state is invalid, redisplay the form with validation errors
        return View("AddSupplier", supplier);
    }
}

