using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TemperaturaServer.Migrations
{
    /// <inheritdoc />
    public partial class V1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Meraci",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Interval = table.Column<double>(type: "float", nullable: false),
                    Boja = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    GranicaOd = table.Column<double>(type: "float", nullable: false),
                    GranicaDo = table.Column<double>(type: "float", nullable: false),
                    TrenutnaVrednost = table.Column<double>(type: "float", nullable: false),
                    MinimalnaIzmerenaVrednost = table.Column<double>(type: "float", nullable: false),
                    MaksimalnaIzmerenaVrednost = table.Column<double>(type: "float", nullable: false),
                    ProsecnaIzmerenaVrednost = table.Column<double>(type: "float", nullable: false),
                    BrojMerenja = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meraci", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meraci");
        }
    }
}
