using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaintyTestTask.Migrations
{
    /// <inheritdoc />
    public partial class AddFriendShipStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Friendship",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Friendship");
        }
    }
}
