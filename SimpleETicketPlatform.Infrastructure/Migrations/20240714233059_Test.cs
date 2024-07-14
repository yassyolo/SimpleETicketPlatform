using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleETicketPlatform.Infrastructure.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ShoppingCartId",
                table: "ShoppingCartItem",
                type: "nvarchar(450)",
                nullable: false,
                comment: "Shopping cart identifier",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Shopping cart identifier");

            migrationBuilder.CreateTable(
                name: "ShoppingCart",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Shopping cart identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCart", x => x.Id);
                },
                comment: "Shopping cart entity");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 8, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 8, 14, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 25, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 9, 23, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 4, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 10, 23, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 14, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 2, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 10, 13, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 9, 23, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 25, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItem_ShoppingCartId",
                table: "ShoppingCartItem",
                column: "ShoppingCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItem_ShoppingCart_ShoppingCartId",
                table: "ShoppingCartItem",
                column: "ShoppingCartId",
                principalTable: "ShoppingCart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItem_ShoppingCart_ShoppingCartId",
                table: "ShoppingCartItem");

            migrationBuilder.DropTable(
                name: "ShoppingCart");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCartItem_ShoppingCartId",
                table: "ShoppingCartItem");

            migrationBuilder.AlterColumn<string>(
                name: "ShoppingCartId",
                table: "ShoppingCartItem",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Shopping cart identifier",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldComment: "Shopping cart identifier");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 8, 22, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 13, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 8, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 23, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 9, 21, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 2, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 8, 12, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 11, 30, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 10, 11, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 9, 21, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 23, 0, 0, 0, 0, DateTimeKind.Local) });
        }
    }
}
