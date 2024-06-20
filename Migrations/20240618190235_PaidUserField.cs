using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace qs_server.Migrations
{
    /// <inheritdoc />
    public partial class PaidUserField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "UserProfiles",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PaidUser",
                table: "UserProfiles",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e2d9884f-5155-4f66-ad8e-dcfa2aebc02c", "AQAAAAIAAYagAAAAELSN6rUeCTwRqnSQ3+0dO/IS6J6CN69nfdHMzQ4YVwgNg2eBbfiaPosqzCgbTGjudA==", "8af3222d-b36f-410e-9884-eb2aa5aacb97" });

            migrationBuilder.UpdateData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: 1,
                column: "PaidUser",
                value: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaidUser",
                table: "UserProfiles");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "UserProfiles",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a695a17-b27e-4de5-a1e3-5db7844eaf05", "AQAAAAIAAYagAAAAEKIgjIlt8NYGpscKVf+awj9Xn6Yh/9Pj1OdkKdFUO4mB0oEk8DrC3HBPyLmLTEMhCA==", "176cc726-6ddf-4145-aee6-e34b22132172" });
        }
    }
}
