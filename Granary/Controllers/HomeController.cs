using Granary.Models.DataLayer;
using Granary.Models.DomainModels;
using Granary.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Granary.Controllers;

public class HomeController(GranaryContext context) : Controller // Using new C# 12 primary constructor

{
    // Navigate to Index page
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    // Navigate to Product page
    [HttpGet]
    public IActionResult Product()
    {
        // Using product view model for formatting and calculations
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
            .ToList();
        return View(productList);
    }

    // Navigate to Supplier page
    [HttpGet]
    public IActionResult Supplier()
    {
        var suppliers = context.Suppliers.ToList();
        return View(suppliers);
    }

    // Navigate to Recipe page
    [HttpGet]
    public IActionResult Recipe()
    {
        var recipes = context.Recipes.ToList();
        return View(recipes);
    }

    // Navigate to Invoice page
    [HttpGet]
    public IActionResult Invoice()
    {
        var invoices = context.Invoices
            .Include(i => i.Supplier)
            .ToList();
        return View(invoices);
    }

    // Navigate to AddProduct page, populate the dropdowns
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

    // Navigate to AddSupplier page
    [HttpGet]
    public IActionResult AddSupplier()
    {
        return View();
    }

    // Navigate to AddRecipe page
    [HttpGet]
    public IActionResult AddRecipe()
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
        // TODO: Re-fetch dropdown data once select lists are implemented properly
        return View("Supplier", supplier);
    }

    // Form submission for adding a recipe
    [HttpPost]
    public IActionResult AddRecipe(Recipe recipe)
    {
        if (ModelState.IsValid)
        {
            var rec = new Recipe
            {
                RecipeId = recipe.RecipeId,
                RecipeName = recipe.RecipeName,
                Description = recipe.Description
            };

            context.Recipes.Add(rec);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        // If model state is invalid, redisplay the form with validation errors
        // TODO: Re-fetch dropdown data once select lists are implemented properly
        return View("Recipe", recipe);
    }
}
