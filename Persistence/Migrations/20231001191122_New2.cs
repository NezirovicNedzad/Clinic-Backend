using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class New2 : Migration
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
                keyValue: "0a4f668d-6a74-4732-9af9-94ed690b18df");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39f44f27-3765-4de8-877c-7456c98e012f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "508ae97e-9535-4fa2-a190-980a3251a4e2");

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
                    { "0a4f668d-6a74-4732-9af9-94ed690b18df", null, "Admin", "ADMIN" },
                    { "39f44f27-3765-4de8-877c-7456c98e012f", null, "Sestra", "SESTRA" },
                    { "508ae97e-9535-4fa2-a190-980a3251a4e2", null, "Lekar", "LEKAR" }
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
    }
}
