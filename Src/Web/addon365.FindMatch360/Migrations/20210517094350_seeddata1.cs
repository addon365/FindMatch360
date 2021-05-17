using Microsoft.EntityFrameworkCore.Migrations;

namespace addon365.FindMatch360.Migrations
{
    public partial class seeddata1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DoshamMasters",
                columns: new[] { "DoshamMasterId", "DoshamName" },
                values: new object[] { 1, "Test" });

            migrationBuilder.InsertData(
                table: "DoshamMasters",
                columns: new[] { "DoshamMasterId", "DoshamName" },
                values: new object[] { 2, "Test2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DoshamMasters",
                keyColumn: "DoshamMasterId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DoshamMasters",
                keyColumn: "DoshamMasterId",
                keyValue: 2);
        }
    }
}
