using Microsoft.EntityFrameworkCore.Migrations;
using SacredBond.Core.Domain;

#nullable disable

namespace SacredBond.Core.Migrations
{
    public partial class AddProfileLanguageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Language_ProfileId",
                table: "Language");

            migrationBuilder.DropForeignKey(
                name: "FK_Language_Profile_ProfileId",
                table: "Language");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Language");

            migrationBuilder.CreateTable(
                "ProfileLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ProfileLanguageId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfileLanguage_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profile",
                        principalColumn: "ProfileId");
                    table.ForeignKey(
                        name: "FK_ProfileLanguage_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Language",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfileLanguage_ProfileId",
                table: "ProfileLanguage",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileLanguage_LanguageId",
                table: "ProfileLanguage",
                column: "LanguageId");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Language>(
                name: "ProfileId",
                table: "Language",
                type: "int",
                nullable: false);

            migrationBuilder.DropIndex(
                name: "IX_ProfileLanguage_LanguageId",
                table: "ProfileLanguage");

            migrationBuilder.DropIndex(
               name: "IX_ProfileLanguage_ProfileId",
               table: "ProfileLanguage");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfileLanguage_ProfileId",
                table: "ProfileLanguage");

            migrationBuilder.DropForeignKey(
               name: "FK_ProfileLanguage_LanguageId",
               table: "ProfileLanguage");


            migrationBuilder.DropTable(
                name: "ProfileLanguage");
        }
    }
}
