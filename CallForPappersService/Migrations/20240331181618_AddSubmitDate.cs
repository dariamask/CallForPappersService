using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CallForPappersService.Migrations
{
    public partial class AddSubmitDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "SubmitDate",
                table: "Applications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Applications_AuthorId",
                table: "Applications",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Applications_AuthorId",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "SubmitDate",
                table: "Applications");
        }
    }
}
