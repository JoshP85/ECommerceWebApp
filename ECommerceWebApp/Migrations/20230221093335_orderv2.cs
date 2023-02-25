using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceWebApp.Migrations
{
    /// <inheritdoc />
    public partial class orderv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShippingAddress",
                table: "Orders",
                newName: "ShippingAddressAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShippingAddressAddressId",
                table: "Orders",
                column: "ShippingAddressAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Addresses_ShippingAddressAddressId",
                table: "Orders",
                column: "ShippingAddressAddressId",
                principalTable: "Addresses",
                principalColumn: "AddressId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Addresses_ShippingAddressAddressId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ShippingAddressAddressId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "ShippingAddressAddressId",
                table: "Orders",
                newName: "ShippingAddress");
        }
    }
}
