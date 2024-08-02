using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleETicketPlatform.Infrastructure.Migrations
{
    public partial class ChangedOrderUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Order user identifier",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Order user identifier");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Orders",
                type: "int",
                nullable: false,
                comment: "Order user identifier",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Order user identifier");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "35d3d6fa-c020-485b-aec0-8845468c4c01",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f0cb2a90-d40e-4677-98dd-c74ecb3fd855", "AQAAAAEAACcQAAAAEH4CCnu4szORXr2oF4xrvubqLBKuXj6PxBrmWloPZM5gJCVsdd2iCt0KOCyIVmM0uA==", "6cf76d73-f852-45fe-92d2-12d00dfa6cd6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f71a12d7-8b47-492c-8585-c5295875e01c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "328540f8-7e19-4847-acca-fbca456afe1e", "AQAAAAEAACcQAAAAEOd8xzekgBj8XfP3GpFDOnF09pu3zL4Xn6tsXg3UsV/yW9uiPJndcmqZx0bSOfKQ1g==", "9caacc6d-e85d-4b76-9d5d-1ce402013281" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 23, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 8, 22, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 3, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 12, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 10, 31, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 22, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 10, 21, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 2, 0, 0, 0, 0, DateTimeKind.Local) });
        }
    }
}
