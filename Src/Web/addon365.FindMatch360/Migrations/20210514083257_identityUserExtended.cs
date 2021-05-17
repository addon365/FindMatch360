using Microsoft.EntityFrameworkCore.Migrations;

namespace addon365.FindMatch360.Migrations
{
    public partial class identityUserExtended : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfileForId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfileMatrimonyProfileId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProfileForMaster",
                columns: table => new
                {
                    ProfileForId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileFor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileForMaster", x => x.ProfileForId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ProfileForId",
                table: "AspNetUsers",
                column: "ProfileForId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ProfileMatrimonyProfileId",
                table: "AspNetUsers",
                column: "ProfileMatrimonyProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ProfileForMaster_ProfileForId",
                table: "AspNetUsers",
                column: "ProfileForId",
                principalTable: "ProfileForMaster",
                principalColumn: "ProfileForId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_MatrimonyProfiles_ProfileMatrimonyProfileId",
                table: "AspNetUsers",
                column: "ProfileMatrimonyProfileId",
                principalTable: "MatrimonyProfiles",
                principalColumn: "MatrimonyProfileId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ProfileForMaster_ProfileForId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_MatrimonyProfiles_ProfileMatrimonyProfileId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ProfileForMaster");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ProfileForId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ProfileMatrimonyProfileId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfileForId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfileMatrimonyProfileId",
                table: "AspNetUsers");
        }
    }
}
