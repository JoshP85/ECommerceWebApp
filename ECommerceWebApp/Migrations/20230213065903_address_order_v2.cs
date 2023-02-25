using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceWebApp.Migrations
{
    /// <inheritdoc />
    public partial class addressorderv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StreetNumber",
                table: "Addresses",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "Street2",
                table: "Addresses",
                newName: "AddressLine2");

            migrationBuilder.RenameColumn(
                name: "Street1",
                table: "Addresses",
                newName: "AddressLine1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "State",
                table: "Addresses",
                newName: "StreetNumber");

            migrationBuilder.RenameColumn(
                name: "AddressLine2",
                table: "Addresses",
                newName: "Street2");

            migrationBuilder.RenameColumn(
                name: "AddressLine1",
                table: "Addresses",
                newName: "Street1");
        }
    }
}
