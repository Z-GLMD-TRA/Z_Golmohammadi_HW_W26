using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateTicketDTO3 : Migration
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
                defaultValue: "15093",
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 5,
                oldDefaultValue: 53417);

            migrationBuilder.AlterColumn<int>(
                name: "TicketCount",
                table: "Ticket",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BuyDate",
                table: "Ticket",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 1, 11, 31, 56, 444, DateTimeKind.Utc).AddTicks(2720),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 1, 11, 30, 45, 746, DateTimeKind.Utc).AddTicks(9417));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TicketNumber",
                table: "Ticket",
                type: "int",
                maxLength: 5,
                nullable: false,
                defaultValue: 53417,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5,
                oldDefaultValue: "15093");

            migrationBuilder.AlterColumn<string>(
                name: "TicketCount",
                table: "Ticket",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BuyDate",
                table: "Ticket",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 1, 11, 30, 45, 746, DateTimeKind.Utc).AddTicks(9417),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 1, 11, 31, 56, 444, DateTimeKind.Utc).AddTicks(2720));
        }
    }
}
