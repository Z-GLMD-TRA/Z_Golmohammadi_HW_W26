using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateTicketDTO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReturnDate",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "SeatNumber",
                table: "Ticket");

            migrationBuilder.RenameColumn(
                name: "PassengerName",
                table: "Ticket",
                newName: "TicketCount");

            migrationBuilder.AlterColumn<string>(
                name: "TicketNumber",
                table: "Ticket",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "90642",
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5,
                oldDefaultValue: "62910");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BuyDate",
                table: "Ticket",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 1, 11, 10, 50, 680, DateTimeKind.Utc).AddTicks(7228),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 31, 22, 55, 49, 769, DateTimeKind.Utc).AddTicks(3222));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TicketCount",
                table: "Ticket",
                newName: "PassengerName");

            migrationBuilder.AlterColumn<string>(
                name: "TicketNumber",
                table: "Ticket",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "62910",
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5,
                oldDefaultValue: "90642");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BuyDate",
                table: "Ticket",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 31, 22, 55, 49, 769, DateTimeKind.Utc).AddTicks(3222),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 1, 11, 10, 50, 680, DateTimeKind.Utc).AddTicks(7228));

            migrationBuilder.AddColumn<DateTime>(
                name: "ReturnDate",
                table: "Ticket",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SeatNumber",
                table: "Ticket",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
