using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SacredBond.Core.Migrations
{
    public partial class alterProfileFieldToAllowNullValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.Sql(@"ALTER TABLE dbo.Profile ALTER COLUMN ConsiderSpouseWithChildren INT NULL;");
            migrationBuilder.AlterColumn<int>(
                name: "ConsiderSpouseWithChildren",
                table: "Profile",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                    UPDATE dbo.Profile SET  ConsiderSpouseWithChildren = 0 WHERE ConsiderSpouseWithChildren IS NULL;");
            //        ALTER TABLE dbo.Profile ALTER COLUMN ConsiderSpouseWithChildren INT NOT NULL;");

            migrationBuilder.AlterColumn<int>(
                name: "ConsiderSpouseWithChildren",
                table: "Profile",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
