using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PacijentAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OdeljenjeId",
                table: "Pacijenti",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pacijenti_OdeljenjeId",
                table: "Pacijenti",
                column: "OdeljenjeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacijenti_Odeljenja_OdeljenjeId",
                table: "Pacijenti",
                column: "OdeljenjeId",
                principalTable: "Odeljenja",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacijenti_Odeljenja_OdeljenjeId",
                table: "Pacijenti");

            migrationBuilder.DropIndex(
                name: "IX_Pacijenti_OdeljenjeId",
                table: "Pacijenti");

            migrationBuilder.DropColumn(
                name: "OdeljenjeId",
                table: "Pacijenti");
        }
    }
}
