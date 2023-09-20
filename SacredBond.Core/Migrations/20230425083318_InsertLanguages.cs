using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SacredBond.Core.Migrations
{
    public partial class InsertLanguages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                                SET IDENTITY_INSERT dbo.Language ON;  
                                GO  
                                INSERT INTO dbo.Language(Id, Name) VALUES (1, N'English');
                                INSERT INTO dbo.Language(Id, Name) VALUES (2, N'Spanish');
                                INSERT INTO dbo.Language(Id, Name) VALUES (3, N'French');
                                INSERT INTO dbo.Language(Id, Name) VALUES (4, N'German');
                                INSERT INTO dbo.Language(Id, Name) VALUES (5, N'Chinese');
                                INSERT INTO dbo.Language(Id, Name) VALUES (6, N'Hindi');
                                INSERT INTO dbo.Language(Id, Name) VALUES (7, N'Arabic');
                                INSERT INTO dbo.Language(Id, Name) VALUES (8, N'Urdu');
                                INSERT INTO dbo.Language(Id, Name) VALUES (9, N'Amharic');
                                INSERT INTO dbo.Language(Id, Name) VALUES (999, N'Other');");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                                SET IDENTITY_INSERT dbo.Language OFF;  
                                GO  
                                DELETE FROM dbo.Language WHERE id IN (1,2,3,4,5,6,7,8,9,999);");
        }
    }
}
