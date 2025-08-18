using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Granary.Migrations
{
    /// <inheritdoc />
    public partial class CementingNewSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UnitType",
                table: "Products");

            migrationBuilder.AddColumn<decimal>(
                name: "UnitPrice",
                table: "InvoiceProducts",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "UnitType",
                table: "InvoiceProducts",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "InvoiceProducts",
                keyColumns: new[] { "InvoiceId", "ProductId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "UnitPrice", "UnitType" },
                values: new object[] { 2.99m, "Each" });

            migrationBuilder.UpdateData(
                table: "InvoiceProducts",
                keyColumns: new[] { "InvoiceId", "ProductId" },
                keyValues: new object[] { 1, 2 },
                columns: new[] { "UnitPrice", "UnitType" },
                values: new object[] { 1.49m, "Pound" });

            migrationBuilder.UpdateData(
                table: "InvoiceProducts",
                keyColumns: new[] { "InvoiceId", "ProductId" },
                keyValues: new object[] { 2, 3 },
                columns: new[] { "UnitPrice", "UnitType" },
                values: new object[] { 1.25m, "Each" });

            migrationBuilder.UpdateData(
                table: "InvoiceProducts",
                keyColumns: new[] { "InvoiceId", "ProductId" },
                keyValues: new object[] { 2, 4 },
                columns: new[] { "UnitPrice", "UnitType" },
                values: new object[] { 3.25m, "Pound" });

            migrationBuilder.UpdateData(
                table: "InvoiceProducts",
                keyColumns: new[] { "InvoiceId", "ProductId" },
                keyValues: new object[] { 3, 5 },
                columns: new[] { "UnitPrice", "UnitType" },
                values: new object[] { 1.99m, "Each" });

            migrationBuilder.UpdateData(
                table: "InvoiceProducts",
                keyColumns: new[] { "InvoiceId", "ProductId" },
                keyValues: new object[] { 3, 6 },
                columns: new[] { "UnitPrice", "UnitType" },
                values: new object[] { 0.75m, "Ounce" });

            migrationBuilder.UpdateData(
                table: "InvoiceProducts",
                keyColumns: new[] { "InvoiceId", "ProductId" },
                keyValues: new object[] { 4, 2 },
                columns: new[] { "UnitPrice", "UnitType" },
                values: new object[] { 1.49m, "Pound" });

            migrationBuilder.UpdateData(
                table: "InvoiceProducts",
                keyColumns: new[] { "InvoiceId", "ProductId" },
                keyValues: new object[] { 4, 3 },
                columns: new[] { "UnitPrice", "UnitType" },
                values: new object[] { 1.25m, "Each" });

            migrationBuilder.UpdateData(
                table: "InvoiceProducts",
                keyColumns: new[] { "InvoiceId", "ProductId" },
                keyValues: new object[] { 5, 7 },
                columns: new[] { "UnitPrice", "UnitType" },
                values: new object[] { 0.89m, "Pound" });

            migrationBuilder.UpdateData(
                table: "InvoiceProducts",
                keyColumns: new[] { "InvoiceId", "ProductId" },
                keyValues: new object[] { 5, 8 },
                columns: new[] { "UnitPrice", "UnitType" },
                values: new object[] { 1.10m, "Pound" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "InvoiceProducts");

            migrationBuilder.DropColumn(
                name: "UnitType",
                table: "InvoiceProducts");

            migrationBuilder.AddColumn<decimal>(
                name: "UnitPrice",
                table: "Products",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "UnitType",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "UnitPrice", "UnitType" },
                values: new object[] { 2.99m, "Each" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "UnitPrice", "UnitType" },
                values: new object[] { 1.49m, "Pound" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "UnitPrice", "UnitType" },
                values: new object[] { 1.25m, "Each" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "UnitPrice", "UnitType" },
                values: new object[] { 3.25m, "Pound" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5,
                columns: new[] { "UnitPrice", "UnitType" },
                values: new object[] { 1.99m, "Each" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6,
                columns: new[] { "UnitPrice", "UnitType" },
                values: new object[] { 0.75m, "Ounce" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7,
                columns: new[] { "UnitPrice", "UnitType" },
                values: new object[] { 0.89m, "Pound" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8,
                columns: new[] { "UnitPrice", "UnitType" },
                values: new object[] { 1.10m, "Pound" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9,
                columns: new[] { "UnitPrice", "UnitType" },
                values: new object[] { 1.30m, "Pound" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 10,
                columns: new[] { "UnitPrice", "UnitType" },
                values: new object[] { 0.60m, "Each" });
        }
    }
}
