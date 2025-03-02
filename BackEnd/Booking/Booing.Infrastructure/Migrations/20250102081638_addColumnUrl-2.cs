using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addColumnUrl2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Properties_PropertyUrl",
                table: "Properties",
                column: "PropertyUrl",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CityUrl",
                table: "Cities",
                column: "CityUrl",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CategoryUrl",
                table: "Categories",
                column: "CategoryUrl",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Properties_PropertyUrl",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Cities_CityUrl",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Categories_CategoryUrl",
                table: "Categories");
        }
    }
}
