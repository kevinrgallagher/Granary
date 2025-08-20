using Microsoft.EntityFrameworkCore;
using Granary.Models.DomainModels;
using Granary.Models.DataLayer.Configuration;

namespace Granary.Models.DataLayer;

public class GranaryContext(DbContextOptions<GranaryContext> options) : DbContext(options)
{
    public DbSet<Invoice> Invoices { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Recipe> Recipes { get; set; } = null!;
    public DbSet<Supplier> Suppliers { get; set; } = null!;
    public DbSet<UnitType> UnitTypes { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<RecipeProduct> RecipeIngredients { get; set; } = null!;
    public DbSet<InvoiceProduct> InvoiceProducts { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new ConfigureCategories());
        modelBuilder.ApplyConfiguration(new ConfigureProducts());
        modelBuilder.ApplyConfiguration(new ConfigureSuppliers());
        modelBuilder.ApplyConfiguration(new ConfigureInvoices());
        modelBuilder.ApplyConfiguration(new ConfigureInvoiceProducts());
        modelBuilder.ApplyConfiguration(new ConfigureRecipes());
        modelBuilder.ApplyConfiguration(new ConfigureRecipeProducts());
        modelBuilder.ApplyConfiguration(new ConfigureUnitTypes());
    }
}
