using APIControleFinanceiroPessoal.Context;
using APIControleFinanceiroPessoal.Models;
using APIControleFinanceiroPessoal.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIControleFinanceiroPessoal.Controllers;

[Route("[Controller]")]
[ApiController]
public class CategoriaController : ControllerBase
{
    private readonly ICategoriaRepository _categoriaRepository;

    public CategoriaController(ICategoriaRepository categoriaRepository)
    {
        _categoriaRepository = categoriaRepository;
    }

    [HttpGet("ObterCategoriasTransacoes")]
    public ActionResult<IEnumerable<Categoria>> GetCategoriasTransacoes()
    {
        var categorias = _categoriaRepository.GetCategoriasTransacoes();
        if (categorias is null)
            return NotFound("categorias não encontradas.");
        return Ok(categorias);
    }

    [HttpGet]
    public ActionResult<IEnumerable<Categoria>> Get()
    {
        var categorias = _categoriaRepository.GetCategorias();

        if (categorias is null)
            return NotFound("categorias não encontradas.");

        return Ok(categorias);
    }

    [HttpGet("{id:int}", Name = "ObterCategoria")]
    public ActionResult<Categoria> Get(int id)
    {
        var categoria = _categoriaRepository.GetCategoria(id);

        if (categoria is null)
            return NotFound("Categoria não encontrada");

        return categoria;
    }

    [HttpPost]
    public ActionResult Post(Categoria categoria)
    {
        if (categoria is null)
            return BadRequest();

        _categoriaRepository.Create(categoria);

        return new CreatedAtRouteResult("ObterCategoria", new { id = categoria.Id }, categoria);
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Categoria categoria)
    {
        if (id != categoria.Id)
        {
            return BadRequest();
        }

        _categoriaRepository.Update(categoria);

        return Ok(categoria);

    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {

        var categoria = _categoriaRepository.GetCategoria(id);

        if (categoria is null)
        {
            return NotFound("Categoria não encontrada.");
        }

        _categoriaRepository.Delete(id);

        return Ok();
    }


}
