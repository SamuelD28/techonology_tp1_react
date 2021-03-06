﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using technology_tp1.Models;

namespace technology_tp1.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20191022030628_removed_itemimage")]
    partial class removed_itemimage
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Technology_Tp1_React.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("CustomerAdress")
                        .IsRequired();

                    b.Property<string>("CustomerName")
                        .IsRequired();

                    b.Property<string>("CustomerPhoneNumber")
                        .IsRequired();

                    b.Property<DateTime?>("DeliveredAt");

                    b.Property<bool>("IsOrdered");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Technology_Tp1_React.Models.OrdersItems", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<int>("MenuItemId");

                    b.Property<int>("OrderId");

                    b.Property<int>("Quantity");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("Id");

                    b.HasIndex("MenuItemId");

                    b.HasIndex("OrderId", "MenuItemId")
                        .IsUnique();

                    b.ToTable("OrdersItems");
                });

            modelBuilder.Entity("technology_tp1.Models.DeliveryMan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<bool>("IsDeactivated");

                    b.Property<bool>("IsEmployed");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Phone")
                        .IsRequired();

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("Id");

                    b.ToTable("DeliveryMen");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            CreatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 730, DateTimeKind.Local).AddTicks(1087),
                            IsDeactivated = false,
                            IsEmployed = true,
                            Name = "Charles White",
                            Phone = "618-300-30280",
                            UpdatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 732, DateTimeKind.Local).AddTicks(3880)
                        },
                        new
                        {
                            Id = -2,
                            CreatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1495),
                            IsDeactivated = false,
                            IsEmployed = false,
                            Name = "Charlotte Anderson",
                            Phone = "116-649-22017",
                            UpdatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1510)
                        },
                        new
                        {
                            Id = -3,
                            CreatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1614),
                            IsDeactivated = false,
                            IsEmployed = true,
                            Name = "Jason Baker",
                            Phone = "193-539-03413",
                            UpdatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1617)
                        },
                        new
                        {
                            Id = -4,
                            CreatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1626),
                            IsDeactivated = false,
                            IsEmployed = true,
                            Name = "Victoria Moore",
                            Phone = "832-521-53793",
                            UpdatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1629)
                        },
                        new
                        {
                            Id = -5,
                            CreatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1636),
                            IsDeactivated = false,
                            IsEmployed = true,
                            Name = "Donna Garcia",
                            Phone = "725-171-69810",
                            UpdatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1638)
                        },
                        new
                        {
                            Id = -6,
                            CreatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1647),
                            IsDeactivated = false,
                            IsEmployed = true,
                            Name = "Kenneth Baker",
                            Phone = "352-324-95195",
                            UpdatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1650)
                        },
                        new
                        {
                            Id = -7,
                            CreatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1657),
                            IsDeactivated = false,
                            IsEmployed = false,
                            Name = "Linda Wilson",
                            Phone = "920-131-04252",
                            UpdatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1659)
                        },
                        new
                        {
                            Id = -8,
                            CreatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1665),
                            IsDeactivated = false,
                            IsEmployed = true,
                            Name = "Jason Davidson",
                            Phone = "238-668-64088",
                            UpdatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1667)
                        },
                        new
                        {
                            Id = -9,
                            CreatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1674),
                            IsDeactivated = false,
                            IsEmployed = false,
                            Name = "David Clarkson",
                            Phone = "504-818-80293",
                            UpdatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1676)
                        },
                        new
                        {
                            Id = -10,
                            CreatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1683),
                            IsDeactivated = false,
                            IsEmployed = true,
                            Name = "Simon Anderson",
                            Phone = "150-972-79913",
                            UpdatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1685)
                        },
                        new
                        {
                            Id = -11,
                            CreatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1692),
                            IsDeactivated = false,
                            IsEmployed = false,
                            Name = "Eve Lake",
                            Phone = "463-091-96333",
                            UpdatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1694)
                        },
                        new
                        {
                            Id = -12,
                            CreatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1699),
                            IsDeactivated = false,
                            IsEmployed = false,
                            Name = "Michelle Davies",
                            Phone = "765-062-63497",
                            UpdatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1701)
                        },
                        new
                        {
                            Id = -13,
                            CreatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1708),
                            IsDeactivated = false,
                            IsEmployed = true,
                            Name = "Matthew Stevens",
                            Phone = "186-747-79982",
                            UpdatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1710)
                        },
                        new
                        {
                            Id = -14,
                            CreatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1715),
                            IsDeactivated = false,
                            IsEmployed = false,
                            Name = "Maria Harrison",
                            Phone = "822-747-19628",
                            UpdatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1717)
                        },
                        new
                        {
                            Id = -15,
                            CreatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1725),
                            IsDeactivated = false,
                            IsEmployed = true,
                            Name = "Anne Davidson",
                            Phone = "049-525-68249",
                            UpdatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1727)
                        },
                        new
                        {
                            Id = -16,
                            CreatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1732),
                            IsDeactivated = false,
                            IsEmployed = true,
                            Name = "Carol Jones",
                            Phone = "286-005-86109",
                            UpdatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1734)
                        },
                        new
                        {
                            Id = -17,
                            CreatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1741),
                            IsDeactivated = false,
                            IsEmployed = false,
                            Name = "Jason Oates",
                            Phone = "399-777-01482",
                            UpdatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1743)
                        },
                        new
                        {
                            Id = -18,
                            CreatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1750),
                            IsDeactivated = false,
                            IsEmployed = true,
                            Name = "Edgar Lewis",
                            Phone = "048-199-67962",
                            UpdatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1752)
                        },
                        new
                        {
                            Id = -19,
                            CreatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1759),
                            IsDeactivated = false,
                            IsEmployed = true,
                            Name = "Jennifer Dent",
                            Phone = "653-509-79472",
                            UpdatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1761)
                        },
                        new
                        {
                            Id = -20,
                            CreatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1766),
                            IsDeactivated = false,
                            IsEmployed = false,
                            Name = "Edgar Thatcher",
                            Phone = "174-604-08577",
                            UpdatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1768)
                        },
                        new
                        {
                            Id = -21,
                            CreatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1775),
                            IsDeactivated = false,
                            IsEmployed = true,
                            Name = "Anne Jones",
                            Phone = "927-116-05153",
                            UpdatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1777)
                        },
                        new
                        {
                            Id = -22,
                            CreatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1782),
                            IsDeactivated = false,
                            IsEmployed = true,
                            Name = "John Peterson",
                            Phone = "235-155-31476",
                            UpdatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1785)
                        },
                        new
                        {
                            Id = -23,
                            CreatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1793),
                            IsDeactivated = false,
                            IsEmployed = false,
                            Name = "Sandra Harris",
                            Phone = "878-970-90010",
                            UpdatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1795)
                        },
                        new
                        {
                            Id = -24,
                            CreatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1800),
                            IsDeactivated = false,
                            IsEmployed = false,
                            Name = "Brian Moore",
                            Phone = "963-843-58596",
                            UpdatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1802)
                        },
                        new
                        {
                            Id = -25,
                            CreatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1812),
                            IsDeactivated = false,
                            IsEmployed = false,
                            Name = "Hugh Martin",
                            Phone = "926-865-64762",
                            UpdatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1814)
                        },
                        new
                        {
                            Id = -26,
                            CreatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1820),
                            IsDeactivated = false,
                            IsEmployed = true,
                            Name = "Terry Kirk",
                            Phone = "200-879-39392",
                            UpdatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1822)
                        },
                        new
                        {
                            Id = -27,
                            CreatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1829),
                            IsDeactivated = false,
                            IsEmployed = false,
                            Name = "Anthony Brown",
                            Phone = "876-527-54403",
                            UpdatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1831)
                        },
                        new
                        {
                            Id = -28,
                            CreatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1836),
                            IsDeactivated = false,
                            IsEmployed = false,
                            Name = "Beryl Davis",
                            Phone = "018-065-14665",
                            UpdatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1838)
                        },
                        new
                        {
                            Id = -29,
                            CreatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1845),
                            IsDeactivated = false,
                            IsEmployed = true,
                            Name = "Ronald Jeffries",
                            Phone = "523-685-69677",
                            UpdatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1847)
                        },
                        new
                        {
                            Id = -30,
                            CreatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1853),
                            IsDeactivated = false,
                            IsEmployed = false,
                            Name = "Nancy Jefferson",
                            Phone = "678-181-12356",
                            UpdatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1855)
                        },
                        new
                        {
                            Id = -31,
                            CreatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1861),
                            IsDeactivated = false,
                            IsEmployed = false,
                            Name = "Steven Robertson",
                            Phone = "425-040-89374",
                            UpdatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1863)
                        },
                        new
                        {
                            Id = -32,
                            CreatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1869),
                            IsDeactivated = false,
                            IsEmployed = false,
                            Name = "George White",
                            Phone = "957-297-41924",
                            UpdatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1871)
                        },
                        new
                        {
                            Id = -33,
                            CreatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1877),
                            IsDeactivated = false,
                            IsEmployed = true,
                            Name = "Charles Clark",
                            Phone = "360-934-95238",
                            UpdatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1879)
                        },
                        new
                        {
                            Id = -34,
                            CreatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1889),
                            IsDeactivated = false,
                            IsEmployed = false,
                            Name = "Helena Kirby",
                            Phone = "099-451-48999",
                            UpdatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1891)
                        },
                        new
                        {
                            Id = -35,
                            CreatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1898),
                            IsDeactivated = false,
                            IsEmployed = true,
                            Name = "Robyn Yorke",
                            Phone = "088-137-12049",
                            UpdatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1900)
                        },
                        new
                        {
                            Id = -36,
                            CreatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1947),
                            IsDeactivated = false,
                            IsEmployed = true,
                            Name = "Ronald Brown",
                            Phone = "997-425-15598",
                            UpdatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1949)
                        },
                        new
                        {
                            Id = -37,
                            CreatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1958),
                            IsDeactivated = false,
                            IsEmployed = true,
                            Name = "Adam Harrison",
                            Phone = "337-229-93068",
                            UpdatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1960)
                        },
                        new
                        {
                            Id = -38,
                            CreatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1968),
                            IsDeactivated = false,
                            IsEmployed = false,
                            Name = "Ursula Major",
                            Phone = "299-800-31549",
                            UpdatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1970)
                        },
                        new
                        {
                            Id = -39,
                            CreatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1977),
                            IsDeactivated = false,
                            IsEmployed = true,
                            Name = "David Lewis",
                            Phone = "902-615-12519",
                            UpdatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1979)
                        },
                        new
                        {
                            Id = -40,
                            CreatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1985),
                            IsDeactivated = false,
                            IsEmployed = false,
                            Name = "Robyn Hall",
                            Phone = "826-978-82939",
                            UpdatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1987)
                        },
                        new
                        {
                            Id = -41,
                            CreatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1995),
                            IsDeactivated = false,
                            IsEmployed = true,
                            Name = "Roger Harrison",
                            Phone = "761-478-42890",
                            UpdatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(1997)
                        },
                        new
                        {
                            Id = -42,
                            CreatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(2002),
                            IsDeactivated = false,
                            IsEmployed = true,
                            Name = "Philip Baker",
                            Phone = "363-257-63461",
                            UpdatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(2004)
                        },
                        new
                        {
                            Id = -43,
                            CreatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(2013),
                            IsDeactivated = false,
                            IsEmployed = true,
                            Name = "Edwin Clarke",
                            Phone = "393-242-42053",
                            UpdatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(2015)
                        },
                        new
                        {
                            Id = -44,
                            CreatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(2020),
                            IsDeactivated = false,
                            IsEmployed = false,
                            Name = "Ursula Robertson",
                            Phone = "145-893-99260",
                            UpdatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(2022)
                        },
                        new
                        {
                            Id = -45,
                            CreatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(2029),
                            IsDeactivated = false,
                            IsEmployed = false,
                            Name = "Ruth Martinez",
                            Phone = "029-660-32389",
                            UpdatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(2031)
                        },
                        new
                        {
                            Id = -46,
                            CreatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(2037),
                            IsDeactivated = false,
                            IsEmployed = false,
                            Name = "Richard Clarkson",
                            Phone = "784-656-33374",
                            UpdatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(2039)
                        },
                        new
                        {
                            Id = -47,
                            CreatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(2046),
                            IsDeactivated = false,
                            IsEmployed = false,
                            Name = "Kevin Harrison",
                            Phone = "973-441-01267",
                            UpdatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(2048)
                        },
                        new
                        {
                            Id = -48,
                            CreatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(2054),
                            IsDeactivated = false,
                            IsEmployed = true,
                            Name = "Anthony Anderson",
                            Phone = "961-081-90287",
                            UpdatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(2056)
                        },
                        new
                        {
                            Id = -49,
                            CreatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(2062),
                            IsDeactivated = false,
                            IsEmployed = true,
                            Name = "Sarah Davies",
                            Phone = "026-991-07296",
                            UpdatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(2064)
                        },
                        new
                        {
                            Id = -50,
                            CreatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(2069),
                            IsDeactivated = false,
                            IsEmployed = true,
                            Name = "Arthur Thatcher",
                            Phone = "413-387-80720",
                            UpdatedOn = new DateTime(2019, 10, 21, 23, 6, 28, 734, DateTimeKind.Local).AddTicks(2071)
                        });
                });

            modelBuilder.Entity("technology_tp1.Models.MenuItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("ImageUrl")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<decimal>("Price");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("Id");

                    b.ToTable("MenuItems");
                });

            modelBuilder.Entity("Technology_Tp1_React.Models.OrdersItems", b =>
                {
                    b.HasOne("technology_tp1.Models.MenuItem", "MenuItem")
                        .WithMany()
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Technology_Tp1_React.Models.Order", "Order")
                        .WithMany("OrdersItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
