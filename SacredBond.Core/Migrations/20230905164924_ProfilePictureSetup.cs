using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SacredBond.Core.Migrations
{
    public partial class ProfilePictureSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPicturesCompleted",
                table: "Profile",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "ProfilePicture",
                columns: table => new
                {
                    ProfilePictureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PictureUri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SasToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PictureNumber = table.Column<int>(type: "int", nullable: false),
                    ProfileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfilePicture", x => x.ProfilePictureId);
                    table.ForeignKey(
                        name: "FK_ProfilePicture_Profile_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profile",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfilePicture_ProfileId",
                table: "ProfilePicture",
                column: "ProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfilePicture");

            migrationBuilder.DropColumn(
                name: "IsPicturesCompleted",
                table: "Profile");
        }
    }
}
