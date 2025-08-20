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
            .Include(p => p.UnitType)
            .Select(p => new ProductViewModel
            {
                ProductId = p.ProductId,
                Name = p.ProductName,
                UnitTypeId = p.UnitTypeId,
                UnitTypeName = p.UnitType.Name,
                UnitTypeAbbreviation = p.UnitType.Abbreviation,
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
            Suppliers = new SelectList(context.Suppliers.ToList(), "SupplierId", "SupplierName"),
            UnitTypes = new SelectList(context.UnitTypes.ToList(), "UnitTypeId", "Name")
        };
        return View(vm);
    }

    // Navigate to AddCategory page
    [HttpGet]
    public IActionResult AddCategory()
    {
        return View();
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
        vm.UnitTypes = new SelectList(context.UnitTypes.ToList(), "UnitTypeId", "Name");
        return View(vm);
    }

    // Form submission for adding a category
    [HttpPost]
    public IActionResult AddCategory(Category category)
    {
        if (ModelState.IsValid)
        {
            var cat = new Category
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                Description = category.Description
            };

            context.Categories.Add(cat);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        // If model state is invalid, redisplay the form with validation errors
        return View("AddCategory", category);
    }
}

