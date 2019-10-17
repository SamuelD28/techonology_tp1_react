using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace technology_tp1.Migrations
{
    public partial class add_category_menuItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "MenuItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: -7,
                column: "CreatedOn",
                value: new DateTime(2019, 10, 16, 20, 29, 15, 970, DateTimeKind.Local).AddTicks(5788));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: -6,
                column: "CreatedOn",
                value: new DateTime(2019, 10, 16, 20, 29, 15, 970, DateTimeKind.Local).AddTicks(5758));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: -5,
                column: "CreatedOn",
                value: new DateTime(2019, 10, 16, 20, 29, 15, 970, DateTimeKind.Local).AddTicks(5732));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: -4,
                columns: new[] { "Category", "CreatedOn" },
                values: new object[] { 3, new DateTime(2019, 10, 16, 20, 29, 15, 970, DateTimeKind.Local).AddTicks(5704) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: -3,
                columns: new[] { "Category", "CreatedOn" },
                values: new object[] { 1, new DateTime(2019, 10, 16, 20, 29, 15, 970, DateTimeKind.Local).AddTicks(5617) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "Category", "CreatedOn" },
                values: new object[] { 2, new DateTime(2019, 10, 16, 20, 29, 15, 970, DateTimeKind.Local).AddTicks(5575) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedOn",
                value: new DateTime(2019, 10, 16, 20, 29, 15, 970, DateTimeKind.Local).AddTicks(5452));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "MenuItems");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: -7,
                column: "CreatedOn",
                value: new DateTime(2019, 10, 16, 20, 20, 36, 725, DateTimeKind.Local).AddTicks(5587));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: -6,
                column: "CreatedOn",
                value: new DateTime(2019, 10, 16, 20, 20, 36, 725, DateTimeKind.Local).AddTicks(5537));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: -5,
                column: "CreatedOn",
                value: new DateTime(2019, 10, 16, 20, 20, 36, 725, DateTimeKind.Local).AddTicks(5514));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: -4,
                column: "CreatedOn",
                value: new DateTime(2019, 10, 16, 20, 20, 36, 725, DateTimeKind.Local).AddTicks(5491));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: -3,
                column: "CreatedOn",
                value: new DateTime(2019, 10, 16, 20, 20, 36, 725, DateTimeKind.Local).AddTicks(5466));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: -2,
                column: "CreatedOn",
                value: new DateTime(2019, 10, 16, 20, 20, 36, 725, DateTimeKind.Local).AddTicks(5368));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedOn",
                value: new DateTime(2019, 10, 16, 20, 20, 36, 725, DateTimeKind.Local).AddTicks(5268));
        }
    }
}
