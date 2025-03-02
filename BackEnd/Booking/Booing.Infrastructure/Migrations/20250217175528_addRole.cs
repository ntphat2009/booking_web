using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Booking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "318bf28e-77cb-4284-aa7b-1a3fc48b205e", "1", "User", "User" },
                    { "522043db-cd9e-43ba-b58b-e5b08f891370", "3", "Admin", "Admin" },
                    { "58d5f649-ce9c-4211-84cc-25424680ac8b", "2", "Partner", "Partner" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "318bf28e-77cb-4284-aa7b-1a3fc48b205e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "522043db-cd9e-43ba-b58b-e5b08f891370");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58d5f649-ce9c-4211-84cc-25424680ac8b");
        }
    }
}
