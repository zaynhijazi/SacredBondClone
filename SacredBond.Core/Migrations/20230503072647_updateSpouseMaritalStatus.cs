using Microsoft.EntityFrameworkCore.Migrations;
using SacredBond.Core.Domain;

#nullable disable

namespace SacredBond.Core.Migrations
{
    public partial class updateSpouseMaritalStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpouseMaritalStatus_Profile_ProfileId",
                table: "SpouseMaritalStatus");

            migrationBuilder.DropTable(
                name: "SpouseMaritalStatus");

            migrationBuilder.AddColumn<Profile>(
                name: "SpouseMaritalStatusesId",
                table: "Profile",
                type: "int",
                 nullable: true,
                defaultValue: null);

            migrationBuilder.CreateIndex(
                name: "IX_Profile_SpouseMaritalStatusesId",
                table: "Profile",
                column: "SpouseMaritalStatusesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Profile_SpouseMaritalStatusesId",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "SpouseMaritalStatusesId",
                table: "Profile");

            migrationBuilder.CreateTable(
                name: "SpouseMaritalStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("SpouseMaritalStatusId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpouseMaritalStatus_Profile_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profile",
                        principalColumn: "ProfileId");
                });
        }
    }
}
