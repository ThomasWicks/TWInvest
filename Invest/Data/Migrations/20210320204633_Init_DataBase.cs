using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Invest.Data.Migrations
{
    public partial class Init_DataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Segmento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Segmento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Setor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubSetor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubSetor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClassificacaoSetorial",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDeSubEstacao = table.Column<int>(nullable: false),
                    IdSetor = table.Column<int>(nullable: false),
                    IdSegmento = table.Column<int>(nullable: false),
                    SetorId = table.Column<int>(nullable: true),
                    SubSetorId = table.Column<int>(nullable: true),
                    SegmentoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassificacaoSetorial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassificacaoSetorial_Segmento_SegmentoId",
                        column: x => x.SegmentoId,
                        principalTable: "Segmento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassificacaoSetorial_Setor_SetorId",
                        column: x => x.SetorId,
                        principalTable: "Setor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassificacaoSetorial_SubSetor_SubSetorId",
                        column: x => x.SubSetorId,
                        principalTable: "SubSetor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    CODIGO_CVM = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNPJ = table.Column<string>(nullable: true),
                    NOME_FANTASIA = table.Column<string>(nullable: true),
                    NOME_PREGAO = table.Column<string>(nullable: true),
                    TIPO_PARTICIPANTE = table.Column<string>(nullable: true),
                    SITUACAO = table.Column<string>(nullable: true),
                    DATA_STATUS = table.Column<DateTime>(nullable: false),
                    CODIGO_LISTAGEM = table.Column<string>(nullable: true),
                    ID_ClASSIFICACAO_SETORIAL = table.Column<int>(nullable: false),
                    ClassificacaoSetorialId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.CODIGO_CVM);
                    table.ForeignKey(
                        name: "FK_Empresas_ClassificacaoSetorial_ClassificacaoSetorialId",
                        column: x => x.ClassificacaoSetorialId,
                        principalTable: "ClassificacaoSetorial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CodigoDeNegociacao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TICKER = table.Column<string>(nullable: true),
                    CODIGO_CVM = table.Column<int>(nullable: false),
                    EmpresasCODIGO_CVM = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodigoDeNegociacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CodigoDeNegociacao_Empresas_EmpresasCODIGO_CVM",
                        column: x => x.EmpresasCODIGO_CVM,
                        principalTable: "Empresas",
                        principalColumn: "CODIGO_CVM",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassificacaoSetorial_SegmentoId",
                table: "ClassificacaoSetorial",
                column: "SegmentoId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassificacaoSetorial_SetorId",
                table: "ClassificacaoSetorial",
                column: "SetorId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassificacaoSetorial_SubSetorId",
                table: "ClassificacaoSetorial",
                column: "SubSetorId");

            migrationBuilder.CreateIndex(
                name: "IX_CodigoDeNegociacao_EmpresasCODIGO_CVM",
                table: "CodigoDeNegociacao",
                column: "EmpresasCODIGO_CVM");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_ClassificacaoSetorialId",
                table: "Empresas",
                column: "ClassificacaoSetorialId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CodigoDeNegociacao");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "ClassificacaoSetorial");

            migrationBuilder.DropTable(
                name: "Segmento");

            migrationBuilder.DropTable(
                name: "Setor");

            migrationBuilder.DropTable(
                name: "SubSetor");
        }
    }
}
