using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PROVAAPI.Migrations
{
    /// <inheritdoc />
    public partial class CReateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "alunos",
                columns: table => new
                {
                    AlunoID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Data = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alunos", x => x.AlunoID);
                });

            migrationBuilder.CreateTable(
                name: "imcs",
                columns: table => new
                {
                    ImcID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AlunoID = table.Column<int>(type: "INTEGER", nullable: false),
                    Altura = table.Column<float>(type: "REAL", nullable: false),
                    Peso = table.Column<float>(type: "REAL", nullable: false),
                    ResultadoConta = table.Column<float>(type: "REAL", nullable: false),
                    ResultadoFinalImc = table.Column<string>(type: "TEXT", nullable: true),
                    Obesidade = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_imcs", x => x.ImcID);
                    table.ForeignKey(
                        name: "FK_imcs_alunos_AlunoID",
                        column: x => x.AlunoID,
                        principalTable: "alunos",
                        principalColumn: "AlunoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_imcs_AlunoID",
                table: "imcs",
                column: "AlunoID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "imcs");

            migrationBuilder.DropTable(
                name: "alunos");
        }
    }
}
