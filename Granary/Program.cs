using Microsoft.EntityFrameworkCore;
using Granary.Models;
using Granary.Models.DataLayer;

var builder = WebApplication.CreateBuilder(args);

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
