using Granary.Models;
using Granary.Models.DataLayer;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// EF Core logging hook (Program.cs or similar)
builder.Logging.AddConsole();
builder.Services.AddDbContext<GranaryContext>(o =>
    o.UseSqlServer("GranaryContext").EnableSensitiveDataLogging());

// Register GranaryContext with SQL server and connection string
builder.Services.AddDbContext<GranaryContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GranaryContext")));

// Register services for MVC pattern
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
