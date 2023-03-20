using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPISmartShop.Migrations
{
    /// <inheritdoc />
    public partial class moredamhendpoints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "createdDate",
                table: "OrderDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "billingAddress",
                table: "OrderDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "shippingAddress",
                table: "OrderDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "shippingType",
                table: "OrderDetails",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "billingAddress",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "shippingAddress",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "shippingType",
                table: "OrderDetails");

            migrationBuilder.AlterColumn<DateTime>(
                name: "createdDate",
                table: "OrderDetails",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
