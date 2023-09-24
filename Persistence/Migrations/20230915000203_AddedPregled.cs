using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedPregled : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Napomene",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NezeljenoDejstvo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Primedba = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KartonId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SestraId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Napomene", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Napomene_AspNetUsers_SestraId",
                        column: x => x.SestraId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Napomene_Kartoni_KartonId",
                        column: x => x.KartonId,
                        principalTable: "Kartoni",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pregledi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Anamneza = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dijagnoza = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Terapija = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KartonId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pregledi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pregledi_Kartoni_KartonId",
                        column: x => x.KartonId,
                        principalTable: "Kartoni",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Napomene_KartonId",
                table: "Napomene",
                column: "KartonId");

            migrationBuilder.CreateIndex(
                name: "IX_Napomene_SestraId",
                table: "Napomene",
                column: "SestraId");

            migrationBuilder.CreateIndex(
                name: "IX_Pregledi_KartonId",
                table: "Pregledi",
                column: "KartonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Napomene");

            migrationBuilder.DropTable(
                name: "Pregledi");
        }
    }
}
