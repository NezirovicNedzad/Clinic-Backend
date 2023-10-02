using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class New4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { "2730b1e3-26a2-46ea-9261-bd20cf00d293", null, "Lekar", "LEKAR" },
                    { "965676ae-7885-4b22-a558-b5f4f6e43a82", null, "Admin", "ADMIN" },
                    { "dc193383-0c07-40e7-8aa5-fbad8bcb7508", null, "Sestra", "SESTRA" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                    { "58a9b051-18ae-4f5b-b518-eb08e2404955", null, "Lekar", "LEKAR" },
                    { "5e93a137-001a-4bc5-92b2-2b9b3cf1a310", null, "Admin", "ADMIN" },
                    { "9fc4a39f-de3a-4ab6-b915-32d13b057897", null, "Sestra", "SESTRA" }
                });
        }
    }
}
