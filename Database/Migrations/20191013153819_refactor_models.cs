using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace technology_tp1.Migrations
{
    public partial class refactor_models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "MenuItems",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "MenuItems",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "ItemImages",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "ItemImages",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "DeliveryMen",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "DeliveryMen",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsOrdered = table.Column<bool>(nullable: false),
                    ClientId = table.Column<int>(nullable: false),
                    CustomerName = table.Column<string>(nullable: false),
                    CustomerAdress = table.Column<string>(nullable: false),
                    CustomerPhoneNumber = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    DeliveredAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrdersItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderId = table.Column<int>(nullable: false),
                    MenuItemId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdersItems_MenuItems_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "MenuItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdersItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "DeliveryMen",
                keyColumn: "Id",
                keyValue: -50,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2681), new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2683) });

            migrationBuilder.UpdateData(
                table: "DeliveryMen",
                keyColumn: "Id",
                keyValue: -49,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2664), new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2666) });

            migrationBuilder.UpdateData(
                table: "DeliveryMen",
                keyColumn: "Id",
                keyValue: -48,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2654), new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2656) });

            migrationBuilder.UpdateData(
                table: "DeliveryMen",
                keyColumn: "Id",
                keyValue: -47,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2635), new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2637) });

            migrationBuilder.UpdateData(
                table: "DeliveryMen",
                keyColumn: "Id",
                keyValue: -46,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2627), new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2629) });

            migrationBuilder.UpdateData(
                table: "DeliveryMen",
                keyColumn: "Id",
                keyValue: -45,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2613), new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2615) });

            migrationBuilder.UpdateData(
                table: "DeliveryMen",
                keyColumn: "Id",
                keyValue: -44,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2592), new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2594) });

            migrationBuilder.UpdateData(
                table: "DeliveryMen",
                keyColumn: "Id",
                keyValue: -43,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2574), new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2576) });

            migrationBuilder.UpdateData(
                table: "DeliveryMen",
                keyColumn: "Id",
                keyValue: -42,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2561), new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2563) });

            migrationBuilder.UpdateData(
                table: "DeliveryMen",
                keyColumn: "Id",
                keyValue: -41,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2544), new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2546) });

            migrationBuilder.UpdateData(
                table: "DeliveryMen",
                keyColumn: "Id",
                keyValue: -40,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2534), new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2536) });

            migrationBuilder.UpdateData(
                table: "DeliveryMen",
                keyColumn: "Id",
                keyValue: -39,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2525), new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2527) });

            migrationBuilder.UpdateData(
                table: "DeliveryMen",
                keyColumn: "Id",
                keyValue: -38,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2507), new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2509) });

            migrationBuilder.UpdateData(
                table: "DeliveryMen",
                keyColumn: "Id",
                keyValue: -37,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2492), new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2494) });

            migrationBuilder.UpdateData(
                table: "DeliveryMen",
                keyColumn: "Id",
                keyValue: -36,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2477), new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2479) });

            migrationBuilder.UpdateData(
                table: "DeliveryMen",
                keyColumn: "Id",
                keyValue: -35,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2458), new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2460) });

            migrationBuilder.UpdateData(
                table: "DeliveryMen",
                keyColumn: "Id",
                keyValue: -34,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2446), new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2448) });

            migrationBuilder.UpdateData(
                table: "DeliveryMen",
                keyColumn: "Id",
                keyValue: -33,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2418), new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2420) });

            migrationBuilder.UpdateData(
                table: "DeliveryMen",
                keyColumn: "Id",
                keyValue: -32,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2405), new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2407) });

            migrationBuilder.UpdateData(
                table: "DeliveryMen",
                keyColumn: "Id",
                keyValue: -31,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2388), new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2390) });

            migrationBuilder.UpdateData(
                table: "DeliveryMen",
                keyColumn: "Id",
                keyValue: -30,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2370), new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2372) });

            migrationBuilder.UpdateData(
                table: "DeliveryMen",
                keyColumn: "Id",
                keyValue: -29,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2350), new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2352) });

            migrationBuilder.UpdateData(
                table: "DeliveryMen",
                keyColumn: "Id",
                keyValue: -28,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2338), new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2341) });

            migrationBuilder.UpdateData(
                table: "DeliveryMen",
                keyColumn: "Id",
                keyValue: -27,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2323), new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2325) });

            migrationBuilder.UpdateData(
                table: "DeliveryMen",
                keyColumn: "Id",
                keyValue: -26,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2310), new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2312) });

            migrationBuilder.UpdateData(
                table: "DeliveryMen",
                keyColumn: "Id",
                keyValue: -25,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2299), new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2301) });

            migrationBuilder.UpdateData(
                table: "DeliveryMen",
                keyColumn: "Id",
                keyValue: -24,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2290), new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2292) });

            migrationBuilder.UpdateData(
                table: "DeliveryMen",
                keyColumn: "Id",
                keyValue: -23,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2278), new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2280) });

            migrationBuilder.UpdateData(
                table: "DeliveryMen",
                keyColumn: "Id",
                keyValue: -22,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2264), new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2266) });

            migrationBuilder.UpdateData(
                table: "DeliveryMen",
                keyColumn: "Id",
                keyValue: -21,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2251), new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2253) });

            migrationBuilder.UpdateData(
                table: "DeliveryMen",
                keyColumn: "Id",
                keyValue: -20,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2238), new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2241) });

            migrationBuilder.UpdateData(
                table: "DeliveryMen",
                keyColumn: "Id",
                keyValue: -19,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2224), new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2226) });

            migrationBuilder.UpdateData(
                table: "DeliveryMen",
                keyColumn: "Id",
                keyValue: -18,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2214), new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2216) });

            migrationBuilder.UpdateData(
                table: "DeliveryMen",
                keyColumn: "Id",
                keyValue: -17,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2201), new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2203) });

            migrationBuilder.UpdateData(
                table: "DeliveryMen",
                keyColumn: "Id",
                keyValue: -16,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2187), new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2189) });

            migrationBuilder.UpdateData(
                table: "DeliveryMen",
                keyColumn: "Id",
                keyValue: -15,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2157), new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2159) });

            migrationBuilder.UpdateData(
                table: "DeliveryMen",
                keyColumn: "Id",
                keyValue: -14,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2146), new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2148) });

            migrationBuilder.UpdateData(
                table: "DeliveryMen",
                keyColumn: "Id",
                keyValue: -13,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2129), new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2131) });

            migrationBuilder.UpdateData(
                table: "DeliveryMen",
                keyColumn: "Id",
                keyValue: -12,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2119), new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2121) });

            migrationBuilder.UpdateData(
                table: "DeliveryMen",
                keyColumn: "Id",
                keyValue: -11,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2100), new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2102) });

            migrationBuilder.UpdateData(
                table: "DeliveryMen",
                keyColumn: "Id",
                keyValue: -10,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2085), new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2087) });

            migrationBuilder.UpdateData(
                table: "DeliveryMen",
                keyColumn: "Id",
                keyValue: -9,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2064), new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2066) });

            migrationBuilder.UpdateData(
                table: "DeliveryMen",
                keyColumn: "Id",
                keyValue: -8,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2052), new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2055) });

            migrationBuilder.UpdateData(
                table: "DeliveryMen",
                keyColumn: "Id",
                keyValue: -7,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2035), new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2037) });

            migrationBuilder.UpdateData(
                table: "DeliveryMen",
                keyColumn: "Id",
                keyValue: -6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2023), new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(2025) });

            migrationBuilder.UpdateData(
                table: "DeliveryMen",
                keyColumn: "Id",
                keyValue: -5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(1995), new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(1997) });

            migrationBuilder.UpdateData(
                table: "DeliveryMen",
                keyColumn: "Id",
                keyValue: -4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(1978), new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(1980) });

            migrationBuilder.UpdateData(
                table: "DeliveryMen",
                keyColumn: "Id",
                keyValue: -3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(1952), new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(1955) });

            migrationBuilder.UpdateData(
                table: "DeliveryMen",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(1645), new DateTime(2019, 10, 13, 11, 38, 19, 486, DateTimeKind.Local).AddTicks(1703) });

            migrationBuilder.UpdateData(
                table: "DeliveryMen",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 478, DateTimeKind.Local).AddTicks(9674), new DateTime(2019, 10, 13, 11, 38, 19, 482, DateTimeKind.Local).AddTicks(9822) });

            migrationBuilder.UpdateData(
                table: "ItemImages",
                keyColumn: "Id",
                keyValue: -7,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 491, DateTimeKind.Local).AddTicks(2826), new DateTime(2019, 10, 13, 11, 38, 19, 491, DateTimeKind.Local).AddTicks(2828) });

            migrationBuilder.UpdateData(
                table: "ItemImages",
                keyColumn: "Id",
                keyValue: -6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 491, DateTimeKind.Local).AddTicks(2813), new DateTime(2019, 10, 13, 11, 38, 19, 491, DateTimeKind.Local).AddTicks(2815) });

            migrationBuilder.UpdateData(
                table: "ItemImages",
                keyColumn: "Id",
                keyValue: -5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 491, DateTimeKind.Local).AddTicks(2797), new DateTime(2019, 10, 13, 11, 38, 19, 491, DateTimeKind.Local).AddTicks(2799) });

            migrationBuilder.UpdateData(
                table: "ItemImages",
                keyColumn: "Id",
                keyValue: -4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 491, DateTimeKind.Local).AddTicks(2784), new DateTime(2019, 10, 13, 11, 38, 19, 491, DateTimeKind.Local).AddTicks(2786) });

            migrationBuilder.UpdateData(
                table: "ItemImages",
                keyColumn: "Id",
                keyValue: -3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 491, DateTimeKind.Local).AddTicks(2770), new DateTime(2019, 10, 13, 11, 38, 19, 491, DateTimeKind.Local).AddTicks(2773) });

            migrationBuilder.UpdateData(
                table: "ItemImages",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 491, DateTimeKind.Local).AddTicks(2713), new DateTime(2019, 10, 13, 11, 38, 19, 491, DateTimeKind.Local).AddTicks(2726) });

            migrationBuilder.UpdateData(
                table: "ItemImages",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 490, DateTimeKind.Local).AddTicks(8718), new DateTime(2019, 10, 13, 11, 38, 19, 490, DateTimeKind.Local).AddTicks(9468) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: -7,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 495, DateTimeKind.Local).AddTicks(7592), new DateTime(2019, 10, 13, 11, 38, 19, 495, DateTimeKind.Local).AddTicks(7594) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: -6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 495, DateTimeKind.Local).AddTicks(7578), new DateTime(2019, 10, 13, 11, 38, 19, 495, DateTimeKind.Local).AddTicks(7580) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: -5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 495, DateTimeKind.Local).AddTicks(7565), new DateTime(2019, 10, 13, 11, 38, 19, 495, DateTimeKind.Local).AddTicks(7567) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: -4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 495, DateTimeKind.Local).AddTicks(7554), new DateTime(2019, 10, 13, 11, 38, 19, 495, DateTimeKind.Local).AddTicks(7556) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: -3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 495, DateTimeKind.Local).AddTicks(7494), new DateTime(2019, 10, 13, 11, 38, 19, 495, DateTimeKind.Local).AddTicks(7543) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 495, DateTimeKind.Local).AddTicks(7383), new DateTime(2019, 10, 13, 11, 38, 19, 495, DateTimeKind.Local).AddTicks(7397) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 13, 11, 38, 19, 494, DateTimeKind.Local).AddTicks(6845), new DateTime(2019, 10, 13, 11, 38, 19, 494, DateTimeKind.Local).AddTicks(6901) });

            migrationBuilder.CreateIndex(
                name: "IX_OrdersItems_MenuItemId",
                table: "OrdersItems",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersItems_OrderId_MenuItemId",
                table: "OrdersItems",
                columns: new[] { "OrderId", "MenuItemId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdersItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "ItemImages");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "ItemImages");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "DeliveryMen");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "DeliveryMen");
        }
    }
}
