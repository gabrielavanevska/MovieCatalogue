using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieCatalogue.Repository.Migrations
{
    public partial class addedIdentityy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonalMovies",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MovieId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalMovies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalMovies_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonalMovies_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonalMovies_MovieId",
                table: "PersonalMovies",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalMovies_UserId",
                table: "PersonalMovies",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonalMovies");
        }
    }
}
