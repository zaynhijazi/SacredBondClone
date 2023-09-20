using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SacredBond.Core.Migrations
{
    public partial class ProfileLanguages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Language_Profile_ProfileId",
            //    table: "Language");

            //migrationBuilder.DropIndex(
            //    name: "IX_Language_ProfileId",
            //    table: "Language");

            //migrationBuilder.DropColumn(
            //    name: "ProfileId",
            //    table: "Language");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ProfileLanguage_LanguageId",
            //    table: "ProfileLanguage",
            //    column: "LanguageId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ProfileLanguage_ProfileId",
            //    table: "ProfileLanguage",
            //    column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileLanguage_Language_LanguageId",
                table: "ProfileLanguage",
                column: "LanguageId",
                principalTable: "Language",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileLanguage_Profile_ProfileId",
                table: "ProfileLanguage",
                column: "ProfileId",
                principalTable: "Profile",
                principalColumn: "ProfileId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfileLanguage_Language_LanguageId",
                table: "ProfileLanguage");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfileLanguage_Profile_ProfileId",
                table: "ProfileLanguage");

            //migrationBuilder.DropIndex(
            //    name: "IX_ProfileLanguage_LanguageId",
            //    table: "ProfileLanguage");

            //migrationBuilder.DropIndex(
            //    name: "IX_ProfileLanguage_ProfileId",
            //    table: "ProfileLanguage");

            //migrationBuilder.AddColumn<int>(
            //    name: "ProfileId",
            //    table: "Language",
            //    type: "int",
            //    nullable: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Language_ProfileId",
            //    table: "Language",
            //    column: "ProfileId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Language_Profile_ProfileId",
            //    table: "Language",
            //    column: "ProfileId",
            //    principalTable: "Profile",
            //    principalColumn: "ProfileId");
        }
    }
}
