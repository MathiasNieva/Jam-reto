using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artistas",
                columns: table => new
                {
                    ArtistaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artistas", x => x.ArtistaId);
                });

            migrationBuilder.CreateTable(
                name: "Discos",
                columns: table => new
                {
                    DiscoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Año = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discos", x => x.DiscoId);
                });

            migrationBuilder.CreateTable(
                name: "ArtistaDisco",
                columns: table => new
                {
                    ArtistaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiscoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistaDisco", x => new { x.ArtistaId, x.DiscoId });
                    table.ForeignKey(
                        name: "FK_ArtistaDisco_Artistas_ArtistaId",
                        column: x => x.ArtistaId,
                        principalTable: "Artistas",
                        principalColumn: "ArtistaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistaDisco_Discos_DiscoId",
                        column: x => x.DiscoId,
                        principalTable: "Discos",
                        principalColumn: "DiscoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtistaDisco_DiscoId",
                table: "ArtistaDisco",
                column: "DiscoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistaDisco");

            migrationBuilder.DropTable(
                name: "Artistas");

            migrationBuilder.DropTable(
                name: "Discos");
        }
    }
}
