using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebTemplate.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stadion",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Lokacija = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Kapacitet = table.Column<int>(type: "int", nullable: false),
                    DatumOtvaranja = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stadion", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tim",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    URLSlike = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tim", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Utakmica",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojPosetilaca = table.Column<int>(type: "int", nullable: false),
                    PrviRezultat = table.Column<int>(type: "int", nullable: false),
                    DrugiRezultat = table.Column<int>(type: "int", nullable: false),
                    PrviTimID = table.Column<int>(type: "int", nullable: true),
                    DrugiTimID = table.Column<int>(type: "int", nullable: true),
                    StadionID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utakmica", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Utakmica_Stadion_StadionID",
                        column: x => x.StadionID,
                        principalTable: "Stadion",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Utakmica_Tim_DrugiTimID",
                        column: x => x.DrugiTimID,
                        principalTable: "Tim",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Utakmica_Tim_PrviTimID",
                        column: x => x.PrviTimID,
                        principalTable: "Tim",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Utakmica_DrugiTimID",
                table: "Utakmica",
                column: "DrugiTimID");

            migrationBuilder.CreateIndex(
                name: "IX_Utakmica_PrviTimID",
                table: "Utakmica",
                column: "PrviTimID");

            migrationBuilder.CreateIndex(
                name: "IX_Utakmica_StadionID",
                table: "Utakmica",
                column: "StadionID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Utakmica");

            migrationBuilder.DropTable(
                name: "Stadion");

            migrationBuilder.DropTable(
                name: "Tim");
        }
    }
}
