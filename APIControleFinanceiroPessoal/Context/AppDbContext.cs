﻿using APIControleFinanceiroPessoal.Models;
using Microsoft.EntityFrameworkCore;

namespace APIControleFinanceiroPessoal.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

       
    }

    public DbSet<Usuario>? Usuarios { get; set; }
    public DbSet<Categoria>? Categorias { get; set; }
    public DbSet<Transacao>? Transacoes { get; set; }
}
