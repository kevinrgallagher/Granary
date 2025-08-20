using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable


namespace Granary.Migrations
{
    /// <inheritdoc />
    public partial class AddedUnitTypeModel : Migration
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
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    RecipeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactPhone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierId);
                });

            migrationBuilder.CreateTable(
                name: "UnitTypes",
                columns: table => new
                {
                    UnitTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Abbreviation = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitTypes", x => x.UnitTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_Invoices_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    UnitTypeId = table.Column<int>(type: "int", nullable: false),
                    StockQuantity = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_UnitTypes_UnitTypeId",
                        column: x => x.UnitTypeId,
                        principalTable: "UnitTypes",
                        principalColumn: "UnitTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceProducts",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
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
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[,]
                {
                    { 1, "Tomatoes", "Includes all tomato varieties like Roma, Cherry, and Beefsteak." },
                    { 2, "Mushrooms", "Covers common edible mushrooms such as White, Portobello, and Shiitake." },
                    { 3, "Onions", "Includes Yellow, Red, Sweet, and specialty onions like Cippolini." }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "RecipeId", "Description", "RecipeName" },
                values: new object[,]
                {
                    { 1, "A warm and savory soup made from fresh tomatoes and onions.", "Tomato Soup" },
                    { 2, "Mushroom caps filled with a savory onion and herb blend.", "Stuffed Mushrooms" },
                    { 3, "A classic Italian-style tomato and mushroom sauce.", "Marinara Sauce" },
                    { 4, "A fresh salad combining red and yellow onions with cherry tomatoes.", "Onion Salad" }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "SupplierId", "ContactEmail", "ContactName", "ContactPhone", "SupplierName" },
                values: new object[,]
                {
                    { 1, "lena@freshfarms.com", "Lena Ortiz", "555-101-0001", "Fresh Farms Co." },
                    { 2, "marcus@harvestsupply.com", "Marcus Liu", "555-101-0002", "Harvest Supply Ltd." },
                    { 3, "jill@mushroommasters.com", "Jill Tanaka", "555-101-0003", "Mushroom Masters" },
                    { 4, "rick@tomatotown.com", "Rick Valenti", "555-101-0004", "Tomato Town Inc." },
                    { 5, "nina@onionbros.com", "Nina Patel", "555-101-0005", "Onion Bros." }
                });

            migrationBuilder.InsertData(
                table: "UnitTypes",
                columns: new[] { "UnitTypeId", "Abbreviation", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, "oz", true, "Ounce" },
                    { 2, "lb", true, "Pound" },
                    { 3, "gal", true, "Gallon" },
                    { 4, "ea", true, "Each" }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "InvoiceId", "DueDate", "InvoiceDate", "InvoiceNumber", "Status", "SupplierId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "INV-1001", "Pending", 1 },
                    { 2, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "INV-1002", "Paid", 2 },
                    { 3, new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "INV-1003", "Pending", 3 },
                    { 4, new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "INV-1004", "Overdue", 4 },
                    { 5, new DateTime(2025, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "INV-1005", "Paid", 5 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "ProductName", "StockQuantity", "SupplierId", "UnitTypeId" },
                values: new object[,]
                {
                    { 1, 1, "Small sweet tomatoes", "Cherry Tomatoes", 100.00m, 4, 1 },
                    { 2, 1, "Ideal for sauces", "Roma Tomatoes", 200.00m, 4, 2 },
                    { 3, 1, "Large slicing tomato", "Beefsteak Tomatoes", 150.00m, 4, 3 },
                    { 4, 2, "Mild and versatile", "White Mushrooms", 80.00m, 3, 4 },
                    { 5, 2, "Meaty texture, great grilled", "Portobello Mushrooms", 60.00m, 3, 2 },
                    { 6, 2, "Savory and rich flavor", "Shiitake Mushrooms", 300.00m, 3, 1 },
                    { 7, 3, "Common all-purpose onion", "Yellow Onions", 500.00m, 5, 3 },
                    { 8, 3, "Colorful and sharp", "Red Onions", 400.00m, 5, 2 },
                    { 9, 3, "Mild and sweet", "Sweet Onions", 350.00m, 5, 3 },
                    { 10, 3, "Mild and sweet", "Sweet Onions", 50.00m, 5, 4 }
                });

            migrationBuilder.InsertData(
                table: "InvoiceProducts",
                columns: new[] { "InvoiceId", "ProductId", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 1, 25.00m, 2.99m },
                    { 1, 2, 15.00m, 1.49m },
                    { 2, 3, 40.00m, 1.25m },
                    { 2, 4, 20.00m, 3.25m },
                    { 3, 5, 10.00m, 1.99m },
                    { 3, 6, 12.00m, 0.75m },
                    { 4, 7, 18.00m, 1.49m },
                    { 4, 8, 22.00m, 1.25m },
                    { 5, 9, 50.00m, 0.89m },
                    { 5, 10, 30.00m, 1.10m }
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
                name: "IX_Products_SupplierId",
                table: "Products",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UnitTypeId",
                table: "Products",
                column: "UnitTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_ProductId",
                table: "RecipeIngredients",
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
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "UnitTypes");
        }
    }
}
