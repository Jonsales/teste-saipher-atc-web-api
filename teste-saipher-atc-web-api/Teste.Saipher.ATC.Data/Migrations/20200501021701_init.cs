using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Teste.Saipher.ATC.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PLANO_VOO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data_Cadastro = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    Data_Alteracao = table.Column<DateTime>(nullable: true),
                    Numero_voo = table.Column<string>(maxLength: 7, nullable: false),
                    Matricula_Aeronave = table.Column<string>(maxLength: 7, nullable: false),
                    Data_Hora_Voo = table.Column<DateTime>(nullable: false),
                    Tipo_Aeronave = table.Column<string>(maxLength: 4, nullable: false),
                    Origem = table.Column<string>(maxLength: 4, nullable: false),
                    Destino = table.Column<string>(maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PLANO_VOO", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PLANO_VOO_Numero_voo",
                table: "PLANO_VOO",
                column: "Numero_voo",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PLANO_VOO");
        }
    }
}
