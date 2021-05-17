using Microsoft.EntityFrameworkCore.Migrations;

namespace addon365.FindMatch360.Migrations
{
    public partial class seed1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CasteName",
                table: "CasteMasters",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "MotherTongueMasters",
                columns: new[] { "MotherTongueMasterId", "MotherTongueName" },
                values: new object[,]
                {
                    { 1, "Not Selected" },
                    { 12, "Urdu" },
                    { 11, "Sindhi" },
                    { 10, "Punjabi" },
                    { 9, "Gujarati" },
                    { 8, "Bengali" },
                    { 13, "Oriya" },
                    { 6, "Malayalam" },
                    { 5, "Kannada" },
                    { 4, "Hindi" },
                    { 3, "Telugu" },
                    { 2, "Tamil" },
                    { 7, "Marathi" }
                });

            migrationBuilder.InsertData(
                table: "ReligionMasters",
                columns: new[] { "ReligionMasterId", "ReligionName" },
                values: new object[,]
                {
                    { 11, "Parsi" },
                    { 10, "Jain - Others" },
                    { 9, "Jain - Shwetambar" },
                    { 8, "Jain - Digambar" },
                    { 7, "Sikh" },
                    { 4, "Muslim - Sunni" },
                    { 5, "Muslim - Others" },
                    { 3, "Muslim - Shia" },
                    { 2, "Hindu" },
                    { 1, "Not Selected" },
                    { 12, "Buddhist" },
                    { 6, "Christian" },
                    { 13, "Inter-Religion" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MotherTongueMasters",
                keyColumn: "MotherTongueMasterId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MotherTongueMasters",
                keyColumn: "MotherTongueMasterId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MotherTongueMasters",
                keyColumn: "MotherTongueMasterId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MotherTongueMasters",
                keyColumn: "MotherTongueMasterId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MotherTongueMasters",
                keyColumn: "MotherTongueMasterId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MotherTongueMasters",
                keyColumn: "MotherTongueMasterId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MotherTongueMasters",
                keyColumn: "MotherTongueMasterId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "MotherTongueMasters",
                keyColumn: "MotherTongueMasterId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "MotherTongueMasters",
                keyColumn: "MotherTongueMasterId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "MotherTongueMasters",
                keyColumn: "MotherTongueMasterId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "MotherTongueMasters",
                keyColumn: "MotherTongueMasterId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "MotherTongueMasters",
                keyColumn: "MotherTongueMasterId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "MotherTongueMasters",
                keyColumn: "MotherTongueMasterId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ReligionMasters",
                keyColumn: "ReligionMasterId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ReligionMasters",
                keyColumn: "ReligionMasterId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ReligionMasters",
                keyColumn: "ReligionMasterId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ReligionMasters",
                keyColumn: "ReligionMasterId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ReligionMasters",
                keyColumn: "ReligionMasterId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ReligionMasters",
                keyColumn: "ReligionMasterId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ReligionMasters",
                keyColumn: "ReligionMasterId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ReligionMasters",
                keyColumn: "ReligionMasterId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ReligionMasters",
                keyColumn: "ReligionMasterId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ReligionMasters",
                keyColumn: "ReligionMasterId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ReligionMasters",
                keyColumn: "ReligionMasterId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ReligionMasters",
                keyColumn: "ReligionMasterId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ReligionMasters",
                keyColumn: "ReligionMasterId",
                keyValue: 13);

            migrationBuilder.AlterColumn<int>(
                name: "CasteName",
                table: "CasteMasters",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
