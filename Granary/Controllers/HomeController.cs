using Granary.Models.DataLayer;
using Granary.Models.DomainModels;
using Granary.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Granary.Controllers;

public class HomeController() : Controller // Using new C# 12 primary constructor

{
    // Navigate to Index page
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }  
}
