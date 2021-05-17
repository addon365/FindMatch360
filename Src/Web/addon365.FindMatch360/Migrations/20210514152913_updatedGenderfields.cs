using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace addon365.FindMatch360.Migrations
{
    public partial class updatedGenderfields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "Gender",
                table: "ProfileForMaster",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Gender",
                table: "MatrimonyProfiles",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "MatrimonyProfiles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "ProfileForMaster");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "MatrimonyProfiles");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "MatrimonyProfiles");
        }
    }
}
