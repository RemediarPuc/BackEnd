using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RemediarAPI.Migrations
{
    /// <inheritdoc />
    public partial class CriandoBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medicamentos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeMedicamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    unidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    quantidade = table.Column<int>(type: "int", nullable: false),
                    dtVencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    valor = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicamentos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numPessoaCasa = table.Column<int>(type: "int", nullable: false),
                    escolaridade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    faixaEtaria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rendaFamiliar = table.Column<double>(type: "float", nullable: false),
                    estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    regiao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rua = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tipoUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "MedicamentosDescartados",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dtDescarte = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dtVencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    qtdDescartada = table.Column<int>(type: "int", nullable: false),
                    valorDescartado = table.Column<double>(type: "float", nullable: false),
                    medicamentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicamentosDescartados", x => x.id);
                    table.ForeignKey(
                        name: "FK_MedicamentosDescartados_Medicamentos_medicamentoId",
                        column: x => x.medicamentoId,
                        principalTable: "Medicamentos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doacoes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeMedicamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    qtdCaixas = table.Column<int>(type: "int", nullable: false),
                    qtdMg = table.Column<int>(type: "int", nullable: false),
                    dtValidade = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dtRetirada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    valorDoacao = table.Column<double>(type: "float", nullable: false),
                    usuarioId = table.Column<int>(type: "int", nullable: false),
                    statusDoacao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doacoes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Doacoes_Usuarios_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeMedicamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dosagem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    unidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    quantidade = table.Column<int>(type: "int", nullable: false),
                    usoContinuo = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nomeUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataRetirada = table.Column<DateTime>(type: "datetime2", nullable: true),
                    valorPedido = table.Column<double>(type: "float", nullable: false),
                    usuarioId = table.Column<int>(type: "int", nullable: false),
                    statusPedido = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Pedidos_Usuarios_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doacoes_usuarioId",
                table: "Doacoes",
                column: "usuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicamentosDescartados_medicamentoId",
                table: "MedicamentosDescartados",
                column: "medicamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_usuarioId",
                table: "Pedidos",
                column: "usuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doacoes");

            migrationBuilder.DropTable(
                name: "MedicamentosDescartados");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Medicamentos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
