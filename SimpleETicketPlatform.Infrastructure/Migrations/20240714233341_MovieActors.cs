using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleETicketPlatform.Infrastructure.Migrations
{
    public partial class MovieActors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MovieActors",
                columns: new[] { "ActorId", "MovieId" },
                values: new object[] { 1, 4 });

            migrationBuilder.InsertData(
                table: "MovieActors",
                columns: new[] { "ActorId", "MovieId" },
                values: new object[] { 6, 5 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 6, 5 });
        }
    }
}
