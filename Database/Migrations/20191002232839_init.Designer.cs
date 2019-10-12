﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using technology_tp1.Models;

namespace technology_tp1.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20191002232839_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("technology_tp1.Models.DeliveryMan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDeactivated");

                    b.Property<bool>("IsEmployed");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.HasKey("Id");

                    b.ToTable("DeliveryMen");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            IsDeactivated = false,
                            IsEmployed = true,
                            Name = "Charles White",
                            Phone = "618-300-30280"
                        },
                        new
                        {
                            Id = -2,
                            IsDeactivated = false,
                            IsEmployed = false,
                            Name = "Charlotte Anderson",
                            Phone = "116-649-22017"
                        },
                        new
                        {
                            Id = -3,
                            IsDeactivated = false,
                            IsEmployed = true,
                            Name = "Jason Baker",
                            Phone = "193-539-03413"
                        },
                        new
                        {
                            Id = -4,
                            IsDeactivated = false,
                            IsEmployed = true,
                            Name = "Victoria Moore",
                            Phone = "832-521-53793"
                        },
                        new
                        {
                            Id = -5,
                            IsDeactivated = false,
                            IsEmployed = true,
                            Name = "Donna Garcia",
                            Phone = "725-171-69810"
                        },
                        new
                        {
                            Id = -6,
                            IsDeactivated = false,
                            IsEmployed = true,
                            Name = "Kenneth Baker",
                            Phone = "352-324-95195"
                        },
                        new
                        {
                            Id = -7,
                            IsDeactivated = false,
                            IsEmployed = false,
                            Name = "Linda Wilson",
                            Phone = "920-131-04252"
                        },
                        new
                        {
                            Id = -8,
                            IsDeactivated = false,
                            IsEmployed = true,
                            Name = "Jason Davidson",
                            Phone = "238-668-64088"
                        },
                        new
                        {
                            Id = -9,
                            IsDeactivated = false,
                            IsEmployed = false,
                            Name = "David Clarkson",
                            Phone = "504-818-80293"
                        },
                        new
                        {
                            Id = -10,
                            IsDeactivated = false,
                            IsEmployed = true,
                            Name = "Simon Anderson",
                            Phone = "150-972-79913"
                        },
                        new
                        {
                            Id = -11,
                            IsDeactivated = false,
                            IsEmployed = false,
                            Name = "Eve Lake",
                            Phone = "463-091-96333"
                        },
                        new
                        {
                            Id = -12,
                            IsDeactivated = false,
                            IsEmployed = false,
                            Name = "Michelle Davies",
                            Phone = "765-062-63497"
                        },
                        new
                        {
                            Id = -13,
                            IsDeactivated = false,
                            IsEmployed = true,
                            Name = "Matthew Stevens",
                            Phone = "186-747-79982"
                        },
                        new
                        {
                            Id = -14,
                            IsDeactivated = false,
                            IsEmployed = false,
                            Name = "Maria Harrison",
                            Phone = "822-747-19628"
                        },
                        new
                        {
                            Id = -15,
                            IsDeactivated = false,
                            IsEmployed = true,
                            Name = "Anne Davidson",
                            Phone = "049-525-68249"
                        },
                        new
                        {
                            Id = -16,
                            IsDeactivated = false,
                            IsEmployed = true,
                            Name = "Carol Jones",
                            Phone = "286-005-86109"
                        },
                        new
                        {
                            Id = -17,
                            IsDeactivated = false,
                            IsEmployed = false,
                            Name = "Jason Oates",
                            Phone = "399-777-01482"
                        },
                        new
                        {
                            Id = -18,
                            IsDeactivated = false,
                            IsEmployed = true,
                            Name = "Edgar Lewis",
                            Phone = "048-199-67962"
                        },
                        new
                        {
                            Id = -19,
                            IsDeactivated = false,
                            IsEmployed = true,
                            Name = "Jennifer Dent",
                            Phone = "653-509-79472"
                        },
                        new
                        {
                            Id = -20,
                            IsDeactivated = false,
                            IsEmployed = false,
                            Name = "Edgar Thatcher",
                            Phone = "174-604-08577"
                        },
                        new
                        {
                            Id = -21,
                            IsDeactivated = false,
                            IsEmployed = true,
                            Name = "Anne Jones",
                            Phone = "927-116-05153"
                        },
                        new
                        {
                            Id = -22,
                            IsDeactivated = false,
                            IsEmployed = true,
                            Name = "John Peterson",
                            Phone = "235-155-31476"
                        },
                        new
                        {
                            Id = -23,
                            IsDeactivated = false,
                            IsEmployed = false,
                            Name = "Sandra Harris",
                            Phone = "878-970-90010"
                        },
                        new
                        {
                            Id = -24,
                            IsDeactivated = false,
                            IsEmployed = false,
                            Name = "Brian Moore",
                            Phone = "963-843-58596"
                        },
                        new
                        {
                            Id = -25,
                            IsDeactivated = false,
                            IsEmployed = false,
                            Name = "Hugh Martin",
                            Phone = "926-865-64762"
                        },
                        new
                        {
                            Id = -26,
                            IsDeactivated = false,
                            IsEmployed = true,
                            Name = "Terry Kirk",
                            Phone = "200-879-39392"
                        },
                        new
                        {
                            Id = -27,
                            IsDeactivated = false,
                            IsEmployed = false,
                            Name = "Anthony Brown",
                            Phone = "876-527-54403"
                        },
                        new
                        {
                            Id = -28,
                            IsDeactivated = false,
                            IsEmployed = false,
                            Name = "Beryl Davis",
                            Phone = "018-065-14665"
                        },
                        new
                        {
                            Id = -29,
                            IsDeactivated = false,
                            IsEmployed = true,
                            Name = "Ronald Jeffries",
                            Phone = "523-685-69677"
                        },
                        new
                        {
                            Id = -30,
                            IsDeactivated = false,
                            IsEmployed = false,
                            Name = "Nancy Jefferson",
                            Phone = "678-181-12356"
                        },
                        new
                        {
                            Id = -31,
                            IsDeactivated = false,
                            IsEmployed = false,
                            Name = "Steven Robertson",
                            Phone = "425-040-89374"
                        },
                        new
                        {
                            Id = -32,
                            IsDeactivated = false,
                            IsEmployed = false,
                            Name = "George White",
                            Phone = "957-297-41924"
                        },
                        new
                        {
                            Id = -33,
                            IsDeactivated = false,
                            IsEmployed = true,
                            Name = "Charles Clark",
                            Phone = "360-934-95238"
                        },
                        new
                        {
                            Id = -34,
                            IsDeactivated = false,
                            IsEmployed = false,
                            Name = "Helena Kirby",
                            Phone = "099-451-48999"
                        },
                        new
                        {
                            Id = -35,
                            IsDeactivated = false,
                            IsEmployed = true,
                            Name = "Robyn Yorke",
                            Phone = "088-137-12049"
                        },
                        new
                        {
                            Id = -36,
                            IsDeactivated = false,
                            IsEmployed = true,
                            Name = "Ronald Brown",
                            Phone = "997-425-15598"
                        },
                        new
                        {
                            Id = -37,
                            IsDeactivated = false,
                            IsEmployed = true,
                            Name = "Adam Harrison",
                            Phone = "337-229-93068"
                        },
                        new
                        {
                            Id = -38,
                            IsDeactivated = false,
                            IsEmployed = false,
                            Name = "Ursula Major",
                            Phone = "299-800-31549"
                        },
                        new
                        {
                            Id = -39,
                            IsDeactivated = false,
                            IsEmployed = true,
                            Name = "David Lewis",
                            Phone = "902-615-12519"
                        },
                        new
                        {
                            Id = -40,
                            IsDeactivated = false,
                            IsEmployed = false,
                            Name = "Robyn Hall",
                            Phone = "826-978-82939"
                        },
                        new
                        {
                            Id = -41,
                            IsDeactivated = false,
                            IsEmployed = true,
                            Name = "Roger Harrison",
                            Phone = "761-478-42890"
                        },
                        new
                        {
                            Id = -42,
                            IsDeactivated = false,
                            IsEmployed = true,
                            Name = "Philip Baker",
                            Phone = "363-257-63461"
                        },
                        new
                        {
                            Id = -43,
                            IsDeactivated = false,
                            IsEmployed = true,
                            Name = "Edwin Clarke",
                            Phone = "393-242-42053"
                        },
                        new
                        {
                            Id = -44,
                            IsDeactivated = false,
                            IsEmployed = false,
                            Name = "Ursula Robertson",
                            Phone = "145-893-99260"
                        },
                        new
                        {
                            Id = -45,
                            IsDeactivated = false,
                            IsEmployed = false,
                            Name = "Ruth Martinez",
                            Phone = "029-660-32389"
                        },
                        new
                        {
                            Id = -46,
                            IsDeactivated = false,
                            IsEmployed = false,
                            Name = "Richard Clarkson",
                            Phone = "784-656-33374"
                        },
                        new
                        {
                            Id = -47,
                            IsDeactivated = false,
                            IsEmployed = false,
                            Name = "Kevin Harrison",
                            Phone = "973-441-01267"
                        },
                        new
                        {
                            Id = -48,
                            IsDeactivated = false,
                            IsEmployed = true,
                            Name = "Anthony Anderson",
                            Phone = "961-081-90287"
                        },
                        new
                        {
                            Id = -49,
                            IsDeactivated = false,
                            IsEmployed = true,
                            Name = "Sarah Davies",
                            Phone = "026-991-07296"
                        },
                        new
                        {
                            Id = -50,
                            IsDeactivated = false,
                            IsEmployed = true,
                            Name = "Arthur Thatcher",
                            Phone = "413-387-80720"
                        });
                });

            modelBuilder.Entity("technology_tp1.Models.ItemImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Full")
                        .IsRequired();

                    b.Property<string>("Medium")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Small")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("ItemImages");
                });

            modelBuilder.Entity("technology_tp1.Models.MenuItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ImageId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<decimal>("Price");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.ToTable("MenuItems");
                });

            modelBuilder.Entity("technology_tp1.Models.MenuItem", b =>
                {
                    b.HasOne("technology_tp1.Models.ItemImage", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
