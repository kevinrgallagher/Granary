using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Granary.Migrations
{
    /// <inheritdoc />
    public partial class FirstTry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    RecipeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.RecipeId);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    StockQuantity = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_Invoices_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeIngredients",
                columns: table => new
                {
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredients", x => new { x.RecipeId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupplierProducts",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierProducts", x => new { x.SupplierId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_SupplierProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupplierProducts_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceProducts",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceProducts", x => new { x.InvoiceId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_InvoiceProducts_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "InvoiceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Includes all tomato varieties like Roma, Cherry, and Beefsteak.", "Tomatoes" },
                    { 2, "Covers common edible mushrooms such as White, Portobello, and Shiitake.", "Mushrooms" },
                    { 3, "Includes Yellow, Red, Sweet, and specialty onions like Cippolini.", "Onions" }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "RecipeId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "A warm and savory soup made from fresh tomatoes and onions.", "Tomato Soup" },
                    { 2, "Mushroom caps filled with a savory onion and herb blend.", "Stuffed Mushrooms" },
                    { 3, "A classic Italian-style tomato and mushroom sauce.", "Marinara Sauce" },
                    { 4, "A fresh salad combining red and yellow onions with cherry tomatoes.", "Onion Salad" }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "SupplierId", "SupplierName" },
                values: new object[,]
                {
                    { 1, "Fresh Farms Co." },
                    { 2, "Harvest Supply Ltd." },
                    { 3, "Mushroom Masters" },
                    { 4, "Tomato Town Inc." },
                    { 5, "Onion Bros." }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "InvoiceId", "InvoiceDate", "SupplierId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, new DateTime(2024, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, new DateTime(2025, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 5, new DateTime(2025, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Name", "StockQuantity", "UnitPrice", "UnitType" },
                values: new object[,]
                {
                    { 1, 1, "Small sweet tomatoes", "Cherry Tomatoes", 100m, 2.99m, "each" },
                    { 2, 1, "Ideal for sauces", "Roma Tomatoes", 200m, 1.49m, "pound" },
                    { 3, 1, "Large slicing tomato", "Beefsteak Tomatoes", 150m, 1.25m, "each" },
                    { 4, 2, "Mild and versatile", "White Mushrooms", 80m, 3.25m, "pound" },
                    { 5, 2, "Meaty texture, great grilled", "Portobello Mushrooms", 60m, 1.99m, "each" },
                    { 6, 2, "Savory and rich flavor", "Shiitake Mushrooms", 300m, 0.75m, "ounce" },
                    { 7, 3, "Common all-purpose onion", "Yellow Onions", 500m, 0.89m, "pound" },
                    { 8, 3, "Colorful and sharp", "Red Onions", 400m, 1.10m, "pound" },
                    { 9, 3, "Mild and sweet", "Sweet Onions", 350m, 1.30m, "pound" },
                    { 10, 3, "Small and sweet, ideal for roasting", "Cippolini Onions", 250m, 0.60m, "each" }
                });

            migrationBuilder.InsertData(
                table: "InvoiceProducts",
                columns: new[] { "InvoiceId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 25.0m },
                    { 1, 2, 15.0m },
                    { 2, 3, 40.0m },
                    { 2, 4, 20.0m },
                    { 3, 5, 10.0m },
                    { 3, 6, 12.0m },
                    { 4, 2, 18.0m },
                    { 4, 3, 22.0m },
                    { 5, 7, 50.0m },
                    { 5, 8, 30.0m }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ProductId", "RecipeId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 4.0m },
                    { 7, 1, 1.0m },
                    { 4, 2, 6.0m },
                    { 8, 2, 0.5m },
                    { 2, 3, 3.0m },
                    { 5, 3, 2.0m },
                    { 1, 4, 1.0m },
                    { 7, 4, 1.0m },
                    { 8, 4, 1.0m }
                });

            migrationBuilder.InsertData(
                table: "SupplierProducts",
                columns: new[] { "ProductId", "SupplierId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 2 },
                    { 4, 2 },
                    { 5, 3 },
                    { 6, 3 },
                    { 2, 4 },
                    { 3, 4 },
                    { 7, 5 },
                    { 8, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceProducts_ProductId",
                table: "InvoiceProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_SupplierId",
                table: "Invoices",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_ProductId",
                table: "RecipeIngredients",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierProducts_ProductId",
                table: "SupplierProducts",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceProducts");

            migrationBuilder.DropTable(
                name: "RecipeIngredients");

            migrationBuilder.DropTable(
                name: "SupplierProducts");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
