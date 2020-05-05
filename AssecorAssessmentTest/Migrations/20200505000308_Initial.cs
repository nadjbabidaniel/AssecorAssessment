using Microsoft.EntityFrameworkCore.Migrations;

namespace AssecorAssessmentTest.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Lastname = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    Zipcode = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "City", "Color", "FirstName", "Lastname", "Zipcode" },
                values: new object[] { 1, "18439 Stralsund", null, "Peter", "Petersen", null });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "City", "Color", "FirstName", "Lastname", "Zipcode" },
                values: new object[] { 6, "Japan,", null, "Tastatur,", "Fujitsu,", "42342" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
