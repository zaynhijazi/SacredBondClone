using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SacredBond.Core.Migrations
{
    public partial class ProfileMatchesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "ProfileMatches",
                columns: table => new
                {
                    MatchId = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileId = table.Column<int>(type: "int", nullable: false),
                    SpouseId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    StatusChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RejectedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("MatchId", x => x.MatchId);
                    table.ForeignKey(
                        name: "FK_ProfileMatches_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profile",
                        principalColumn: "ProfileId");
                    table.ForeignKey(
                        name: "FK_ProfileMatches_SpouseId",
                        column: x => x.SpouseId,
                        principalTable: "Profile",
                        principalColumn: "ProfileId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfileMatches_ProfileId",
                table: "ProfileMatches",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileMatches_SpouseId",
                table: "ProfileMatches",
                column: "SpouseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropIndex(
                name: "IX_ProfileMatches_SpouseId",
                table: "ProfileMatches");

            migrationBuilder.DropIndex(
               name: "IX_ProfileMatches_ProfileId",
               table: "ProfileMatches");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfileMatches_SpouseId",
                table: "ProfileMatches");

            migrationBuilder.DropForeignKey(
               name: "FK_ProfileMatches_ProfileId",
               table: "ProfileMatches");


            migrationBuilder.DropTable(
                name: "ProfileMatches");
        }
    }

}
