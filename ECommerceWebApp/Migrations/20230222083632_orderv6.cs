using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceWebApp.Migrations
{
    /// <inheritdoc />
    public partial class orderv6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Accounts_AccountId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_AccountId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Addresses");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AddressId",
                table: "Accounts",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Addresses_AddressId",
                table: "Accounts",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "AddressId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Addresses_AddressId",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_AddressId",
                table: "Accounts");

            migrationBuilder.AddColumn<string>(
                name: "AccountId",
                table: "Addresses",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_AccountId",
                table: "Addresses",
                column: "AccountId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Accounts_AccountId",
                table: "Addresses",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "AccountId");
        }
    }
}
