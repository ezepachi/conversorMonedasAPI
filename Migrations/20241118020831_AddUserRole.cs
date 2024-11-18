using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace conversorMonedas.Migrations
{
    /// <inheritdoc />
    public partial class AddUserRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubscriptionId",
                table: "Users",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Firstname", "Lastname", "Password", "Role", "SubscriptionId", "Username" },
                values: new object[,]
                {
                    { 1, "john@example.com", "John", "Doe", "123456", 0, 1, "user1" },
                    { 2, "jane@example.com", "Jane", "Smith", "654321", 0, 2, "user2" }
                });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "ConversionLimit", "ExpirationDate", "Type", "UserId" },
                values: new object[,]
                {
                    { 1, 10, new DateTime(2024, 12, 18, 2, 8, 31, 142, DateTimeKind.Utc).AddTicks(620), "Free", 1 },
                    { 2, -1, new DateTime(2025, 11, 18, 2, 8, 31, 142, DateTimeKind.Utc).AddTicks(630), "Premium", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subscriptions",
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

            migrationBuilder.DropColumn(
                name: "SubscriptionId",
                table: "Users");
        }
    }
}
