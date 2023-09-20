using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SacredBond.Core.Migrations
{
    public partial class AddStatusChangesTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProfileMatchStatusChange",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    FromStatus = table.Column<int>(type: "int", nullable: false),
                    ToStatus = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileMatchStatusChange", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfileMatchStatusChange_ProfileMatches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "ProfileMatches",
                        principalColumn: "MatchId");
                });

            migrationBuilder.CreateTable(
                name: "ProfileStatusChange",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileId = table.Column<int>(type: "int", nullable: false),
                    FromStatus = table.Column<int>(type: "int", nullable: false),
                    ToStatus = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileStatusChange", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfileStatusChange_Profile_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profile",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfileMatchStatusChange_MatchId",
                table: "ProfileMatchStatusChange",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileStatusChange_ProfileId",
                table: "ProfileStatusChange",
                column: "ProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfileMatchStatusChange");

            migrationBuilder.DropTable(
                name: "ProfileStatusChange");
        }
    }
}
