using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebTemplate.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menii",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menii", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Zalihe",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kolicina = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zalihe", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Prodavnice",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Lokacija = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MeniiID = table.Column<int>(type: "int", nullable: true),
                    ZaliheUProdavniciID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prodavnice", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Prodavnice_Menii_MeniiID",
                        column: x => x.MeniiID,
                        principalTable: "Menii",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Prodavnice_Zalihe_ZaliheUProdavniciID",
                        column: x => x.ZaliheUProdavniciID,
                        principalTable: "Zalihe",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Proizvodi",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Lokacija = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ZaliheProizvodaID = table.Column<int>(type: "int", nullable: true),
                    MeniID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvodi", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Proizvodi_Menii_MeniID",
                        column: x => x.MeniID,
                        principalTable: "Menii",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Proizvodi_Zalihe_ZaliheProizvodaID",
                        column: x => x.ZaliheProizvodaID,
                        principalTable: "Zalihe",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Sastojci",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ZaliheSastojkaID = table.Column<int>(type: "int", nullable: true),
                    ProizvodID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sastojci", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Sastojci_Proizvodi_ProizvodID",
                        column: x => x.ProizvodID,
                        principalTable: "Proizvodi",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Sastojci_Zalihe_ZaliheSastojkaID",
                        column: x => x.ZaliheSastojkaID,
                        principalTable: "Zalihe",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prodavnice_MeniiID",
                table: "Prodavnice",
                column: "MeniiID");

            migrationBuilder.CreateIndex(
                name: "IX_Prodavnice_ZaliheUProdavniciID",
                table: "Prodavnice",
                column: "ZaliheUProdavniciID");

            migrationBuilder.CreateIndex(
                name: "IX_Proizvodi_MeniID",
                table: "Proizvodi",
                column: "MeniID");

            migrationBuilder.CreateIndex(
                name: "IX_Proizvodi_ZaliheProizvodaID",
                table: "Proizvodi",
                column: "ZaliheProizvodaID");

            migrationBuilder.CreateIndex(
                name: "IX_Sastojci_ProizvodID",
                table: "Sastojci",
                column: "ProizvodID");

            migrationBuilder.CreateIndex(
                name: "IX_Sastojci_ZaliheSastojkaID",
                table: "Sastojci",
                column: "ZaliheSastojkaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prodavnice");

            migrationBuilder.DropTable(
                name: "Sastojci");

            migrationBuilder.DropTable(
                name: "Proizvodi");

            migrationBuilder.DropTable(
                name: "Menii");

            migrationBuilder.DropTable(
                name: "Zalihe");
        }
    }
}
