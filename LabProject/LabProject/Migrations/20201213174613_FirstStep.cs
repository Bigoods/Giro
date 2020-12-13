using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LabProject.Migrations
{
    public partial class FirstStep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aviso",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    foto = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    data = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aviso", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Tipo_Prato",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo_Prato", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Utilizador",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    username = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    password = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    bloqueado = table.Column<bool>(type: "bit", nullable: false),
                    motivo = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    notificacao = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizador", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Prato",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    preco = table.Column<double>(type: "float", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Tipo_PratoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prato", x => x.id);
                    table.ForeignKey(
                        name: "FK__Prato__Tipo_Prat__628FA481",
                        column: x => x.Tipo_PratoId,
                        principalTable: "Tipo_Prato",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Administrador",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UtilizadorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrador", x => x.id);
                    table.ForeignKey(
                        name: "FK__Administr__Utili__32E0915F",
                        column: x => x.UtilizadorId,
                        principalTable: "Utilizador",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UtilizadorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.id);
                    table.ForeignKey(
                        name: "FK__Cliente__Utiliza__33D4B598",
                        column: x => x.UtilizadorId,
                        principalTable: "Utilizador",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Restaurante",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UtilizadorId = table.Column<int>(type: "int", nullable: true),
                    telefone = table.Column<int>(type: "int", nullable: true),
                    foto = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    morada = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    hora_abertura = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    hora_fecho = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    dia_descanso = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    aprovado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurante", x => x.id);
                    table.ForeignKey(
                        name: "FK__Restauran__Utili__37A5467C",
                        column: x => x.UtilizadorId,
                        principalTable: "Utilizador",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cliente_aviso",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: true),
                    AvisoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__Cliente_a__Aviso__4BAC3F29",
                        column: x => x.AvisoId,
                        principalTable: "Aviso",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Cliente_a__Clien__4AB81AF0",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prato_Cliente",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: true),
                    PratoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prato_Cliente", x => x.id);
                    table.ForeignKey(
                        name: "FK__Prato_Pra__Clien__35BCFE0A",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Restaurante_Cliente",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: true),
                    RestauranteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurante_Cliente", x => x.id);
                    table.ForeignKey(
                        name: "FK__Restauran__Clien__38996AB5",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Restauran__Resta__398D8EEE",
                        column: x => x.RestauranteId,
                        principalTable: "Restaurante",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Restaurante_Prato",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dia = table.Column<DateTime>(type: "date", nullable: false),
                    foto = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PratoId = table.Column<int>(type: "int", nullable: true),
                    RestauranteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurante_Prato", x => x.id);
                    table.ForeignKey(
                        name: "FK__Restauran__Prato__693CA210",
                        column: x => x.PratoId,
                        principalTable: "Prato",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Restauran__Resta__68487DD7",
                        column: x => x.RestauranteId,
                        principalTable: "Restaurante",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Administrador_UtilizadorId",
                table: "Administrador",
                column: "UtilizadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_UtilizadorId",
                table: "Cliente",
                column: "UtilizadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_aviso_AvisoId",
                table: "Cliente_aviso",
                column: "AvisoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_aviso_ClienteId",
                table: "Cliente_aviso",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Prato_Tipo_PratoId",
                table: "Prato",
                column: "Tipo_PratoId");

            migrationBuilder.CreateIndex(
                name: "IX_Prato_Cliente_ClienteId",
                table: "Prato_Cliente",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurante_UtilizadorId",
                table: "Restaurante",
                column: "UtilizadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurante_Cliente_ClienteId",
                table: "Restaurante_Cliente",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurante_Cliente_RestauranteId",
                table: "Restaurante_Cliente",
                column: "RestauranteId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurante_Prato_PratoId",
                table: "Restaurante_Prato",
                column: "PratoId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurante_Prato_RestauranteId",
                table: "Restaurante_Prato",
                column: "RestauranteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrador");

            migrationBuilder.DropTable(
                name: "Cliente_aviso");

            migrationBuilder.DropTable(
                name: "Prato_Cliente");

            migrationBuilder.DropTable(
                name: "Restaurante_Cliente");

            migrationBuilder.DropTable(
                name: "Restaurante_Prato");

            migrationBuilder.DropTable(
                name: "Aviso");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Prato");

            migrationBuilder.DropTable(
                name: "Restaurante");

            migrationBuilder.DropTable(
                name: "Tipo_Prato");

            migrationBuilder.DropTable(
                name: "Utilizador");
        }
    }
}
