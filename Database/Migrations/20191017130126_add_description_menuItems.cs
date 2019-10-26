using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace technology_tp1.Migrations
{
    public partial class add_description_menuItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "MenuItems",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: -7,
                columns: new[] { "CreatedOn", "Description" },
                values: new object[] { new DateTime(2019, 10, 17, 8, 56, 56, 790, DateTimeKind.Local).AddTicks(2619), "Cheap, simple and still surprisingly good!" });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: -6,
                columns: new[] { "CreatedOn", "Description" },
                values: new object[] { new DateTime(2019, 10, 17, 8, 56, 56, 790, DateTimeKind.Local).AddTicks(2585), "I guess that pineapple are good" });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: -5,
                columns: new[] { "CreatedOn", "Description" },
                values: new object[] { new DateTime(2019, 10, 17, 8, 56, 56, 790, DateTimeKind.Local).AddTicks(2429), "Classic yet very good" });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: -4,
                columns: new[] { "CreatedOn", "Description" },
                values: new object[] { new DateTime(2019, 10, 17, 8, 56, 56, 790, DateTimeKind.Local).AddTicks(2397), "Always good with those!" });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: -3,
                columns: new[] { "CreatedOn", "Description" },
                values: new object[] { new DateTime(2019, 10, 17, 8, 56, 56, 790, DateTimeKind.Local).AddTicks(2324), "Are you thirsty? Take a coke too feel better" });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "CreatedOn", "Description" },
                values: new object[] { new DateTime(2019, 10, 17, 8, 56, 56, 790, DateTimeKind.Local).AddTicks(2276), "A good and tasty chocolate cake!" });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreatedOn", "Description" },
                values: new object[] { new DateTime(2019, 10, 17, 8, 56, 56, 790, DateTimeKind.Local).AddTicks(2127), "This is an all dress pizza" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "MenuItems");

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
                column: "CreatedOn",
                value: new DateTime(2019, 10, 16, 20, 29, 15, 970, DateTimeKind.Local).AddTicks(5704));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: -3,
                column: "CreatedOn",
                value: new DateTime(2019, 10, 16, 20, 29, 15, 970, DateTimeKind.Local).AddTicks(5617));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: -2,
                column: "CreatedOn",
                value: new DateTime(2019, 10, 16, 20, 29, 15, 970, DateTimeKind.Local).AddTicks(5575));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedOn",
                value: new DateTime(2019, 10, 16, 20, 29, 15, 970, DateTimeKind.Local).AddTicks(5452));
        }
    }
}
