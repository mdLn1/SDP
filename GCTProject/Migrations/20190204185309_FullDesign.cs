using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GCTProject.Migrations
{
    public partial class FullDesign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PerformanceDate",
                table: "PerformanceDate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookedSeats",
                table: "BookedSeats");

            migrationBuilder.DropColumn(
                name: "LiveDate",
                table: "Performance");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Seats",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<byte>(
                name: "Booked",
                table: "BookedSeats",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "BookedSeats",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PerformanceDate",
                table: "PerformanceDate",
                columns: new[] { "Id", "PerformanceId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookedSeats",
                table: "BookedSeats",
                columns: new[] { "Id", "Seatid", "PerformanceId" });

            migrationBuilder.CreateIndex(
                name: "IX_BookedSeats_Seatid",
                table: "BookedSeats",
                column: "Seatid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PerformanceDate",
                table: "PerformanceDate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookedSeats",
                table: "BookedSeats");

            migrationBuilder.DropIndex(
                name: "IX_BookedSeats_Seatid",
                table: "BookedSeats");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "BookedSeats");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Seats",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "LiveDate",
                table: "Performance",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<bool>(
                name: "Booked",
                table: "BookedSeats",
                nullable: true,
                oldClrType: typeof(byte));

            migrationBuilder.AddPrimaryKey(
                name: "PK_PerformanceDate",
                table: "PerformanceDate",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookedSeats",
                table: "BookedSeats",
                columns: new[] { "Seatid", "PerformanceId" });
        }
    }
}
