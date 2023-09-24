using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedPregled2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Pregledi",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pregledi_AppUserId",
                table: "Pregledi",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pregledi_AspNetUsers_AppUserId",
                table: "Pregledi",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pregledi_AspNetUsers_AppUserId",
                table: "Pregledi");

            migrationBuilder.DropIndex(
                name: "IX_Pregledi_AppUserId",
                table: "Pregledi");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Pregledi");
        }
    }
}
