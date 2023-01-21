using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hex.Infra.Migrations
{
    public partial class InicialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cpf = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    Nome = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    TipoEstadoCivil = table.Column<int>(type: "int", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    HealthPlan = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pessoa");
        }
    }
}
