using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class New5 : Migration
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
                keyValue: "2730b1e3-26a2-46ea-9261-bd20cf00d293");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "965676ae-7885-4b22-a558-b5f4f6e43a82");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc193383-0c07-40e7-8aa5-fbad8bcb7508");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1f154d26-f07d-4dcd-a152-8f8f1c676974", null, "Admin", "ADMIN" },
                    { "a0b82528-1560-4f02-8110-3014bf7785a4", null, "Sestra", "SESTRA" },
                    { "e0b49ee9-181a-4906-873d-0969907fd6fe", null, "Lekar", "LEKAR" }
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
                keyValue: "1f154d26-f07d-4dcd-a152-8f8f1c676974");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0b82528-1560-4f02-8110-3014bf7785a4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e0b49ee9-181a-4906-873d-0969907fd6fe");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2730b1e3-26a2-46ea-9261-bd20cf00d293", null, "Lekar", "LEKAR" },
                    { "965676ae-7885-4b22-a558-b5f4f6e43a82", null, "Admin", "ADMIN" },
                    { "dc193383-0c07-40e7-8aa5-fbad8bcb7508", null, "Sestra", "SESTRA" }
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
