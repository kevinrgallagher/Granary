using Granary.Models.DataLayer;
using Granary.Models.DomainModels;
using Granary.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Granary.Controllers;

public class HomeController(GranaryContext context) : Controller // Using new C# 12 primary constructor
{
    public IActionResult Index()
    {
        return View();
    }

    // Navigate to Inventory page
    public IActionResult Inventory()
    {
        // Using inventory view model for formatting and calculations
        var inventory = context.Products
            .Include(p => p.Category)
            .Select(p => new InventoryViewModel
            {
                ProductId = p.ProductId,
                Name = p.ProductName,
                UnitType = p.UnitType,
                UnitPrice = p.UnitPrice,
                StockQuantity = p.StockQuantity,
                CategoryName = p.Category.CategoryName
            })
            .ToList();
        return View(inventory);
    }

    // Navigate to Product page
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
                UnitPrice = p.UnitPrice,
                Description = p.Description,
                CategoryId = p.CategoryId,
                CategoryName = p.Category.CategoryName
            })
            .ToList();
        return View(productList);
    }

    // Navigate to Supplier page
    public IActionResult Supplier()
    {
        var suppliers = context.Suppliers.ToList();
        return View(suppliers);
    }

    // Navigate to Recipe page
    public IActionResult Recipe()
    {
        var recipes = context.Recipes.ToList();
        return View(recipes);
    }

    // Navigate to Invoice page
    public IActionResult Invoice()
    {
        var invoices = context.Invoices.ToList();
        return View(invoices);
    }

    [HttpGet]
    public IActionResult AddProduct()
    {
        var vm = new AddProductViewModel
        {
            Categories = new SelectList(context.Categories.ToList(), "CategoryId", "CategoryName")
        };
        return View(vm);
    }

    // Navigate to AddSupplier page
    public IActionResult AddSupplier()
    {
        return View();
    }

    // Navigate to AddInvoice page
    public IActionResult AddInvoice()
    {
        return View();
    }

    // Navigate to AddRecipe page
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

    // Form submission for adding an invoice
    [HttpPost]
    public IActionResult AddInvoice(Invoice invoice)
    {
        if (ModelState.IsValid)
        {
            var inv = new Invoice
            {
                InvoiceId = invoice.InvoiceId,
                SupplierId = invoice.SupplierId,
                InvoiceNumber = invoice.InvoiceNumber,
                InvoiceDate = invoice.InvoiceDate,
                DueDate = invoice.DueDate,
                Status = invoice.Status,
            };

            context.Invoices.Add(inv);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        // If model state is invalid, redisplay the form with validation errors
        // TODO: Re-fetch dropdown data once select lists are implemented properly
        return View("Invoice", invoice);
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
