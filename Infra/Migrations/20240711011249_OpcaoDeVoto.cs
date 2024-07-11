using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class OpcaoDeVoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Opcoes",
                table: "Votacoes");

            migrationBuilder.CreateTable(
                name: "OpcaoDeVoto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VotacaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpcaoDeVoto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpcaoDeVoto_Votacoes_VotacaoId",
                        column: x => x.VotacaoId,
                        principalTable: "Votacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OpcaoDeVoto_VotacaoId",
                table: "OpcaoDeVoto",
                column: "VotacaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OpcaoDeVoto");

            migrationBuilder.AddColumn<string>(
                name: "Opcoes",
                table: "Votacoes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
