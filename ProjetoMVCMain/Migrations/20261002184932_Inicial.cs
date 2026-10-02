using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoMVCMain.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fornecedor",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RazaoSocial = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    CNPJ = table.Column<string>(type: "varchar(18)", unicode: false, maxLength: 18, nullable: false),
                    Telefone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Forneced__06370DAD1F34AA2A", x => x.Codigo);
                });

            migrationBuilder.CreateIndex(
                name: "UQ__Forneced__AA57D6B46C9E5EE4",
                table: "Fornecedor",
                column: "CNPJ",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fornecedor");
        }
    }
}
