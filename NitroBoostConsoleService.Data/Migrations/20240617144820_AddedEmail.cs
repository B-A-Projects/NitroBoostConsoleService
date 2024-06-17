using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NitroBoostConsoleService.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "credentials_id",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "validated",
                table: "Users");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_date",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created_date",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "email",
                table: "Users");

            migrationBuilder.AddColumn<long>(
                name: "credentials_id",
                table: "Users",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "validated",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
