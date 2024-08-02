using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleETicketPlatform.Infrastructure.Migrations
{
    public partial class SeedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "71b461ba-dc43-4d74-b70f-29499795bea8", "35d3d6fa-c020-485b-aec0-8845468c4c01" },
                    { "6a173502-8668-415e-9ccc-c15da662d7ec", "f71a12d7-8b47-492c-8585-c5295875e01c" }
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "71b461ba-dc43-4d74-b70f-29499795bea8", "35d3d6fa-c020-485b-aec0-8845468c4c01" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6a173502-8668-415e-9ccc-c15da662d7ec", "f71a12d7-8b47-492c-8585-c5295875e01c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "35d3d6fa-c020-485b-aec0-8845468c4c01",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ba69403b-1995-440f-acb2-5af04baca502", "AQAAAAEAACcQAAAAEDel873dprT3Dfsb/Fkydo1lW/BG75plcEywllQ3IEpNQpCI5mYnmJ+7K+OVmskfaw==", "65546648-e372-4c49-8fa4-61fc56cad8dd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f71a12d7-8b47-492c-8585-c5295875e01c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "08308518-f5a9-4da7-90b0-8be5ce224778", "AQAAAAEAACcQAAAAELWiVYNKvsUCwWHX6Kce5gTb+FxBlSSz8jUG5Up5vVs5pE2NKiHHkU2E9cIXXxu3Iw==", "8491d041-f345-4503-aa14-ae5e239a6b19" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 8, 31, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 8, 21, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 2, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 9, 30, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 11, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 10, 30, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 21, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 9, 30, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Local) });
        }
    }
}
