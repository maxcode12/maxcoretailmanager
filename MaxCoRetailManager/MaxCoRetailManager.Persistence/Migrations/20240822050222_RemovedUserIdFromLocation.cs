using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaxCoRetailManager.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemovedUserIdFromLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_User_UserId",
                table: "Locations");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Locations",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_User_UserId",
                table: "Locations",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_User_UserId",
                table: "Locations");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Locations",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_User_UserId",
                table: "Locations",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
