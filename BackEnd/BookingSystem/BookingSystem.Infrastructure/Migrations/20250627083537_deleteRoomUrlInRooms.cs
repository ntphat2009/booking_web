using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class deleteRoomUrlInRooms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoomUrl",
                table: "Rooms");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_PropertyUrl",
                table: "Rooms",
                column: "PropertyUrl",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Rooms_PropertyUrl",
                table: "Rooms");

            migrationBuilder.AddColumn<string>(
                name: "RoomUrl",
                table: "Rooms",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");
        }
    }
}
