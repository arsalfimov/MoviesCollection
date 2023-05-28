using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MC.PersistanceServices.Migrations
{
    /// <inheritdoc />
    public partial class MigrationName6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MoviesActors",
                table: "MoviesActors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MoviesActors",
                table: "MoviesActors",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_MoviesActors_ActorId",
                table: "MoviesActors",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_MoviesActors_Id",
                table: "MoviesActors",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MoviesActors",
                table: "MoviesActors");

            migrationBuilder.DropIndex(
                name: "IX_MoviesActors_ActorId",
                table: "MoviesActors");

            migrationBuilder.DropIndex(
                name: "IX_MoviesActors_Id",
                table: "MoviesActors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MoviesActors",
                table: "MoviesActors",
                columns: new[] { "ActorId", "MovieId" });
        }
    }
}
