using Microsoft.EntityFrameworkCore.Migrations;

namespace GCTOnlineServices.Migrations
{
    public partial class EditedDesign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlayName",
                table: "Orders");

            migrationBuilder.AddColumn<bool>(
                name: "IsPrinted",
                table: "Orders",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPrinted",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "PlayName",
                table: "Orders",
                nullable: true);
        }
    }
}
