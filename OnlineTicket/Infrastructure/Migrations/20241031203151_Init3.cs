using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TicketNumber",
                table: "Ticket",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "37301",
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5,
                oldDefaultValue: "68544");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BuyDate",
                table: "Ticket",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 31, 20, 31, 46, 761, DateTimeKind.Utc).AddTicks(4589),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 31, 17, 22, 52, 964, DateTimeKind.Utc).AddTicks(1974));

            migrationBuilder.AlterColumn<string>(
                name: "CategoryDescription",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                oldDefaultValue: "37301");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BuyDate",
                table: "Ticket",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 31, 17, 22, 52, 964, DateTimeKind.Utc).AddTicks(1974),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 31, 20, 31, 46, 761, DateTimeKind.Utc).AddTicks(4589));

            migrationBuilder.AlterColumn<string>(
                name: "CategoryDescription",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
