using Microsoft.EntityFrameworkCore.Migrations;

namespace Hayvan_Barinagi.Data.Migrations
{
    public partial class TemelTablolar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cins",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CinsAd = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cinsiyet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CinsiyetAd = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinsiyet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tur",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TurAd = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tur", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hayvan",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(nullable: true),
                    DogumYili = table.Column<int>(nullable: true),
                    Hakkinda = table.Column<string>(nullable: true),
                    Fotograf = table.Column<string>(nullable: true),
                    TurID = table.Column<int>(nullable: false),
                    CinsID = table.Column<int>(nullable: false),
                    CinsiyetID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hayvan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hayvan_Cins_CinsID",
                        column: x => x.CinsID,
                        principalTable: "Cins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hayvan_Cinsiyet_CinsiyetID",
                        column: x => x.CinsiyetID,
                        principalTable: "Cinsiyet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hayvan_Tur_TurID",
                        column: x => x.TurID,
                        principalTable: "Tur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hayvan_CinsID",
                table: "Hayvan",
                column: "CinsID");

            migrationBuilder.CreateIndex(
                name: "IX_Hayvan_CinsiyetID",
                table: "Hayvan",
                column: "CinsiyetID");

            migrationBuilder.CreateIndex(
                name: "IX_Hayvan_TurID",
                table: "Hayvan",
                column: "TurID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hayvan");

            migrationBuilder.DropTable(
                name: "Cins");

            migrationBuilder.DropTable(
                name: "Cinsiyet");

            migrationBuilder.DropTable(
                name: "Tur");
        }
    }
}
