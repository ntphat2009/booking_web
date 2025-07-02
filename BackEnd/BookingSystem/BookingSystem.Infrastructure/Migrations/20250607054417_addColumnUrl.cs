using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addColumnUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageURL",
                table: "ImageRooms",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "ImageURL",
                table: "ImageProperties",
                newName: "ImageUrl");

            migrationBuilder.AddColumn<string>(
                name: "PropertyUrl",
                table: "Tags",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PropertyUrl",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PropertyUrl",
                table: "Rooms",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Street",
                table: "Properties",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "PropertyUrl",
                table: "Properties",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Properties",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "District",
                table: "Properties",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AddColumn<string>(
                name: "CityUrl",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RoomUrl",
                table: "ImageRooms",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PropertyUrl",
                table: "ImageProperties",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CategoryUrl",
                table: "Cities",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RoomUrl",
                table: "Books",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Books_RoomUrl",
                table: "Books",
                column: "RoomUrl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Books_RoomUrl",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "PropertyUrl",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "PropertyUrl",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "PropertyUrl",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "CityUrl",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "RoomUrl",
                table: "ImageRooms");

            migrationBuilder.DropColumn(
                name: "PropertyUrl",
                table: "ImageProperties");

            migrationBuilder.DropColumn(
                name: "CategoryUrl",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "RoomUrl",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "ImageRooms",
                newName: "ImageURL");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "ImageProperties",
                newName: "ImageURL");

            migrationBuilder.AlterColumn<string>(
                name: "Street",
                table: "Properties",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "PropertyUrl",
                table: "Properties",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Properties",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "District",
                table: "Properties",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);
        }
    }
}
