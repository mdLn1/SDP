using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GCTOnlineServices.Migrations
{
    public partial class PlayAndPerformance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketTickets_PerformanceDates_PerformanceDateId",
                table: "BasketTickets");

            migrationBuilder.DropForeignKey(
                name: "FK_BookedSeats_PerformanceDates_PerformanceDateId",
                table: "BookedSeats");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Performances_PerformanceId",
                table: "Reviews");

            migrationBuilder.DropTable(
                name: "PerformanceDates");

            migrationBuilder.DropColumn(
                name: "AgeRestriction",
                table: "Performances");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Performances");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Performances");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Performances");

            migrationBuilder.DropColumn(
                name: "PriceEnd",
                table: "Performances");

            migrationBuilder.DropColumn(
                name: "PriceStart",
                table: "Performances");

            migrationBuilder.RenameColumn(
                name: "PerformanceName",
                table: "SoldTickets",
                newName: "PlayName");

            migrationBuilder.RenameColumn(
                name: "PerformanceId",
                table: "Reviews",
                newName: "PlayId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_PerformanceId",
                table: "Reviews",
                newName: "IX_Reviews_PlayId");

            migrationBuilder.RenameColumn(
                name: "PerformanceName",
                table: "Orders",
                newName: "PlayName");

            migrationBuilder.RenameColumn(
                name: "PerformanceDateId",
                table: "BookedSeats",
                newName: "PerformanceId");

            migrationBuilder.RenameIndex(
                name: "IX_BookedSeats_PerformanceDateId",
                table: "BookedSeats",
                newName: "IX_BookedSeats_PerformanceId");

            migrationBuilder.RenameColumn(
                name: "PerformanceDateId",
                table: "BasketTickets",
                newName: "PerformanceId");

            migrationBuilder.RenameIndex(
                name: "IX_BasketTickets_PerformanceDateId",
                table: "BasketTickets",
                newName: "IX_BasketTickets_PerformanceId");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Performances",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PlayId",
                table: "Performances",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Plays",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PriceStart = table.Column<decimal>(nullable: false),
                    PriceEnd = table.Column<decimal>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    AgeRestriction = table.Column<string>(nullable: true),
                    Picture = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plays", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Performances_PlayId",
                table: "Performances",
                column: "PlayId");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketTickets_Performances_PerformanceId",
                table: "BasketTickets",
                column: "PerformanceId",
                principalTable: "Performances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookedSeats_Performances_PerformanceId",
                table: "BookedSeats",
                column: "PerformanceId",
                principalTable: "Performances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Performances_Plays_PlayId",
                table: "Performances",
                column: "PlayId",
                principalTable: "Plays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Plays_PlayId",
                table: "Reviews",
                column: "PlayId",
                principalTable: "Plays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketTickets_Performances_PerformanceId",
                table: "BasketTickets");

            migrationBuilder.DropForeignKey(
                name: "FK_BookedSeats_Performances_PerformanceId",
                table: "BookedSeats");

            migrationBuilder.DropForeignKey(
                name: "FK_Performances_Plays_PlayId",
                table: "Performances");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Plays_PlayId",
                table: "Reviews");

            migrationBuilder.DropTable(
                name: "Plays");

            migrationBuilder.DropIndex(
                name: "IX_Performances_PlayId",
                table: "Performances");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Performances");

            migrationBuilder.DropColumn(
                name: "PlayId",
                table: "Performances");

            migrationBuilder.RenameColumn(
                name: "PlayName",
                table: "SoldTickets",
                newName: "PerformanceName");

            migrationBuilder.RenameColumn(
                name: "PlayId",
                table: "Reviews",
                newName: "PerformanceId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_PlayId",
                table: "Reviews",
                newName: "IX_Reviews_PerformanceId");

            migrationBuilder.RenameColumn(
                name: "PlayName",
                table: "Orders",
                newName: "PerformanceName");

            migrationBuilder.RenameColumn(
                name: "PerformanceId",
                table: "BookedSeats",
                newName: "PerformanceDateId");

            migrationBuilder.RenameIndex(
                name: "IX_BookedSeats_PerformanceId",
                table: "BookedSeats",
                newName: "IX_BookedSeats_PerformanceDateId");

            migrationBuilder.RenameColumn(
                name: "PerformanceId",
                table: "BasketTickets",
                newName: "PerformanceDateId");

            migrationBuilder.RenameIndex(
                name: "IX_BasketTickets_PerformanceId",
                table: "BasketTickets",
                newName: "IX_BasketTickets_PerformanceDateId");

            migrationBuilder.AddColumn<string>(
                name: "AgeRestriction",
                table: "Performances",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Performances",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Performances",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Picture",
                table: "Performances",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceEnd",
                table: "Performances",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceStart",
                table: "Performances",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "PerformanceDates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    PerformanceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerformanceDates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PerformanceDates_Performances_PerformanceId",
                        column: x => x.PerformanceId,
                        principalTable: "Performances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PerformanceDates_PerformanceId",
                table: "PerformanceDates",
                column: "PerformanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketTickets_PerformanceDates_PerformanceDateId",
                table: "BasketTickets",
                column: "PerformanceDateId",
                principalTable: "PerformanceDates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookedSeats_PerformanceDates_PerformanceDateId",
                table: "BookedSeats",
                column: "PerformanceDateId",
                principalTable: "PerformanceDates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Performances_PerformanceId",
                table: "Reviews",
                column: "PerformanceId",
                principalTable: "Performances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
