using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedPregled4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pregledi_AspNetUsers_AppUserId",
                table: "Pregledi");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Pregledi",
                newName: "LekarId");

            migrationBuilder.RenameIndex(
                name: "IX_Pregledi_AppUserId",
                table: "Pregledi",
                newName: "IX_Pregledi_LekarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pregledi_AspNetUsers_LekarId",
                table: "Pregledi",
                column: "LekarId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pregledi_AspNetUsers_LekarId",
                table: "Pregledi");

            migrationBuilder.RenameColumn(
                name: "LekarId",
                table: "Pregledi",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Pregledi_LekarId",
                table: "Pregledi",
                newName: "IX_Pregledi_AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pregledi_AspNetUsers_AppUserId",
                table: "Pregledi",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
