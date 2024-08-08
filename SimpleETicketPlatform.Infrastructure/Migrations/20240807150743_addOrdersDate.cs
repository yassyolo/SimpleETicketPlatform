using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleETicketPlatform.Infrastructure.Migrations
{
    public partial class addOrdersDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Order date when made");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "Application user full name",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Application user full name");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "35d3d6fa-c020-485b-aec0-8845468c4c01",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "db88240e-ec94-4ccb-a9d8-31d82dd1a0ca", "AQAAAAEAACcQAAAAEAe3oiBq6Vxl6rjuw8ZnvNkBy7J1C3qO8TcxW3pTvTgMZ6nMawAw7cSiiAoDIy4YxQ==", "cafb0281-c7a9-422a-8393-0e0da32d8811" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f71a12d7-8b47-492c-8585-c5295875e01c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7570406b-91a1-4266-bc33-1399d832d92e", "AQAAAAEAACcQAAAAECdYI5FG+vTTNkh0OPVL5JVWa9RH0OUP3NtE+CXthMo73EQmkCEj7O1zMtmnMuG++A==", "2d4a85c8-0857-4e14-950e-fa70df9c796f" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 9, 16, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 7, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 9, 6, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 18, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 10, 16, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 27, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 9, 6, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 11, 5, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 10, 16, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 17, 0, 0, 0, 0, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Application user full name",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "Application user full name");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "35d3d6fa-c020-485b-aec0-8845468c4c01",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "139fa424-a384-43b9-89e4-c4ca794ca9cf", "AQAAAAEAACcQAAAAENsNi9/4wx5T1AAY64J9IzlsA62SgPpKUYaVXKZAPo4BNTwN64bM5RWTF5e3v0hTpA==", "fc4667e6-7f8f-4bd1-974c-8238bb1c2085" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f71a12d7-8b47-492c-8585-c5295875e01c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "96bbc012-2bc8-4a4a-8e4b-5eea59a4db09", "AQAAAAEAACcQAAAAECH0zr5Kq9+Kr+tFGKUnxZn/AnlN2/ZFhEbCxiYSGrC7JZNhqNdvNRpIzm9tMbLhfA==", "63a912c4-4699-48a7-8cef-84e210ad170a" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 9, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 2, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 13, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 10, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 22, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 20, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 10, 31, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 10, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 12, 0, 0, 0, 0, DateTimeKind.Local) });
        }
    }
}
