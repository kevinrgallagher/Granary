using Granary.Models.DataLayer;
using Granary.Models.DomainModels;
using Granary.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Granary.Controllers;

public class RecipeController(GranaryContext context) : Controller // Using new C# 12 primary constructor
{
    // Navigate to Recipe page
    [HttpGet]
    public IActionResult Index()
    {
        var recipes = context.Recipes.ToList();
        return View(recipes);
    }

    // Navigate to AddRecipe page
    [HttpGet]
    public IActionResult AddRecipe()
    {
        return View();
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
        return View("Recipe", recipe);
    }
}

