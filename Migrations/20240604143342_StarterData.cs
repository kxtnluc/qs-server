using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace qs_server.Migrations
{
    /// <inheritdoc />
    public partial class StarterData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MembershipId",
                table: "UserProfiles",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Memberships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memberships", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestionGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    QuestionSectionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Body = table.Column<string>(type: "text", nullable: false),
                    QuestionGroupId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserProfileId = table.Column<int>(type: "integer", nullable: false),
                    QuestionId = table.Column<int>(type: "integer", nullable: false),
                    Response = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserQuestions", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b990618e-fa40-47fe-b97d-ae2ca0fdb511", "AQAAAAIAAYagAAAAEIUhTPnUFVPBbKtXcBByaefBXjrL8E8Am8LfDfHvWksiADTbHGsoV6+c77EDj6AJhg==", "5314ea8a-64d6-4930-857c-fca5b8f9d9a8" });

            migrationBuilder.InsertData(
                table: "Memberships",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Free", 0L },
                    { 2, "Monthly", 10L },
                    { 3, "Lifetime", 300L }
                });

            migrationBuilder.InsertData(
                table: "QuestionGroups",
                columns: new[] { "Id", "QuestionSectionId", "Title" },
                values: new object[,]
                {
                    { 1, 0, "User" },
                    { 2, 0, "Pet" },
                    { 3, 0, "Bank" }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Body", "QuestionGroupId" },
                values: new object[,]
                {
                    { 1, "First Name", 1 },
                    { 2, "Last Name", 1 },
                    { 3, "Number of Pets", 2 },
                    { 4, "Pet Name", 2 },
                    { 5, "Bank Name", 3 },
                    { 6, "Account Number", 3 }
                });

            migrationBuilder.UpdateData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: 1,
                column: "MembershipId",
                value: 3);

            migrationBuilder.InsertData(
                table: "UserQuestions",
                columns: new[] { "Id", "QuestionId", "Response", "UserProfileId" },
                values: new object[,]
                {
                    { 1, 1, "Admin", 1 },
                    { 2, 2, "Administrator", 1 },
                    { 3, 3, "4", 1 },
                    { 4, 4, "Napoleon", 1 },
                    { 5, 5, "Bank of America", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Memberships");

            migrationBuilder.DropTable(
                name: "QuestionGroups");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "UserQuestions");

            migrationBuilder.DropColumn(
                name: "MembershipId",
                table: "UserProfiles");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a7076818-1111-4c10-81fe-50061ee0a575", "AQAAAAIAAYagAAAAEAihXKio3JJ5tBXYF7KUwFBzJGqjsbrms/5jEalsOHCdqYScWpk/1B2LzCFj1b4X9w==", "b57a7f48-4fd1-4b26-9225-1289d0c25380" });
        }
    }
}
