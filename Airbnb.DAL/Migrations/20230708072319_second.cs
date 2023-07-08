using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Airbnb.DAL.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isAvailable",
                table: "Properties",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_revied",
                table: "Bookings",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "isAvailable",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "is_revied",
                table: "Bookings");
        }
    }
}
