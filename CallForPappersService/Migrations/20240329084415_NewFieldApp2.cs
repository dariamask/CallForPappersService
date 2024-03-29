using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CallForPappersService.Migrations
{
    public partial class NewFieldApp2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Applications_ActivityId",
                table: "Applications",
                column: "ActivityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Activities_ActivityId",
                table: "Applications",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Activities_ActivityId",
                table: "Applications");

            migrationBuilder.DropIndex(
                name: "IX_Applications_ActivityId",
                table: "Applications");
        }
    }
}
