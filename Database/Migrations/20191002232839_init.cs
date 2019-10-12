using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace technology_tp1.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeliveryMen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    IsEmployed = table.Column<bool>(nullable: false),
                    IsDeactivated = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryMen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Small = table.Column<string>(nullable: false),
                    Medium = table.Column<string>(nullable: false),
                    Full = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    ImageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuItems_ItemImages_ImageId",
                        column: x => x.ImageId,
                        principalTable: "ItemImages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DeliveryMen",
                columns: new[] { "Id", "IsDeactivated", "IsEmployed", "Name", "Phone" },
                values: new object[,]
                {
                    { -1, false, true, "Charles White", "618-300-30280" },
                    { -28, false, false, "Beryl Davis", "018-065-14665" },
                    { -29, false, true, "Ronald Jeffries", "523-685-69677" },
                    { -30, false, false, "Nancy Jefferson", "678-181-12356" },
                    { -31, false, false, "Steven Robertson", "425-040-89374" },
                    { -32, false, false, "George White", "957-297-41924" },
                    { -33, false, true, "Charles Clark", "360-934-95238" },
                    { -34, false, false, "Helena Kirby", "099-451-48999" },
                    { -35, false, true, "Robyn Yorke", "088-137-12049" },
                    { -36, false, true, "Ronald Brown", "997-425-15598" },
                    { -37, false, true, "Adam Harrison", "337-229-93068" },
                    { -38, false, false, "Ursula Major", "299-800-31549" },
                    { -39, false, true, "David Lewis", "902-615-12519" },
                    { -40, false, false, "Robyn Hall", "826-978-82939" },
                    { -41, false, true, "Roger Harrison", "761-478-42890" },
                    { -42, false, true, "Philip Baker", "363-257-63461" },
                    { -43, false, true, "Edwin Clarke", "393-242-42053" },
                    { -44, false, false, "Ursula Robertson", "145-893-99260" },
                    { -45, false, false, "Ruth Martinez", "029-660-32389" },
                    { -46, false, false, "Richard Clarkson", "784-656-33374" },
                    { -47, false, false, "Kevin Harrison", "973-441-01267" },
                    { -48, false, true, "Anthony Anderson", "961-081-90287" },
                    { -27, false, false, "Anthony Brown", "876-527-54403" },
                    { -26, false, true, "Terry Kirk", "200-879-39392" },
                    { -25, false, false, "Hugh Martin", "926-865-64762" },
                    { -24, false, false, "Brian Moore", "963-843-58596" },
                    { -2, false, false, "Charlotte Anderson", "116-649-22017" },
                    { -3, false, true, "Jason Baker", "193-539-03413" },
                    { -4, false, true, "Victoria Moore", "832-521-53793" },
                    { -5, false, true, "Donna Garcia", "725-171-69810" },
                    { -6, false, true, "Kenneth Baker", "352-324-95195" },
                    { -7, false, false, "Linda Wilson", "920-131-04252" },
                    { -8, false, true, "Jason Davidson", "238-668-64088" },
                    { -9, false, false, "David Clarkson", "504-818-80293" },
                    { -10, false, true, "Simon Anderson", "150-972-79913" },
                    { -11, false, false, "Eve Lake", "463-091-96333" },
                    { -49, false, true, "Sarah Davies", "026-991-07296" },
                    { -12, false, false, "Michelle Davies", "765-062-63497" },
                    { -14, false, false, "Maria Harrison", "822-747-19628" },
                    { -15, false, true, "Anne Davidson", "049-525-68249" },
                    { -16, false, true, "Carol Jones", "286-005-86109" },
                    { -17, false, false, "Jason Oates", "399-777-01482" },
                    { -18, false, true, "Edgar Lewis", "048-199-67962" },
                    { -19, false, true, "Jennifer Dent", "653-509-79472" },
                    { -20, false, false, "Edgar Thatcher", "174-604-08577" },
                    { -21, false, true, "Anne Jones", "927-116-05153" },
                    { -22, false, true, "John Peterson", "235-155-31476" },
                    { -23, false, false, "Sandra Harris", "878-970-90010" },
                    { -13, false, true, "Matthew Stevens", "186-747-79982" },
                    { -50, false, true, "Arthur Thatcher", "413-387-80720" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_ImageId",
                table: "MenuItems",
                column: "ImageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeliveryMen");

            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "ItemImages");
        }
    }
}
