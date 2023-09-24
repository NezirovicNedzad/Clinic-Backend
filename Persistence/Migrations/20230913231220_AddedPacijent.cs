using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedPacijent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LekarId",
                table: "Pacijenti",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pacijenti_LekarId",
                table: "Pacijenti",
                column: "LekarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacijenti_AspNetUsers_LekarId",
                table: "Pacijenti",
                column: "LekarId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacijenti_AspNetUsers_LekarId",
                table: "Pacijenti");

            migrationBuilder.DropIndex(
                name: "IX_Pacijenti_LekarId",
                table: "Pacijenti");

            migrationBuilder.DropColumn(
                name: "LekarId",
                table: "Pacijenti");
        }
    }
}
