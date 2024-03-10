using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlanketPticeJovana.Migrations
{
    /// <inheritdoc />
    public partial class V1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NepoznataPtica",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NepoznataPtica", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Podrucja",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Podrucja", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Ptica",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Slika = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ptica", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Osobine",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vrednost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ViseVrednosti = table.Column<bool>(type: "bit", nullable: false),
                    PticaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Osobine", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Osobine_Ptica_PticaID",
                        column: x => x.PticaID,
                        principalTable: "Ptica",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Vidjenja",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojVidjenja = table.Column<int>(type: "int", nullable: false),
                    Vreme = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    PticaID = table.Column<int>(type: "int", nullable: true),
                    PodrucjeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vidjenja", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Vidjenja_Podrucja_PodrucjeID",
                        column: x => x.PodrucjeID,
                        principalTable: "Podrucja",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Vidjenja_Ptica_PticaID",
                        column: x => x.PticaID,
                        principalTable: "Ptica",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "NepoznataPticaOsobine",
                columns: table => new
                {
                    NepoznataID = table.Column<int>(type: "int", nullable: false),
                    OsobineID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NepoznataPticaOsobine", x => new { x.NepoznataID, x.OsobineID });
                    table.ForeignKey(
                        name: "FK_NepoznataPticaOsobine_NepoznataPtica_NepoznataID",
                        column: x => x.NepoznataID,
                        principalTable: "NepoznataPtica",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NepoznataPticaOsobine_Osobine_OsobineID",
                        column: x => x.OsobineID,
                        principalTable: "Osobine",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NepoznataPticaOsobine_OsobineID",
                table: "NepoznataPticaOsobine",
                column: "OsobineID");

            migrationBuilder.CreateIndex(
                name: "IX_Osobine_PticaID",
                table: "Osobine",
                column: "PticaID");

            migrationBuilder.CreateIndex(
                name: "IX_Vidjenja_PodrucjeID",
                table: "Vidjenja",
                column: "PodrucjeID");

            migrationBuilder.CreateIndex(
                name: "IX_Vidjenja_PticaID",
                table: "Vidjenja",
                column: "PticaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NepoznataPticaOsobine");

            migrationBuilder.DropTable(
                name: "Vidjenja");

            migrationBuilder.DropTable(
                name: "NepoznataPtica");

            migrationBuilder.DropTable(
                name: "Osobine");

            migrationBuilder.DropTable(
                name: "Podrucja");

            migrationBuilder.DropTable(
                name: "Ptica");
        }
    }
}
