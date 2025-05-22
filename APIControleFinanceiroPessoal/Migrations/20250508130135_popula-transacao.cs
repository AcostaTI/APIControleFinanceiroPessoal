using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIControleFinanceiroPessoal.Migrations
{
    /// <inheritdoc />
    public partial class populatransacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {

            mb.Sql("INSERT INTO Transacoes (Nome, Valor, Data, Tipo, UsuarioId, CategoriaId) VALUES('Salario', 7000.00, '2025-05-01', 'E', 1, 5);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Transacoes;");
        }
    }
}
