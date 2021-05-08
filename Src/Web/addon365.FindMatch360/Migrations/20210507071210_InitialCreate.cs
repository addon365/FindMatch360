using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace addon365.FindMatch360.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MatrimonyProfiles",
                columns: table => new
                {
                    MatrimonyProfileId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    DateandTimeOfBirth = table.Column<DateTime>(nullable: false),
                    Place = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    Height = table.Column<string>(nullable: true),
                    Nakshatra = table.Column<string>(nullable: true),
                    Rasi = table.Column<string>(nullable: true),
                    Lagnam = table.Column<string>(nullable: true),
                    ChevvaiDosham = table.Column<bool>(nullable: false),
                    BirthNumberinFamily = table.Column<short>(nullable: false),
                    Brothers = table.Column<short>(nullable: false),
                    MarriedBrothers = table.Column<short>(nullable: false),
                    Sisters = table.Column<short>(nullable: false),
                    MarriedSisters = table.Column<short>(nullable: false),
                    JobPosition = table.Column<string>(nullable: true),
                    CompanyAddress = table.Column<string>(nullable: true),
                    MonthlyRevenue = table.Column<string>(nullable: true),
                    FatherName = table.Column<string>(nullable: true),
                    FatherQualification = table.Column<string>(nullable: true),
                    FatherJob = table.Column<string>(nullable: true),
                    MotherName = table.Column<string>(nullable: true),
                    MotherQualification = table.Column<string>(nullable: true),
                    MotherJob = table.Column<string>(nullable: true),
                    NativeDistrict = table.Column<string>(nullable: true),
                    ContactPerson = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    PhoneNo = table.Column<string>(nullable: true),
                    MobileNo = table.Column<string>(nullable: true),
                    EmailId = table.Column<string>(nullable: true),
                    ExpectedQualification = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatrimonyProfiles", x => x.MatrimonyProfileId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatrimonyProfiles");
        }
    }
}
