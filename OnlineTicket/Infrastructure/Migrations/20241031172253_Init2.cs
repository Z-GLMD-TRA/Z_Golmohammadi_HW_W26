using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_City_CityId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_CityId",
                table: "Address");

            migrationBuilder.AlterColumn<string>(
                name: "TicketNumber",
                table: "Ticket",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "68544",
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5,
                oldDefaultValue: "60404");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BuyDate",
                table: "Ticket",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 31, 17, 22, 52, 964, DateTimeKind.Utc).AddTicks(1974),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 31, 17, 14, 17, 10, DateTimeKind.Utc).AddTicks(5128));

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "City",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Address_CityId",
                table: "Address",
                column: "CityId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_City_CityId",
                table: "Address",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_City_CityId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_CityId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "City");

            migrationBuilder.AlterColumn<string>(
                name: "TicketNumber",
                table: "Ticket",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "60404",
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5,
                oldDefaultValue: "68544");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BuyDate",
                table: "Ticket",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 31, 17, 14, 17, 10, DateTimeKind.Utc).AddTicks(5128),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 31, 17, 22, 52, 964, DateTimeKind.Utc).AddTicks(1974));

            migrationBuilder.CreateIndex(
                name: "IX_Address_CityId",
                table: "Address",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_City_CityId",
                table: "Address",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
