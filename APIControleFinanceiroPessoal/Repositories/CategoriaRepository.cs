﻿using APIControleFinanceiroPessoal.Context;
using APIControleFinanceiroPessoal.Models;
using Microsoft.EntityFrameworkCore;

namespace APIControleFinanceiroPessoal.Repositories;

public class CategoriaRepository : ICategoriaRepository
{
    private readonly AppDbContext _context;

    public CategoriaRepository(AppDbContext context)
    {
        _context = context;
    }

    public Categoria Delete(int id)
    {
        var categoria = _context.Categorias.Find(id);

        if (categoria is null)
            throw new ArgumentNullException(nameof(categoria)); 

        _context.Categorias.Remove(categoria);
        _context.SaveChanges();

        return categoria;
    }

    public Categoria GetCategoria(int id)
    {
        return _context.Categorias.FirstOrDefault(c => c.Id == id);
    }

    public IEnumerable<Categoria> GetCategorias()
    {
        return _context.Categorias.AsNoTracking().ToList();
    }

    public IEnumerable<Categoria> GetCategoriasTransacoes()
    {
        return _context.Categorias.Include(c => c.Transacoes).ToList();
    }

    public Categoria Create(Categoria categoria)
    {
        if (categoria is null)
            throw new ArgumentNullException(nameof(categoria));

        _context.Categorias.Add(categoria);
        _context.SaveChanges();

        return categoria;
    }

    public Categoria Update(Categoria categoria)
    {
        if (categoria is null)
            throw new ArgumentNullException(nameof(categoria));

        _context.Entry(categoria).State = EntityState.Modified;
        _context.SaveChanges();

        return categoria;
    }
}
