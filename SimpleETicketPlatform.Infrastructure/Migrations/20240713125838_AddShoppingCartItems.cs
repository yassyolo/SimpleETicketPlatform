using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleETicketPlatform.Infrastructure.Migrations
{
    public partial class AddShoppingCartItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShoppingCartItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Shopping cart item identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false, comment: "Shopping cart items amount"),
                    ShoppingCartId = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Shopping cart identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItem_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Shopping cart item entity");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItem_MovieId",
                table: "ShoppingCartItem",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingCartItem");
        }
    }
}
