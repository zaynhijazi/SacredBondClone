using System;
using Microsoft.EntityFrameworkCore.Migrations;
using SacredBond.Core.Domain;

#nullable disable

namespace SacredBond.Core.Migrations
{
    public partial class AlterProfileMatchesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<ProfileMatches>(
                name: "ReviewedDate",
                table: "ProfileMatches",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<ProfileMatches>(
                name: "CompletedDate",
                table: "ProfileMatches",
                type: "datetime2",
                nullable: true);
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "CompletedDate", table: "ProfileMatches");
            migrationBuilder.DropColumn(name: "ReviewedDate", table: "ProfileMatches");
        }
    }
}
