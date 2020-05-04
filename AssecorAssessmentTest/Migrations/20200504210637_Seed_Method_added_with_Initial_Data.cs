using Microsoft.EntityFrameworkCore.Migrations;

namespace AssecorAssessmentTest.Migrations
{
    public partial class Seed_Method_added_with_Initial_Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "City", "Color", "FirstName", "Lastname", "Zipcode" },
                values: new object[] { 1, "Stralsund", null, "Peter", "Petersen", "18439" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "City", "Color", "FirstName", "Lastname", "Zipcode" },
                values: new object[] { 6, "Japan,", null, "Tastatur,", "Fujitsu,", "42342" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
