using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthZero.AccountService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCreatedAtAndLastUpdateAtInUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created_At",
                schema: "AuthZero",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 28, 7, 46, 32, 464, DateTimeKind.Utc).AddTicks(9640));

            migrationBuilder.AddColumn<DateTime>(
                name: "Last_Update_At",
                schema: "AuthZero",
                table: "Users",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created_At",
                schema: "AuthZero",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Last_Update_At",
                schema: "AuthZero",
                table: "Users");
        }
    }
}
