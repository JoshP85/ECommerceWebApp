using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceWebApp.Migrations
{
    /// <inheritdoc />
    public partial class orderv3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Addresses_ShippingAddressAddressId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "ShippingAddressAddressId",
                table: "Orders",
                newName: "AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_ShippingAddressAddressId",
                table: "Orders",
                newName: "IX_Orders_AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Addresses_AddressId",
                table: "Orders",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "AddressId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Addresses_AddressId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "Orders",
                newName: "ShippingAddressAddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_AddressId",
                table: "Orders",
                newName: "IX_Orders_ShippingAddressAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Addresses_ShippingAddressAddressId",
                table: "Orders",
                column: "ShippingAddressAddressId",
                principalTable: "Addresses",
                principalColumn: "AddressId");
        }
    }
}
