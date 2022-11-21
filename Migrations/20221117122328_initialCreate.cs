using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ufrSet.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administration",
                columns: table => new
                {
                    matricule = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Profession = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administration", x => x.matricule);
                });

            migrationBuilder.CreateTable(
                name: "Pers",
                columns: table => new
                {
                    matricule = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    profession = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pers", x => x.matricule);
                });

            migrationBuilder.CreateTable(
                name: "Ufr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ufr", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UfrId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departement_Ufr_UfrId",
                        column: x => x.UfrId,
                        principalTable: "Ufr",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Filiere",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartementId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filiere", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Filiere_Departement_DepartementId",
                        column: x => x.DepartementId,
                        principalTable: "Departement",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departement_UfrId",
                table: "Departement",
                column: "UfrId");

            migrationBuilder.CreateIndex(
                name: "IX_Filiere_DepartementId",
                table: "Filiere",
                column: "DepartementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administration");

            migrationBuilder.DropTable(
                name: "Filiere");

            migrationBuilder.DropTable(
                name: "Pers");

            migrationBuilder.DropTable(
                name: "Departement");

            migrationBuilder.DropTable(
                name: "Ufr");
        }
    }
}
