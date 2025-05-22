
using APIControleFinanceiroPessoal.Context;
using APIControleFinanceiroPessoal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIControleFinanceiroPessoal.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TransacaoController : ControllerBase
{
    private readonly AppDbContext _context;
    public TransacaoController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Transacao>> Get()
    {
        var transacao = _context.Transacoes.AsNoTracking().ToList();

        if (transacao is null)
        {
            return NotFound("Transações não encontradas.");
        }

        return Ok(transacao);
    }

    [HttpGet("{id:int}", Name = "ObterTransacao")]
    public ActionResult<Transacao> Get(int id)
    {
        var transacao = _context.Transacoes.FirstOrDefault(t => t.Id == id);

        if (transacao is null)
        {
            return NotFound("Transação não encontrada.");
        }

        return Ok(transacao);
    }

    [HttpPost]
    public ActionResult Post(Transacao transacao)
    {
        if (transacao is null)
        {
            return BadRequest("Transação inválida.");
        }

        _context.Transacoes.Add(transacao);
        _context.SaveChanges();
        return new CreatedAtRouteResult("ObterTransacao", new { id = transacao.Id }, transacao);
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Transacao transacao)
    {
        if (transacao.Id != id)
        {
            BadRequest();
        }

        _context.Entry(transacao).State = EntityState.Modified;
        _context.SaveChanges();

        return Ok();
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var transacao = _context.Transacoes.FirstOrDefault(t => t.Id == id);

        if (transacao is null)
        {
            return NotFound("Transação inválida.");
        }

        _context.Remove(transacao);
        _context.SaveChanges();

        return Ok();
    }
}
