using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Granary.Migrations
{
    /// <inheritdoc />
    public partial class CorrectedSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "InvoiceProducts",
                keyColumns: new[] { "InvoiceId", "ProductId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "InvoiceProducts",
                keyColumns: new[] { "InvoiceId", "ProductId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "InvoiceProducts",
                keyColumns: new[] { "InvoiceId", "ProductId" },
                keyValues: new object[] { 5, 7 });

            migrationBuilder.DeleteData(
                table: "InvoiceProducts",
                keyColumns: new[] { "InvoiceId", "ProductId" },
                keyValues: new object[] { 5, 8 });

            migrationBuilder.InsertData(
                table: "InvoiceProducts",
                columns: new[] { "InvoiceId", "ProductId", "Quantity", "UnitPrice", "UnitType" },
                values: new object[,]
                {
                    { 4, 7, 18.00m, 1.49m, "Pound" },
                    { 4, 8, 22.00m, 1.25m, "Each" },
                    { 5, 9, 50.00m, 0.89m, "Pound" },
                    { 5, 10, 30.00m, 1.10m, "Pound" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "InvoiceProducts",
                keyColumns: new[] { "InvoiceId", "ProductId" },
                keyValues: new object[] { 4, 7 });

            migrationBuilder.DeleteData(
                table: "InvoiceProducts",
                keyColumns: new[] { "InvoiceId", "ProductId" },
                keyValues: new object[] { 4, 8 });

            migrationBuilder.DeleteData(
                table: "InvoiceProducts",
                keyColumns: new[] { "InvoiceId", "ProductId" },
                keyValues: new object[] { 5, 9 });

            migrationBuilder.DeleteData(
                table: "InvoiceProducts",
                keyColumns: new[] { "InvoiceId", "ProductId" },
                keyValues: new object[] { 5, 10 });

            migrationBuilder.InsertData(
                table: "InvoiceProducts",
                columns: new[] { "InvoiceId", "ProductId", "Quantity", "UnitPrice", "UnitType" },
                values: new object[,]
                {
                    { 4, 2, 18.00m, 1.49m, "Pound" },
                    { 4, 3, 22.00m, 1.25m, "Each" },
                    { 5, 7, 50.00m, 0.89m, "Pound" },
                    { 5, 8, 30.00m, 1.10m, "Pound" }
                });
        }
    }
}
