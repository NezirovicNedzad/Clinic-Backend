using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class New3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Napomene_AspNetUsers_SestraId",
                table: "Napomene");

            migrationBuilder.DropForeignKey(
                name: "FK_Pacijenti_Odeljenja_OdeljenjeId",
                table: "Pacijenti");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "811d1d1c-2c32-49f3-8288-c6be143e3808");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a078cca9-7ff2-487b-8d36-374465aef3bc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a971a719-12b6-4501-a4e6-f5bc29370ed8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "58a9b051-18ae-4f5b-b518-eb08e2404955", null, "Lekar", "LEKAR" },
                    { "5e93a137-001a-4bc5-92b2-2b9b3cf1a310", null, "Admin", "ADMIN" },
                    { "9fc4a39f-de3a-4ab6-b915-32d13b057897", null, "Sestra", "SESTRA" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Napomene_AspNetUsers_SestraId",
                table: "Napomene",
                column: "SestraId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

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
                name: "FK_Napomene_AspNetUsers_SestraId",
                table: "Napomene");

            migrationBuilder.DropForeignKey(
                name: "FK_Pacijenti_Odeljenja_OdeljenjeId",
                table: "Pacijenti");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58a9b051-18ae-4f5b-b518-eb08e2404955");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e93a137-001a-4bc5-92b2-2b9b3cf1a310");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9fc4a39f-de3a-4ab6-b915-32d13b057897");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "811d1d1c-2c32-49f3-8288-c6be143e3808", null, "Lekar", "LEKAR" },
                    { "a078cca9-7ff2-487b-8d36-374465aef3bc", null, "Admin", "ADMIN" },
                    { "a971a719-12b6-4501-a4e6-f5bc29370ed8", null, "Sestra", "SESTRA" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Napomene_AspNetUsers_SestraId",
                table: "Napomene",
                column: "SestraId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pacijenti_Odeljenja_OdeljenjeId",
                table: "Pacijenti",
                column: "OdeljenjeId",
                principalTable: "Odeljenja",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
