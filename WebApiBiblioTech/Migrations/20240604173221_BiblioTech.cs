using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapibibliotech.Migrations
{
    /// <inheritdoc />
    public partial class BiblioTech : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    IDGenero = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TituloGenero = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.IDGenero);
                });

            migrationBuilder.CreateTable(
                name: "TiposUsuario",
                columns: table => new
                {
                    IDTipoUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TituloTipoUsuario = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposUsuario", x => x.IDTipoUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Livros",
                columns: table => new
                {
                    IDLivro = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "VARCHAR(60)", nullable: false),
                    Autor = table.Column<string>(type: "VARCHAR(60)", nullable: false),
                    Ano = table.Column<string>(type: "VARCHAR(60)", nullable: false),
                    Editora = table.Column<string>(type: "VARCHAR(60)", nullable: false),
                    ISBN = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: false),
                    Capa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDGenero = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livros", x => x.IDLivro);
                    table.ForeignKey(
                        name: "FK_Livros_Generos_IDGenero",
                        column: x => x.IDGenero,
                        principalTable: "Generos",
                        principalColumn: "IDGenero",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Senha = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: false),
                    IDTipoUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_TiposUsuario_IDTipoUsuario",
                        column: x => x.IDTipoUsuario,
                        principalTable: "TiposUsuario",
                        principalColumn: "IDTipoUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmprestimosLivro",
                columns: table => new
                {
                    IDEmprestimoLivro = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Situacao = table.Column<string>(type: "VARCHAR(60)", nullable: false),
                    DataDevolucao = table.Column<DateTime>(type: "DATE", nullable: false),
                    IDUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDLivro = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmprestimosLivro", x => x.IDEmprestimoLivro);
                    table.ForeignKey(
                        name: "FK_EmprestimosLivro_Livros_IDLivro",
                        column: x => x.IDLivro,
                        principalTable: "Livros",
                        principalColumn: "IDLivro",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmprestimosLivro_Usuarios_IDUsuario",
                        column: x => x.IDUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resenhas",
                columns: table => new
                {
                    IDResenha = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    Exibe = table.Column<bool>(type: "BIT", nullable: false),
                    IDUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDLivro = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resenhas", x => x.IDResenha);
                    table.ForeignKey(
                        name: "FK_Resenhas_Livros_IDLivro",
                        column: x => x.IDLivro,
                        principalTable: "Livros",
                        principalColumn: "IDLivro",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Resenhas_Usuarios_IDUsuario",
                        column: x => x.IDUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmprestimosLivro_IDLivro",
                table: "EmprestimosLivro",
                column: "IDLivro");

            migrationBuilder.CreateIndex(
                name: "IX_EmprestimosLivro_IDUsuario",
                table: "EmprestimosLivro",
                column: "IDUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Livros_IDGenero",
                table: "Livros",
                column: "IDGenero");

            migrationBuilder.CreateIndex(
                name: "IX_Resenhas_IDLivro",
                table: "Resenhas",
                column: "IDLivro");

            migrationBuilder.CreateIndex(
                name: "IX_Resenhas_IDUsuario",
                table: "Resenhas",
                column: "IDUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IDTipoUsuario",
                table: "Usuarios",
                column: "IDTipoUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmprestimosLivro");

            migrationBuilder.DropTable(
                name: "Resenhas");

            migrationBuilder.DropTable(
                name: "Livros");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Generos");

            migrationBuilder.DropTable(
                name: "TiposUsuario");
        }
    }
}
