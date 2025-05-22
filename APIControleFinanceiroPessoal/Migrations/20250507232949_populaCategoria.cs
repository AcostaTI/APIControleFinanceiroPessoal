using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIControleFinanceiroPessoal.Migrations
{
    /// <inheritdoc />
    public partial class populaCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO categorias (nome) VALUES('Alimentação');");
            mb.Sql("INSERT INTO categorias (nome) VALUES('Estudos');");
            mb.Sql("INSERT INTO categorias (nome) VALUES('Diversão');");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM categorias;");
        }
    }
}
