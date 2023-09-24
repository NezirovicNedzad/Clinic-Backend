using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedDeleteCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Napomene_Kartoni_KartonId",
                table: "Napomene");

            migrationBuilder.DropForeignKey(
                name: "FK_Pregledi_Kartoni_KartonId",
                table: "Pregledi");

            migrationBuilder.AddForeignKey(
                name: "FK_Napomene_Kartoni_KartonId",
                table: "Napomene",
                column: "KartonId",
                principalTable: "Kartoni",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pregledi_Kartoni_KartonId",
                table: "Pregledi",
                column: "KartonId",
                principalTable: "Kartoni",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Napomene_Kartoni_KartonId",
                table: "Napomene");

            migrationBuilder.DropForeignKey(
                name: "FK_Pregledi_Kartoni_KartonId",
                table: "Pregledi");

            migrationBuilder.AddForeignKey(
                name: "FK_Napomene_Kartoni_KartonId",
                table: "Napomene",
                column: "KartonId",
                principalTable: "Kartoni",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pregledi_Kartoni_KartonId",
                table: "Pregledi",
                column: "KartonId",
                principalTable: "Kartoni",
                principalColumn: "Id");
        }
    }
}
