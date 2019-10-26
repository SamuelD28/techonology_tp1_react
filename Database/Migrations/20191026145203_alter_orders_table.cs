using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace technology_tp1.Migrations
{
    public partial class alter_orders_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IsOrdered",
                table: "Orders");

            migrationBuilder.AddColumn<DateTime>(
                name: "Scheduled",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Scheduled",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsOrdered",
                table: "Orders",
                nullable: false,
                defaultValue: false);
        }
    }
}
