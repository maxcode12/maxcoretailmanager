using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MaxCoRetailManager.Identity.Migrations
{
    /// <inheritdoc />
    public partial class RoleSeedMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8b693986-0d12-487f-9fde-e0e983e2f51c", null, "User", "USER" },
                    { "c619043f-2923-4180-95fc-1104ed3ddc3e", null, "Admin", "ADMIN" },
                    { "c619453f-2973-4180-78fc-1b84ed3dkc3o", null, "Manager", "MANAGER" },
                    { "d6s9043f-3924-4589-05fq-1i94ed3ddc3f", null, "Cashier", "CASHIER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8b693986-0d12-487f-9fde-e0e983e2f51c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c619043f-2923-4180-95fc-1104ed3ddc3e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c619453f-2973-4180-78fc-1b84ed3dkc3o");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d6s9043f-3924-4589-05fq-1i94ed3ddc3f");
        }
    }
}
