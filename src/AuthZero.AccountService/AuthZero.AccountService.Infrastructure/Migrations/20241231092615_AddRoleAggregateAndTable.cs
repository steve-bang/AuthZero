using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthZero.AccountService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRoleAggregateAndTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_At",
                schema: "AuthZero",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 31, 9, 26, 15, 329, DateTimeKind.Utc).AddTicks(4070),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 28, 7, 46, 32, 464, DateTimeKind.Utc).AddTicks(9640));

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "AuthZero",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User_Roles",
                schema: "AuthZero",
                columns: table => new
                {
                    User_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Role_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    Last_Update_At = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Roles", x => new { x.User_Id, x.Role_Id });
                    table.ForeignKey(
                        name: "FK_User_Roles_Roles_Role_Id",
                        column: x => x.Role_Id,
                        principalSchema: "AuthZero",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Roles_Users_User_Id",
                        column: x => x.User_Id,
                        principalSchema: "AuthZero",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_Roles_Role_Id",
                schema: "AuthZero",
                table: "User_Roles",
                column: "Role_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User_Roles",
                schema: "AuthZero");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "AuthZero");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_At",
                schema: "AuthZero",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 28, 7, 46, 32, 464, DateTimeKind.Utc).AddTicks(9640),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 31, 9, 26, 15, 329, DateTimeKind.Utc).AddTicks(4070));
        }
    }
}
