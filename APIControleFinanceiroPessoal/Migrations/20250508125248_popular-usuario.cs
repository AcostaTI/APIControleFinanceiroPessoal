using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIControleFinanceiroPessoal.Migrations
{
    /// <inheritdoc />
    public partial class popularusuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {

            mb.Sql("INSERT INTO usuarios (Nome, DataNascimento, email, Senha, Saldo) VALUES('admin', '1989-06-04', 'ti.alexandre.costa@gmail.com', '@le159357', 0);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM usuarios;");
        }
    }
}
