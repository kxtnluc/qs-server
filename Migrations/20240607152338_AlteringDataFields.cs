using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace qs_server.Migrations
{
    /// <inheritdoc />
    public partial class AlteringDataFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuestionSectionId",
                table: "QuestionGroups");

            migrationBuilder.AddColumn<bool>(
                name: "MultipleResponses",
                table: "Questions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PaidUsersOnly",
                table: "Questions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8ceeacc2-ce73-4178-af0f-698ec698ebab", "AQAAAAIAAYagAAAAEAXlUaUE1d7eHtsGCESSNEEcsCBwgTWFqdrQ4LdY9S4wLexReVm0ohjaX3bA+sODfA==", "98edd8ca-6cdc-4c16-aef2-1661922cecb2" });

            migrationBuilder.UpdateData(
                table: "Memberships",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "Price" },
                values: new object[] { "Yearly", 60L });

            migrationBuilder.InsertData(
                table: "Memberships",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { 4, "Lifetime", 300L });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "MultipleResponses", "PaidUsersOnly" },
                values: new object[] { false, false });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "MultipleResponses", "PaidUsersOnly" },
                values: new object[] { false, false });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "MultipleResponses", "PaidUsersOnly" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "MultipleResponses", "PaidUsersOnly" },
                values: new object[] { true, true });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "MultipleResponses", "PaidUsersOnly" },
                values: new object[] { true, true });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "MultipleResponses", "PaidUsersOnly" },
                values: new object[] { true, true });

            migrationBuilder.CreateIndex(
                name: "IX_UserQuestions_QuestionId",
                table: "UserQuestions",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuestionGroupId",
                table: "Questions",
                column: "QuestionGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_QuestionGroups_QuestionGroupId",
                table: "Questions",
                column: "QuestionGroupId",
                principalTable: "QuestionGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserQuestions_Questions_QuestionId",
                table: "UserQuestions",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_QuestionGroups_QuestionGroupId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserQuestions_Questions_QuestionId",
                table: "UserQuestions");

            migrationBuilder.DropIndex(
                name: "IX_UserQuestions_QuestionId",
                table: "UserQuestions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_QuestionGroupId",
                table: "Questions");

            migrationBuilder.DeleteData(
                table: "Memberships",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "MultipleResponses",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "PaidUsersOnly",
                table: "Questions");

            migrationBuilder.AddColumn<int>(
                name: "QuestionSectionId",
                table: "QuestionGroups",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b990618e-fa40-47fe-b97d-ae2ca0fdb511", "AQAAAAIAAYagAAAAEIUhTPnUFVPBbKtXcBByaefBXjrL8E8Am8LfDfHvWksiADTbHGsoV6+c77EDj6AJhg==", "5314ea8a-64d6-4930-857c-fca5b8f9d9a8" });

            migrationBuilder.UpdateData(
                table: "Memberships",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "Price" },
                values: new object[] { "Lifetime", 300L });

            migrationBuilder.UpdateData(
                table: "QuestionGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "QuestionSectionId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "QuestionGroups",
                keyColumn: "Id",
                keyValue: 2,
                column: "QuestionSectionId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "QuestionGroups",
                keyColumn: "Id",
                keyValue: 3,
                column: "QuestionSectionId",
                value: 0);
        }
    }
}
