using Microsoft.EntityFrameworkCore.Migrations;

namespace addon365.FindMatch360.Migrations
{
    public partial class ProfileForMasters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ProfileForMaster_ProfileForId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfileForMaster",
                table: "ProfileForMaster");

            migrationBuilder.RenameTable(
                name: "ProfileForMaster",
                newName: "profileForMasters");

            migrationBuilder.AddPrimaryKey(
                name: "PK_profileForMasters",
                table: "profileForMasters",
                column: "ProfileForId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_profileForMasters_ProfileForId",
                table: "AspNetUsers",
                column: "ProfileForId",
                principalTable: "profileForMasters",
                principalColumn: "ProfileForId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_profileForMasters_ProfileForId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_profileForMasters",
                table: "profileForMasters");

            migrationBuilder.RenameTable(
                name: "profileForMasters",
                newName: "ProfileForMaster");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfileForMaster",
                table: "ProfileForMaster",
                column: "ProfileForId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ProfileForMaster_ProfileForId",
                table: "AspNetUsers",
                column: "ProfileForId",
                principalTable: "ProfileForMaster",
                principalColumn: "ProfileForId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
