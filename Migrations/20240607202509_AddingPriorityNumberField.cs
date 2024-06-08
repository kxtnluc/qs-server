using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace qs_server.Migrations
{
    /// <inheritdoc />
    public partial class AddingPriorityNumberField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PriorityNumber",
                table: "UserQuestions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "ce8fcf5e-bcea-4a4e-a372-ef8a85c3e4a7", "AQAAAAIAAYagAAAAEBtqoNrTVa6jA3pspRri0lDezorYY8iEi1dJHGI0cGeiaJSlI1EeeOmjlmEezQUrbA==", "03057e55-a67a-4708-a312-0aca79ea45ca", null });

            migrationBuilder.UpdateData(
                table: "UserQuestions",
                keyColumn: "Id",
                keyValue: 1,
                column: "PriorityNumber",
                value: 1);

            migrationBuilder.UpdateData(
                table: "UserQuestions",
                keyColumn: "Id",
                keyValue: 2,
                column: "PriorityNumber",
                value: 2);

            migrationBuilder.UpdateData(
                table: "UserQuestions",
                keyColumn: "Id",
                keyValue: 3,
                column: "PriorityNumber",
                value: 1);

            migrationBuilder.UpdateData(
                table: "UserQuestions",
                keyColumn: "Id",
                keyValue: 4,
                column: "PriorityNumber",
                value: 2);

            migrationBuilder.UpdateData(
                table: "UserQuestions",
                keyColumn: "Id",
                keyValue: 5,
                column: "PriorityNumber",
                value: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriorityNumber",
                table: "UserQuestions");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "UserProfiles",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "8ceeacc2-ce73-4178-af0f-698ec698ebab", "AQAAAAIAAYagAAAAEAXlUaUE1d7eHtsGCESSNEEcsCBwgTWFqdrQ4LdY9S4wLexReVm0ohjaX3bA+sODfA==", "98edd8ca-6cdc-4c16-aef2-1661922cecb2", "Administrator" });
        }
    }
}
