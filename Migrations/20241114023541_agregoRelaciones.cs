using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace conversorMonedas.Migrations
{
    /// <inheritdoc />
    public partial class agregoRelaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteCurrency_Currencies_CurrencyId",
                table: "FavoriteCurrency");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteCurrency_Users_UserId",
                table: "FavoriteCurrency");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FavoriteCurrency",
                table: "FavoriteCurrency");

            migrationBuilder.RenameTable(
                name: "FavoriteCurrency",
                newName: "FavoriteCurrencies");

            migrationBuilder.RenameIndex(
                name: "IX_FavoriteCurrency_UserId",
                table: "FavoriteCurrencies",
                newName: "IX_FavoriteCurrencies_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_FavoriteCurrency_CurrencyId",
                table: "FavoriteCurrencies",
                newName: "IX_FavoriteCurrencies_CurrencyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavoriteCurrencies",
                table: "FavoriteCurrencies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteCurrencies_Currencies_CurrencyId",
                table: "FavoriteCurrencies",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteCurrencies_Users_UserId",
                table: "FavoriteCurrencies",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteCurrencies_Currencies_CurrencyId",
                table: "FavoriteCurrencies");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteCurrencies_Users_UserId",
                table: "FavoriteCurrencies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FavoriteCurrencies",
                table: "FavoriteCurrencies");

            migrationBuilder.RenameTable(
                name: "FavoriteCurrencies",
                newName: "FavoriteCurrency");

            migrationBuilder.RenameIndex(
                name: "IX_FavoriteCurrencies_UserId",
                table: "FavoriteCurrency",
                newName: "IX_FavoriteCurrency_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_FavoriteCurrencies_CurrencyId",
                table: "FavoriteCurrency",
                newName: "IX_FavoriteCurrency_CurrencyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavoriteCurrency",
                table: "FavoriteCurrency",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteCurrency_Currencies_CurrencyId",
                table: "FavoriteCurrency",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteCurrency_Users_UserId",
                table: "FavoriteCurrency",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
