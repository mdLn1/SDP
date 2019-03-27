using Microsoft.EntityFrameworkCore.Migrations;

namespace GCTOnlineServices.Migrations
{
    public partial class agencyCheck : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ApprovedMultipleDiscounts",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovedMultipleDiscounts",
                table: "AspNetUsers");
        }
    }
}
