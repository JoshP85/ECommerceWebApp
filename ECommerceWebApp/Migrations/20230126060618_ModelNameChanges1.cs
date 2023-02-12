using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceWebApp.Migrations
{
    /// <inheritdoc />
    public partial class ModelNameChanges1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "ShoppingItems",
                newName: "ShoppingItemTotalPrice");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ShoppingItems",
                newName: "ShoppingItemId");

            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "ShoppingCarts",
                newName: "ShoppingCartTotalPrice");

            migrationBuilder.RenameColumn(
                name: "CartId",
                table: "ShoppingCarts",
                newName: "ShoppingCartId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Products",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ProductCategories",
                newName: "ProductCategoryId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AuthItems",
                newName: "AccountId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Accounts",
                newName: "AccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShoppingItemTotalPrice",
                table: "ShoppingItems",
                newName: "TotalPrice");

            migrationBuilder.RenameColumn(
                name: "ShoppingItemId",
                table: "ShoppingItems",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ShoppingCartTotalPrice",
                table: "ShoppingCarts",
                newName: "TotalPrice");

            migrationBuilder.RenameColumn(
                name: "ShoppingCartId",
                table: "ShoppingCarts",
                newName: "CartId");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Products",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProductCategoryId",
                table: "ProductCategories",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "AuthItems",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Accounts",
                newName: "Id");
        }
    }
}
