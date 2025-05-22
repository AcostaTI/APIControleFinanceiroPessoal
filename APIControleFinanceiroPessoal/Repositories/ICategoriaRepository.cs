using APIControleFinanceiroPessoal.Models;

namespace APIControleFinanceiroPessoal.Repositories;

public interface ICategoriaRepository
{
    IEnumerable<Categoria> GetCategoriasTransacoes();
    Categoria GetCategoria(int id);
    IEnumerable<Categoria> GetCategorias();
    Categoria Create(Categoria categoria);
    Categoria Update(Categoria categoria);
    Categoria Delete(int id);

}
