using Granary.Models.DataLayer;
using Granary.Models.DomainModels;
using Granary.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Granary.Controllers;

public class ProductController(GranaryContext context) : Controller // Using new C# 12 primary constructor
{
    // Navigate to Product page
    [HttpGet]
    public IActionResult Index()
    {
        var productList = context.Products
            .Include(p => p.Category)
            .Select(p => new ProductViewModel
            {
                ProductId = p.ProductId,
                Name = p.ProductName,
                UnitType = p.UnitType,
                StockQuantity = p.StockQuantity,
                Description = p.Description,
                CategoryId = p.CategoryId,
                CategoryName = p.Category.CategoryName,
                // Average of most recent five unit prices from associated invoice lines
                AverageUnitPrice = p.InvoiceProducts
                    .OrderByDescending(ip => ip.Invoice.InvoiceDate)
                    .Select(ip => (decimal?)ip.UnitPrice) // cast so Average() works on empty
                    .Take(5)
                    .Average() ?? 0m
            })
            .AsNoTracking()
            .ToList();

        return View(productList);
    }

    // Navigate to AddProduct page and populate the dropdowns
    [HttpGet]
    public IActionResult AddProduct()
    {
        var vm = new AddProductViewModel
        {
            Categories = new SelectList(context.Categories.ToList(), "CategoryId", "CategoryName"),
            Suppliers = new SelectList(context.Suppliers.ToList(), "SupplierId", "SupplierName")
        };
        return View(vm);
    }

    // Navigate to AddCategory page
    [HttpGet]
    public IActionResult AddCategory()
    {
        var recipes = context.Recipes.ToList();
        return View(recipes);
    }

    // Form submission for adding a product
    [HttpPost]
    public IActionResult AddProduct(AddProductViewModel vm)
    {
        if (ModelState.IsValid)
        {
            context.Products.Add(vm.Product);
            context.SaveChanges();
            return RedirectToAction("Product");
        }

        // If invalid, re-populate the categories dropdown and return to the view
        vm.Categories = new SelectList(context.Categories.ToList(), "CategoryId", "CategoryName");
        vm.Suppliers = new SelectList(context.Suppliers.ToList(), "SupplierId", "SupplierName");
        return View(vm);
    }
}

