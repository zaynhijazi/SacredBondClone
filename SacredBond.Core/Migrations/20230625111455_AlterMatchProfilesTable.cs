using System;
using Microsoft.EntityFrameworkCore.Migrations;
using SacredBond.Core.Domain;

#nullable disable

namespace SacredBond.Core.Migrations
{
    public partial class AlterMatchProfilesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CanceledDate",
                table: "ProfileMatches",
                type: "datetime2",
                nullable: true);

            migrationBuilder.DropColumn(
                name: "ReviewedDate",
                table: "ProfileMatches");

            migrationBuilder.AddColumn<DateTime>(
                name: "InReviewDate",
                table: "ProfileMatches",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CanceledDate",
                table: "ProfileMatches");

            migrationBuilder.AddColumn<ProfileMatches>(
                name: "ReviewedDate",
                table: "ProfileMatches",
                type: "datetime2",
                nullable: true);

            migrationBuilder.DropColumn(
                name: "InReviewDate",
                table: "ProfileMatches");
        }
    }
}
