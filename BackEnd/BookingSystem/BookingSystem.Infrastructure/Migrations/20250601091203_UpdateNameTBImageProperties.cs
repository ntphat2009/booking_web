using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNameTBImageProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImagePropertíe_Properties_PropertyId",
                table: "ImagePropertíe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImagePropertíe",
                table: "ImagePropertíe");

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "7183262a-6db1-4aae-b3a8-12bc2033f003");

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "8cb7fd08-0f9b-4fd5-817a-abb20e242ce9");

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "e6dc48b8-51fc-4f34-84d4-d98aa8328c37");

            migrationBuilder.RenameTable(
                name: "ImagePropertíe",
                newName: "ImageProperties");

            migrationBuilder.RenameIndex(
                name: "IX_ImagePropertíe_PropertyId",
                table: "ImageProperties",
                newName: "IX_ImageProperties_PropertyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImageProperties",
                table: "ImageProperties",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageProperties_Properties_PropertyId",
                table: "ImageProperties",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageProperties_Properties_PropertyId",
                table: "ImageProperties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImageProperties",
                table: "ImageProperties");

            migrationBuilder.RenameTable(
                name: "ImageProperties",
                newName: "ImagePropertíe");

            migrationBuilder.RenameIndex(
                name: "IX_ImageProperties_PropertyId",
                table: "ImagePropertíe",
                newName: "IX_ImagePropertíe_PropertyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImagePropertíe",
                table: "ImagePropertíe",
                column: "Id");

            //migrationBuilder.InsertData(
            //    table: "AspNetRoles",
            //    columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
            //    values: new object[,]
            //    {
            //        { "7183262a-6db1-4aae-b3a8-12bc2033f003", "1", "User", "User" },
            //        { "8cb7fd08-0f9b-4fd5-817a-abb20e242ce9", "3", "Admin", "Admin" },
            //        { "e6dc48b8-51fc-4f34-84d4-d98aa8328c37", "2", "Partner", "Partner" }
            //    });

            migrationBuilder.AddForeignKey(
                name: "FK_ImagePropertíe_Properties_PropertyId",
                table: "ImagePropertíe",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
