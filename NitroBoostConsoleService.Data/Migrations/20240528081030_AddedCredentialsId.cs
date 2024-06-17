using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NitroBoostConsoleService.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedCredentialsId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Devices_DeviceId1",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_DeviceId1",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "DeviceId1",
                table: "Games");

            migrationBuilder.AlterColumn<long>(
                name: "favourite_game_id",
                table: "Users",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "credentials_id",
                table: "Users",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<long>(
                name: "device_id",
                table: "Games",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_Games_device_id",
                table: "Games",
                column: "device_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Devices_device_id",
                table: "Games",
                column: "device_id",
                principalTable: "Devices",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Devices_device_id",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_device_id",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "credentials_id",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "favourite_game_id",
                table: "Users",
                type: "integer",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "device_id",
                table: "Games",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "DeviceId1",
                table: "Games",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_DeviceId1",
                table: "Games",
                column: "DeviceId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Devices_DeviceId1",
                table: "Games",
                column: "DeviceId1",
                principalTable: "Devices",
                principalColumn: "id");
        }
    }
}
