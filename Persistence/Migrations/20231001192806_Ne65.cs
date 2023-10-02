using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Ne65 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { "1e44fb34-86df-4ba5-a640-73ef8ba42eaf", null, "Sestra", "SESTRA" },
                    { "48bfba19-8737-470d-bc4a-720523f1c3bd", null, "Lekar", "LEKAR" },
                    { "d6c27276-de3c-4d1a-8030-beef69f7bbf4", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e44fb34-86df-4ba5-a640-73ef8ba42eaf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48bfba19-8737-470d-bc4a-720523f1c3bd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d6c27276-de3c-4d1a-8030-beef69f7bbf4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1f154d26-f07d-4dcd-a152-8f8f1c676974", null, "Admin", "ADMIN" },
                    { "a0b82528-1560-4f02-8110-3014bf7785a4", null, "Sestra", "SESTRA" },
                    { "e0b49ee9-181a-4906-873d-0969907fd6fe", null, "Lekar", "LEKAR" }
                });
        }
    }
}
