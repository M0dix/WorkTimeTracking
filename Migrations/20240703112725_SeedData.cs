using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkTimeTracking.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Patronymic" },
                values: new object[,]
                {
                    { 1, "ivan@example.com", "Иванов", "Иван", "Иванович" },
                    { 2, "dmitriy@example.com", "Дмитриев", "Дмитрий", "Дмитриевич" }
                });

            migrationBuilder.InsertData(
                table: "WorkReports",
                columns: new[] { "Id", "Note", "Hours", "Date", "UserId" },
                values: new object[,]
                {
                    { 1, "Первый отчёт", 8, new DateTime(2024, 1, 1).ToUniversalTime(), 1 },
                    { 2, "Второй отчёт", 6, new DateTime(2024, 1, 2).ToUniversalTime(), 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WorkReports",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WorkReports",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
